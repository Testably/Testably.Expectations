using FluentAssertions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Formatting;
using Xunit;

namespace Testably.Expectations.Features.Tests;

public sealed class CompareFeatureGapWithFluentAssertionsTests
{
	#region Test Setup

	private readonly Dictionary<string, Dictionary<string, string>> _existingMapping = new()
	{
		{
			"Boolean", new Dictionary<string, string>
			{
				{ ".Should().BeFalse()", ".Should().BeFalse()" },
				{ ".Should().BeTrue()", ".Should().BeTrue()" },
				{ ".Should().Be(bool)", ".Should().Be(bool)" },
			}
		},
	};

	#endregion

	[Fact]
	public async Task CompareFeatureGap()
	{
		StringBuilder sb = new();
		sb.AppendLine("# Feature Gap between FluentAssertions and Testably.Expectations");
		sb.AppendLine();
		sb.AppendLine(
			"|        Category         |                   FluentAssertions                   |                Testably.Expectations                 |");
		sb.AppendLine(
			"| ----------------------- | ---------------------------------------------------- | ---------------------------------------------------- |");
		IEnumerable<Type> types = typeof(BooleanAssertions).Assembly.GetTypes()
			.Where(x => x.Name.Contains("Assertions"))
			.OrderBy(x => x.Name);
		List<string> ignoredMethodNames =
		[
			"Equals",
			"GetHashCode",
			"GetType",
			"ToString"
		];

		foreach (Type type in types)
		{
			string groupName = type.Name;
			if (groupName.EndsWith("Assertions", StringComparison.Ordinal))
			{
				groupName = groupName.Substring(0, groupName.Length - "Assertions".Length);
			}
			else if (groupName.EndsWith("Assertions`1", StringComparison.Ordinal))
			{
				groupName = $"{groupName.Substring(0, groupName.Length - "Assertions`1".Length)}?";
			}
			else
			{
				continue;
			}

			int index = 0;
			foreach (MethodInfo method in type.GetMethods().Where(x => x.IsPublic))
			{
				if (ignoredMethodNames.Contains(method.Name) ||
				    method.Name.StartsWith("get_", StringComparison.Ordinal))
				{
					continue;
				}

				if (index++ == 0)
				{
					sb.Append("| ").Append(groupName).Append(new string(' ', 23 - groupName.Length))
						.Append(" |");
				}
				else
				{
					sb.Append("|                         |");
				}

				StringBuilder fluentAssertionsMethodBuilder = new();
				fluentAssertionsMethodBuilder.Append(".Should().").Append(method.Name).Append('(');
				bool isFirst = true;
				foreach (ParameterInfo parameter in method.GetParameters())
				{
					if (parameter.Name is "because" or "becauseArgs")
					{
						continue;
					}

					if (!isFirst)
					{
						fluentAssertionsMethodBuilder.Append(", ");
					}

					isFirst = false;
					fluentAssertionsMethodBuilder.Append(
						Formatter.Format(parameter.ParameterType, FormattingOptions.SingleLine));
				}

				fluentAssertionsMethodBuilder.Append(')');

				string fluentAssertionsMethod = fluentAssertionsMethodBuilder.ToString();
				sb.Append($" `{fluentAssertionsMethod}`");
				sb.Append(new string(' ', Math.Max(0, 50 - fluentAssertionsMethod.Length)));
				sb.Append(" | ");
				if (_existingMapping.TryGetValue(groupName,
					    out Dictionary<string, string>? existingGroup) &&
				    existingGroup.TryGetValue(fluentAssertionsMethod, out string? existingMapping))
				{
					sb.Append($"`{existingMapping}`");
					sb.Append(new string(' ', Math.Max(0, 50 - fluentAssertionsMethod.Length)));
				}
				else
				{
					sb.Append(new string(' ', 52));
				}

				sb.AppendLine(" |");
			}
		}

		string result = sb.ToString();
		string content = await File.ReadAllTextAsync(Path.Combine("..", "..", "..", "..", "Docs",
			"FeatureGapToFluentAssertions.md"));

		await Expect.That(content).Should().Be(result);
	}
}
