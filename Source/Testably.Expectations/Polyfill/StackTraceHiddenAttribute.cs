﻿#if !NET6_0_OR_GREATER
// ReSharper disable once CheckNamespace
namespace System.Diagnostics;

[AttributeUsage(AttributeTargets.Class |
                AttributeTargets.Method |
                AttributeTargets.Constructor |
                AttributeTargets.Struct,
	Inherited = false)]
public sealed class StackTraceHiddenAttribute : Attribute
{
}
#endif
