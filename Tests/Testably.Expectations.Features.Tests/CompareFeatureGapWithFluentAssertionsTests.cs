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
			"Action", new Dictionary<string, string>
			{
				{ ".Should().NotThrow()", $".Should().{nameof(ThatDelegateShould.NotThrow)}()" },
				{ ".Should().Throw<TException>()", $".Should().{nameof(ThatDelegateShould.Throw)}<TException>()" },
				{ ".Should().ThrowExactly<TException>()", $".Should().{nameof(ThatDelegateShould.ThrowExactly)}<TException>()" },
			}
		},
		{
			"Assembly", new Dictionary<string, string>
			{
			}
		},
		{
			"Boolean", new Dictionary<string, string>
			{
				{ ".Should().BeFalse()", $".Should().{nameof(ThatBoolShould.BeFalse)}()" },
				{ ".Should().BeTrue()", $".Should().{nameof(ThatBoolShould.BeTrue)}()" },
				{ ".Should().Be(bool)", $".Should().{nameof(ThatBoolShould.Be)}(bool)" },
				{ ".Should().NotBe(bool)", $".Should().{nameof(ThatBoolShould.NotBe)}(bool)" },
				{ ".Should().Imply(bool)", $".Should().{nameof(ThatBoolShould.Imply)}(bool)" },
			}
		},
		{
			"BufferedStream", new Dictionary<string, string>
			{
				{ ".Should().HaveBufferSize(int)", $".Should().{nameof(ThatBufferedStreamShould.HaveBufferSize)}(long)" },
				{ ".Should().NotHaveBufferSize(int)", $".Should().{nameof(ThatBufferedStreamShould.NotHaveBufferSize)}(long)" },
				{ ".Should().BeReadable()", $".Should().{nameof(ThatStreamShould.BeReadable)}()" },
				{ ".Should().BeReadOnly()", $".Should().{nameof(ThatStreamShould.BeReadOnly)}()" },
				{ ".Should().BeSeekable()", $".Should().{nameof(ThatStreamShould.BeSeekable)}()" },
				{ ".Should().BeWritable()", $".Should().{nameof(ThatStreamShould.BeWritable)}()" },
				{ ".Should().BeWriteOnly()", $".Should().{nameof(ThatStreamShould.BeWriteOnly)}()" },
				{ ".Should().HaveLength()", $".Should().{nameof(ThatStreamShould.HaveLength)}()" },
				{ ".Should().HavePosition()", $".Should().{nameof(ThatStreamShould.HavePosition)}()" },
				{ ".Should().NotBeReadable()", $".Should().{nameof(ThatStreamShould.NotBeReadable)}()" },
				{ ".Should().NotBeReadOnly()", $".Should().{nameof(ThatStreamShould.NotBeReadOnly)}()" },
				{ ".Should().NotBeSeekable()", $".Should().{nameof(ThatStreamShould.NotBeSeekable)}()" },
				{ ".Should().NotBeWritable()", $".Should().{nameof(ThatStreamShould.NotBeWritable)}()" },
				{ ".Should().NotBeWriteOnly()", $".Should().{nameof(ThatStreamShould.NotBeWriteOnly)}()" },
				{ ".Should().NotHaveLength()", $".Should().{nameof(ThatStreamShould.NotHaveLength)}()" },
				{ ".Should().NotHavePosition()", $".Should().{nameof(ThatStreamShould.NotHavePosition)}()" },
			}
		},
		{
			"Byte", new Dictionary<string, string>
			{
				{ ".Should().Be(byte?)", $".Should().{nameof(ThatNumberShould.Be)}(byte?)" },
				{ ".Should().Be(byte)", $".Should().{nameof(ThatNumberShould.Be)}(byte?)" },
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

		Dictionary<string, List<string>> foundGroups = new();

		foreach (Type type in types)
		{
			string groupName = type.Name;
			if (groupName.EndsWith("Assertions", StringComparison.Ordinal))
			{
				groupName = groupName.Substring(0, groupName.Length - "Assertions".Length);
			}
			else if (groupName.EndsWith("Assertions`1", StringComparison.Ordinal))
			{
				groupName = $"{groupName.Substring(0, groupName.Length - "Assertions`1".Length)}";
			}
			else
			{
				continue;
			}

			foundGroups[groupName] = new List<string>();

			foreach (MethodInfo method in type.GetMethods().Where(x => x.IsPublic))
			{
				if (ignoredMethodNames.Contains(method.Name) ||
				    method.Name.StartsWith("get_", StringComparison.Ordinal))
				{
					continue;
				}

				StringBuilder fluentAssertionsMethodBuilder = new();
				fluentAssertionsMethodBuilder.Append(".Should().").Append(method.Name);

				if (method.IsGenericMethod)
				{
					MethodInfo genericMethodDefinition = method.GetGenericMethodDefinition();
					fluentAssertionsMethodBuilder.Append('<');
					fluentAssertionsMethodBuilder.Append(string.Join(", ",
						genericMethodDefinition.GetGenericArguments().Select(x => x.Name)));
					fluentAssertionsMethodBuilder.Append('>');
				}

				fluentAssertionsMethodBuilder.Append('(');
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
				foundGroups[groupName].Add(fluentAssertionsMethod);
			}
		}

		foreach (KeyValuePair<string, List<string>> group in foundGroups.OrderBy(x => x.Key))
		{
			int index = 0;
			foreach (string method in group.Value.Distinct().OrderBy(x => x))
			{
				if (index++ == 0)
				{
					sb.Append("| ").Append(group.Key).Append(new string(' ', 23 - group.Key.Length))
						.Append(" |");
				}
				else
				{
					sb.Append("|                         |");
				}

				sb.Append($" `{method}`");
				sb.Append(new string(' ', Math.Max(0, 50 - method.Length)));
				sb.Append(" | ");
				if (_existingMapping.TryGetValue(group.Key,
					    out Dictionary<string, string>? existingGroup) &&
				    existingGroup.TryGetValue(method, out string? existingMapping))
				{
					sb.Append($"`{existingMapping}`");
					sb.Append(new string(' ', Math.Max(0, 50 - method.Length)));
				}
				else
				{
					sb.Append(new string(' ', 52));
				}

				sb.AppendLine(" |");
			}
		}

		string filePath = Path.Combine("..", "..", "..", "..", "Docs",
			"FeatureGapToFluentAssertions.md");
		string result = sb.ToString();
		string content = await File.ReadAllTextAsync(filePath);

#if DEBUG
		await File.WriteAllTextAsync(filePath, result);
#endif

		await Expect.That(content).Should().Be(result);
	}
}
