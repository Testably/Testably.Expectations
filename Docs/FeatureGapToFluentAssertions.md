# Feature Gap between FluentAssertions and Testably.Expectations

|        Category         |                   FluentAssertions                   |                Testably.Expectations                 |
| ----------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| Action                  | `.Should().Match(Expression<Func<Action, bool>>)`    | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotThrow()`                               | `.Should().NotThrow()`                               |
|                         | `.Should().NotThrow<TException>()`                   | ``                                                   |
|                         | `.Should().NotThrowAfter(TimeSpan, TimeSpan)`        | ``                                                   |
|                         | `.Should().Throw<TException>()`                      | `.Should().Throw<TException>()`                      |
|                         | `.Should().ThrowExactly<TException>()`               | `.Should().ThrowExactly<TException>()`               |
| Assembly                | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeSameAs(Assembly)`                       | `.Should().BeSameAs(Assembly)`                       |
|                         | `.Should().BeSignedWithPublicKey(string)`            | ``                                                   |
|                         | `.Should().BeUnsigned()`                             | ``                                                   |
|                         | `.Should().DefineType(string, string)`               | ``                                                   |
|                         | `.Should().Match(Expression<Func<Assembly, bool>>)`  | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeSameAs(Assembly)`                    | `.Should().NotBeSameAs(Assembly)`                    |
|                         | `.Should().NotReference(Assembly)`                   | ``                                                   |
|                         | `.Should().Reference(Assembly)`                      | ``                                                   |
| Boolean                 | `.Should().Be(bool)`                                 | `.Should().Be(bool)`                                 |
|                         | `.Should().BeFalse()`                                | `.Should().BeFalse()`                                |
|                         | `.Should().BeTrue()`                                 | `.Should().BeTrue()`                                 |
|                         | `.Should().Imply(bool)`                              | `.Should().Imply(bool)`                              |
|                         | `.Should().NotBe(bool)`                              | `.Should().NotBe(bool)`                              |
| BufferedStream          | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeReadable()`                             | `.Should().BeReadable()`                             |
|                         | `.Should().BeReadOnly()`                             | `.Should().BeReadOnly()`                             |
|                         | `.Should().BeSameAs(BufferedStream)`                 | ``                                                   |
|                         | `.Should().BeSeekable()`                             | `.Should().BeSeekable()`                             |
|                         | `.Should().BeWritable()`                             | `.Should().BeWritable()`                             |
|                         | `.Should().BeWriteOnly()`                            | `.Should().BeWriteOnly()`                            |
|                         | `.Should().HaveBufferSize(int)`                      | `.Should().HaveBufferSize(long)`                     |
|                         | `.Should().HaveLength(long)`                         | `.Should().HaveLength(long)`                         |
|                         | `.Should().HavePosition(long)`                       | `.Should().HavePosition(long)`                       |
|                         | `.Should().Match(Expression<Func<BufferedStream, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeReadable()`                          | `.Should().NotBeReadable()`                          |
|                         | `.Should().NotBeReadOnly()`                          | `.Should().NotBeReadOnly()`                          |
|                         | `.Should().NotBeSameAs(BufferedStream)`              | ``                                                   |
|                         | `.Should().NotBeSeekable()`                          | `.Should().NotBeSeekable()`                          |
|                         | `.Should().NotBeWritable()`                          | `.Should().NotBeWritable()`                          |
|                         | `.Should().NotBeWriteOnly()`                         | `.Should().NotBeWriteOnly()`                         |
|                         | `.Should().NotHaveBufferSize(int)`                   | `.Should().NotHaveBufferSize(long)`                  |
|                         | `.Should().NotHaveLength(long)`                      | `.Should().NotHaveLength(long)`                      |
|                         | `.Should().NotHavePosition(long)`                    | `.Should().NotHavePosition(long)`                    |
| Byte                    | `.Should().Be(byte?)`                                | `.Should().Be(byte?)`                                |
|                         | `.Should().Be(byte)`                                 | `.Should().Be(byte?)`                                |
|                         | `.Should().BeGreaterOrEqualTo(byte)`                 | ``                                                   |
|                         | `.Should().BeGreaterThan(byte)`                      | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(byte)`             | ``                                                   |
|                         | `.Should().BeInRange(byte, byte)`                    | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(byte)`                    | ``                                                   |
|                         | `.Should().BeLessThan(byte)`                         | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(byte)`                | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(byte[])`                          | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<byte>)`               | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<byte, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(byte?)`                             | ``                                                   |
|                         | `.Should().NotBe(byte)`                              | ``                                                   |
|                         | `.Should().NotBeInRange(byte, byte)`                 | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| ComparableType          | `.Should().Be(T)`                                    | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(T)`                    | ``                                                   |
|                         | `.Should().BeGreaterThan(T)`                         | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(T)`                | ``                                                   |
|                         | `.Should().BeInRange(T, T)`                          | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(T)`                       | ``                                                   |
|                         | `.Should().BeLessThan(T)`                            | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(T)`                   | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<T>)`                  | ``                                                   |
|                         | `.Should().BeOneOf(T[])`                             | ``                                                   |
|                         | `.Should().BeRankedEquallyTo(T)`                     | ``                                                   |
|                         | `.Should().BeSameAs(IComparable<T>)`                 | ``                                                   |
|                         | `.Should().Match(Expression<Func<IComparable<T>, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(T)`                                 | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeInRange(T, T)`                       | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeRankedEquallyTo(T)`                  | ``                                                   |
|                         | `.Should().NotBeSameAs(IComparable<T>)`              | ``                                                   |
| ConstructorInfo         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>()`            | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(ConstructorInfo)`                | ``                                                   |
|                         | `.Should().HaveAccessModifier(CSharpAccessModifier)` | ``                                                   |
|                         | `.Should().Match(Expression<Func<ConstructorInfo, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>()`         | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(ConstructorInfo)`             | ``                                                   |
|                         | `.Should().NotHaveAccessModifier(CSharpAccessModifier)` | ``                                                   |
| DataColumn              | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataColumn, Func<IDataEquivalencyAssertionOptions<DataColumn>, IDataEquivalencyAssertionOptions<DataColumn>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataColumn)`               | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(DataColumn)`                     | ``                                                   |
|                         | `.Should().Match(Expression<Func<DataColumn, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(DataColumn)`                  | ``                                                   |
| DataRow                 | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataRow, Func<IDataEquivalencyAssertionOptions<DataRow>, IDataEquivalencyAssertionOptions<DataRow>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataRow)`                  | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(TDataRow)`                       | ``                                                   |
|                         | `.Should().HaveColumn(string)`                       | ``                                                   |
|                         | `.Should().HaveColumns(IEnumerable<string>)`         | ``                                                   |
|                         | `.Should().HaveColumns(string[])`                    | ``                                                   |
|                         | `.Should().Match(Expression<Func<TDataRow, bool>>)`  | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(TDataRow)`                    | ``                                                   |
| DataSet                 | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataSet, Func<IDataEquivalencyAssertionOptions<DataSet>, IDataEquivalencyAssertionOptions<DataSet>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataSet)`                  | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(DataSet)`                        | ``                                                   |
|                         | `.Should().HaveTable(string)`                        | ``                                                   |
|                         | `.Should().HaveTableCount(int)`                      | ``                                                   |
|                         | `.Should().HaveTables(IEnumerable<string>)`          | ``                                                   |
|                         | `.Should().HaveTables(string[])`                     | ``                                                   |
|                         | `.Should().Match(Expression<Func<DataSet, bool>>)`   | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(DataSet)`                     | ``                                                   |
| DataTable               | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataTable, Func<IDataEquivalencyAssertionOptions<DataTable>, IDataEquivalencyAssertionOptions<DataTable>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo(DataTable)`                | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(DataTable)`                      | ``                                                   |
|                         | `.Should().HaveColumn(string)`                       | ``                                                   |
|                         | `.Should().HaveColumns(IEnumerable<string>)`         | ``                                                   |
|                         | `.Should().HaveColumns(string[])`                    | ``                                                   |
|                         | `.Should().HaveRowCount(int)`                        | ``                                                   |
|                         | `.Should().Match(Expression<Func<DataTable, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(DataTable)`                   | ``                                                   |
| DateOnly                | `.Should().Be(DateOnly)`                             | ``                                                   |
|                         | `.Should().Be(Nullable<DateOnly>)`                   | ``                                                   |
|                         | `.Should().BeAfter(DateOnly)`                        | ``                                                   |
|                         | `.Should().BeBefore(DateOnly)`                       | ``                                                   |
|                         | `.Should().BeOneOf(DateOnly[])`                      | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<DateOnly>)`           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateOnly>>)` | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<DateOnly>[])`            | ``                                                   |
|                         | `.Should().BeOnOrAfter(DateOnly)`                    | ``                                                   |
|                         | `.Should().BeOnOrBefore(DateOnly)`                   | ``                                                   |
|                         | `.Should().HaveDay(int)`                             | ``                                                   |
|                         | `.Should().HaveMonth(int)`                           | ``                                                   |
|                         | `.Should().HaveYear(int)`                            | ``                                                   |
|                         | `.Should().NotBe(DateOnly)`                          | ``                                                   |
|                         | `.Should().NotBe(Nullable<DateOnly>)`                | ``                                                   |
|                         | `.Should().NotBeAfter(DateOnly)`                     | ``                                                   |
|                         | `.Should().NotBeBefore(DateOnly)`                    | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(DateOnly)`                 | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(DateOnly)`                | ``                                                   |
|                         | `.Should().NotHaveDay(int)`                          | ``                                                   |
|                         | `.Should().NotHaveMonth(int)`                        | ``                                                   |
|                         | `.Should().NotHaveYear(int)`                         | ``                                                   |
| DateTime                | `.Should().Be(DateTime)`                             | ``                                                   |
|                         | `.Should().Be(Nullable<DateTime>)`                   | ``                                                   |
|                         | `.Should().BeAfter(DateTime)`                        | ``                                                   |
|                         | `.Should().BeAtLeast(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeBefore(DateTime)`                       | ``                                                   |
|                         | `.Should().BeCloseTo(DateTime, TimeSpan)`            | ``                                                   |
|                         | `.Should().BeExactly(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeIn(DateTimeKind)`                       | ``                                                   |
|                         | `.Should().BeLessThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeMoreThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeOneOf(DateTime[])`                      | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<DateTime>)`           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTime>>)` | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<DateTime>[])`            | ``                                                   |
|                         | `.Should().BeOnOrAfter(DateTime)`                    | ``                                                   |
|                         | `.Should().BeOnOrBefore(DateTime)`                   | ``                                                   |
|                         | `.Should().BeSameDateAs(DateTime)`                   | ``                                                   |
|                         | `.Should().BeWithin(TimeSpan)`                       | ``                                                   |
|                         | `.Should().HaveDay(int)`                             | ``                                                   |
|                         | `.Should().HaveHour(int)`                            | ``                                                   |
|                         | `.Should().HaveMinute(int)`                          | ``                                                   |
|                         | `.Should().HaveMonth(int)`                           | ``                                                   |
|                         | `.Should().HaveSecond(int)`                          | ``                                                   |
|                         | `.Should().HaveYear(int)`                            | ``                                                   |
|                         | `.Should().NotBe(DateTime)`                          | ``                                                   |
|                         | `.Should().NotBe(Nullable<DateTime>)`                | ``                                                   |
|                         | `.Should().NotBeAfter(DateTime)`                     | ``                                                   |
|                         | `.Should().NotBeBefore(DateTime)`                    | ``                                                   |
|                         | `.Should().NotBeCloseTo(DateTime, TimeSpan)`         | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(DateTime)`                 | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(DateTime)`                | ``                                                   |
|                         | `.Should().NotBeSameDateAs(DateTime)`                | ``                                                   |
|                         | `.Should().NotHaveDay(int)`                          | ``                                                   |
|                         | `.Should().NotHaveHour(int)`                         | ``                                                   |
|                         | `.Should().NotHaveMinute(int)`                       | ``                                                   |
|                         | `.Should().NotHaveMonth(int)`                        | ``                                                   |
|                         | `.Should().NotHaveSecond(int)`                       | ``                                                   |
|                         | `.Should().NotHaveYear(int)`                         | ``                                                   |
| DateTimeOffset          | `.Should().Be(DateTimeOffset)`                       | ``                                                   |
|                         | `.Should().Be(Nullable<DateTimeOffset>)`             | ``                                                   |
|                         | `.Should().BeAfter(DateTimeOffset)`                  | ``                                                   |
|                         | `.Should().BeAtLeast(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeBefore(DateTimeOffset)`                 | ``                                                   |
|                         | `.Should().BeCloseTo(DateTimeOffset, TimeSpan)`      | ``                                                   |
|                         | `.Should().BeExactly(DateTimeOffset)`                | ``                                                   |
|                         | `.Should().BeExactly(Nullable<DateTimeOffset>)`      | ``                                                   |
|                         | `.Should().BeExactly(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeLessThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeMoreThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeOneOf(DateTimeOffset[])`                | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<DateTimeOffset>)`     | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTimeOffset>>)` | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<DateTimeOffset>[])`      | ``                                                   |
|                         | `.Should().BeOnOrAfter(DateTimeOffset)`              | ``                                                   |
|                         | `.Should().BeOnOrBefore(DateTimeOffset)`             | ``                                                   |
|                         | `.Should().BeSameDateAs(DateTimeOffset)`             | ``                                                   |
|                         | `.Should().BeWithin(TimeSpan)`                       | ``                                                   |
|                         | `.Should().HaveDay(int)`                             | ``                                                   |
|                         | `.Should().HaveHour(int)`                            | ``                                                   |
|                         | `.Should().HaveMinute(int)`                          | ``                                                   |
|                         | `.Should().HaveMonth(int)`                           | ``                                                   |
|                         | `.Should().HaveOffset(TimeSpan)`                     | ``                                                   |
|                         | `.Should().HaveSecond(int)`                          | ``                                                   |
|                         | `.Should().HaveYear(int)`                            | ``                                                   |
|                         | `.Should().NotBe(DateTimeOffset)`                    | ``                                                   |
|                         | `.Should().NotBe(Nullable<DateTimeOffset>)`          | ``                                                   |
|                         | `.Should().NotBeAfter(DateTimeOffset)`               | ``                                                   |
|                         | `.Should().NotBeBefore(DateTimeOffset)`              | ``                                                   |
|                         | `.Should().NotBeCloseTo(DateTimeOffset, TimeSpan)`   | ``                                                   |
|                         | `.Should().NotBeExactly(DateTimeOffset)`             | ``                                                   |
|                         | `.Should().NotBeExactly(Nullable<DateTimeOffset>)`   | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(DateTimeOffset)`           | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(DateTimeOffset)`          | ``                                                   |
|                         | `.Should().NotBeSameDateAs(DateTimeOffset)`          | ``                                                   |
|                         | `.Should().NotHaveDay(int)`                          | ``                                                   |
|                         | `.Should().NotHaveHour(int)`                         | ``                                                   |
|                         | `.Should().NotHaveMinute(int)`                       | ``                                                   |
|                         | `.Should().NotHaveMonth(int)`                        | ``                                                   |
|                         | `.Should().NotHaveOffset(TimeSpan)`                  | ``                                                   |
|                         | `.Should().NotHaveSecond(int)`                       | ``                                                   |
|                         | `.Should().NotHaveYear(int)`                         | ``                                                   |
| DateTimeOffsetRange     | `.Should().After(DateTimeOffset)`                    | ``                                                   |
|                         | `.Should().Before(DateTimeOffset)`                   | ``                                                   |
| DateTimeRange           | `.Should().After(DateTime)`                          | ``                                                   |
|                         | `.Should().Before(DateTime)`                         | ``                                                   |
| Decimal                 | `.Should().Be(decimal?)`                             | ``                                                   |
|                         | `.Should().Be(decimal)`                              | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(decimal)`              | ``                                                   |
|                         | `.Should().BeGreaterThan(decimal)`                   | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(decimal)`          | ``                                                   |
|                         | `.Should().BeInRange(decimal, decimal)`              | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(decimal)`                 | ``                                                   |
|                         | `.Should().BeLessThan(decimal)`                      | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(decimal)`             | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(decimal[])`                       | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<decimal>)`            | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<decimal, bool>>)`   | ``                                                   |
|                         | `.Should().NotBe(decimal?)`                          | ``                                                   |
|                         | `.Should().NotBe(decimal)`                           | ``                                                   |
|                         | `.Should().NotBeInRange(decimal, decimal)`           | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| Double                  | `.Should().Be(double?)`                              | ``                                                   |
|                         | `.Should().Be(double)`                               | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(double)`               | ``                                                   |
|                         | `.Should().BeGreaterThan(double)`                    | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(double)`           | ``                                                   |
|                         | `.Should().BeInRange(double, double)`                | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(double)`                  | ``                                                   |
|                         | `.Should().BeLessThan(double)`                       | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(double)`              | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(double[])`                        | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<double>)`             | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<double, bool>>)`    | ``                                                   |
|                         | `.Should().NotBe(double?)`                           | ``                                                   |
|                         | `.Should().NotBe(double)`                            | ``                                                   |
|                         | `.Should().NotBeInRange(double, double)`             | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| Enum                    | `.Should().Be(Nullable<TEnum>)`                      | ``                                                   |
|                         | `.Should().Be(TEnum)`                                | ``                                                   |
|                         | `.Should().BeDefined()`                              | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<TEnum>)`              | ``                                                   |
|                         | `.Should().BeOneOf(TEnum[])`                         | ``                                                   |
|                         | `.Should().HaveFlag(TEnum)`                          | ``                                                   |
|                         | `.Should().HaveSameNameAs<T>(T)`                     | ``                                                   |
|                         | `.Should().HaveSameValueAs<T>(T)`                    | ``                                                   |
|                         | `.Should().HaveValue(decimal)`                       | ``                                                   |
|                         | `.Should().Match(Expression<Func<Nullable<TEnum>, bool>>)` | ``                                                   |
|                         | `.Should().NotBe(Nullable<TEnum>)`                   | ``                                                   |
|                         | `.Should().NotBe(TEnum)`                             | ``                                                   |
|                         | `.Should().NotBeDefined()`                           | ``                                                   |
|                         | `.Should().NotHaveFlag(TEnum)`                       | ``                                                   |
|                         | `.Should().NotHaveSameNameAs<T>(T)`                  | ``                                                   |
|                         | `.Should().NotHaveSameValueAs<T>(T)`                 | ``                                                   |
|                         | `.Should().NotHaveValue(decimal)`                    | ``                                                   |
| Event                   | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(T)`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(T)`                           | ``                                                   |
|                         | `.Should().NotRaise(string)`                         | ``                                                   |
|                         | `.Should().NotRaisePropertyChangeFor(Expression<Func<T, object>>)` | ``                                                   |
|                         | `.Should().Raise(string)`                            | ``                                                   |
|                         | `.Should().RaisePropertyChangeFor(Expression<Func<T, object>>)` | ``                                                   |
| Exception               | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(IEnumerable<TException>)`        | ``                                                   |
|                         | `.Should().Match(Expression<Func<IEnumerable<TException>, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(IEnumerable<TException>)`     | ``                                                   |
|                         | `.Should().Where(Expression<Func<TException, bool>>)` | ``                                                   |
|                         | `.Should().WithInnerException(Type)`                 | ``                                                   |
|                         | `.Should().WithInnerException<TInnerException>()`    | ``                                                   |
|                         | `.Should().WithInnerExceptionExactly(Type)`          | ``                                                   |
|                         | `.Should().WithInnerExceptionExactly<TInnerException>()` | ``                                                   |
|                         | `.Should().WithMessage(string)`                      | ``                                                   |
| ExecutionTime           | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             | ``                                                   |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                | ``                                                   |
|                         | `.Should().BeLessThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(TimeSpan)`            | ``                                                   |
| Function                | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(Func<T>)`                        | ``                                                   |
|                         | `.Should().Match(Expression<Func<Func<T>, bool>>)`   | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(Func<T>)`                     | ``                                                   |
|                         | `.Should().NotThrow()`                               | ``                                                   |
|                         | `.Should().NotThrow<TException>()`                   | ``                                                   |
|                         | `.Should().NotThrowAfter(TimeSpan, TimeSpan)`        | ``                                                   |
|                         | `.Should().Throw<TException>()`                      | ``                                                   |
|                         | `.Should().ThrowExactly<TException>()`               | ``                                                   |
| GenericAsyncFunction    | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(Func<Task<TResult>>)`            | ``                                                   |
|                         | `.Should().CompleteWithinAsync(TimeSpan)`            | ``                                                   |
|                         | `.Should().Match(Expression<Func<Func<Task<TResult>>, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(Func<Task<TResult>>)`         | ``                                                   |
|                         | `.Should().NotCompleteWithinAsync(TimeSpan)`         | ``                                                   |
|                         | `.Should().NotThrowAfterAsync(TimeSpan, TimeSpan)`   | ``                                                   |
|                         | `.Should().NotThrowAsync()`                          | ``                                                   |
|                         | `.Should().NotThrowAsync<TException>()`              | ``                                                   |
|                         | `.Should().ThrowAsync<TException>()`                 | ``                                                   |
|                         | `.Should().ThrowExactlyAsync<TException>()`          | ``                                                   |
|                         | `.Should().ThrowWithinAsync<TException>(TimeSpan)`   | ``                                                   |
| GenericCollection       | `.Should().AllBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().AllBeAssignableTo<TExpectation>()`        | ``                                                   |
|                         | `.Should().AllBeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().AllBeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().AllBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().AllBeOfType<TExpectation>()`              | ``                                                   |
|                         | `.Should().AllSatisfy(Action<T>)`                    | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEmpty()`                                | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().BeInAscendingOrder()`                     | ``                                                   |
|                         | `.Should().BeInAscendingOrder(Func<T, T, int>)`      | ``                                                   |
|                         | `.Should().BeInAscendingOrder(IComparer<T>)`         | ``                                                   |
|                         | `.Should().BeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().BeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().BeInDescendingOrder()`                    | ``                                                   |
|                         | `.Should().BeInDescendingOrder(Func<T, T, int>)`     | ``                                                   |
|                         | `.Should().BeInDescendingOrder(IComparer<T>)`        | ``                                                   |
|                         | `.Should().BeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().BeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeNullOrEmpty()`                          | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(IEnumerable<T>)`                 | ``                                                   |
|                         | `.Should().BeSubsetOf(IEnumerable<T>)`               | ``                                                   |
|                         | `.Should().Contain(Expression<Func<T, bool>>)`       | ``                                                   |
|                         | `.Should().Contain(IEnumerable<T>)`                  | ``                                                   |
|                         | `.Should().Contain(T)`                               | ``                                                   |
|                         | `.Should().ContainEquivalentOf<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().ContainEquivalentOf<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().ContainInConsecutiveOrder(IEnumerable<T>)` | ``                                                   |
|                         | `.Should().ContainInConsecutiveOrder(T[])`           | ``                                                   |
|                         | `.Should().ContainInOrder(IEnumerable<T>)`           | ``                                                   |
|                         | `.Should().ContainInOrder(T[])`                      | ``                                                   |
|                         | `.Should().ContainItemsAssignableTo<TExpectation>()` | ``                                                   |
|                         | `.Should().ContainSingle()`                          | ``                                                   |
|                         | `.Should().ContainSingle(Expression<Func<T, bool>>)` | ``                                                   |
|                         | `.Should().EndWith(IEnumerable<T>)`                  | ``                                                   |
|                         | `.Should().EndWith(T)`                               | ``                                                   |
|                         | `.Should().EndWith<TExpectation>(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` | ``                                                   |
|                         | `.Should().Equal(IEnumerable<T>)`                    | ``                                                   |
|                         | `.Should().Equal(T[])`                               | ``                                                   |
|                         | `.Should().Equal<TExpectation>(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` | ``                                                   |
|                         | `.Should().HaveCount(Expression<Func<int, bool>>)`   | ``                                                   |
|                         | `.Should().HaveCount(int)`                           | ``                                                   |
|                         | `.Should().HaveCountGreaterOrEqualTo(int)`           | ``                                                   |
|                         | `.Should().HaveCountGreaterThan(int)`                | ``                                                   |
|                         | `.Should().HaveCountGreaterThanOrEqualTo(int)`       | ``                                                   |
|                         | `.Should().HaveCountLessOrEqualTo(int)`              | ``                                                   |
|                         | `.Should().HaveCountLessThan(int)`                   | ``                                                   |
|                         | `.Should().HaveCountLessThanOrEqualTo(int)`          | ``                                                   |
|                         | `.Should().HaveElementAt(int, T)`                    | ``                                                   |
|                         | `.Should().HaveElementPreceding(T, T)`               | ``                                                   |
|                         | `.Should().HaveElementSucceeding(T, T)`              | ``                                                   |
|                         | `.Should().HaveSameCount<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().IntersectWith(IEnumerable<T>)`            | ``                                                   |
|                         | `.Should().Match(Expression<Func<IEnumerable<T>, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEmpty()`                             | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder()`                  | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder(Func<T, T, int>)`   | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder(IComparer<T>)`      | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder()`                 | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder(Func<T, T, int>)`  | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder(IComparer<T>)`     | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeNullOrEmpty()`                       | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(IEnumerable<T>)`              | ``                                                   |
|                         | `.Should().NotBeSubsetOf(IEnumerable<T>)`            | ``                                                   |
|                         | `.Should().NotContain(Expression<Func<T, bool>>)`    | ``                                                   |
|                         | `.Should().NotContain(IEnumerable<T>)`               | ``                                                   |
|                         | `.Should().NotContain(T)`                            | ``                                                   |
|                         | `.Should().NotContainEquivalentOf<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotContainEquivalentOf<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().NotContainInConsecutiveOrder(IEnumerable<T>)` | ``                                                   |
|                         | `.Should().NotContainInConsecutiveOrder(T[])`        | ``                                                   |
|                         | `.Should().NotContainInOrder(IEnumerable<T>)`        | ``                                                   |
|                         | `.Should().NotContainInOrder(T[])`                   | ``                                                   |
|                         | `.Should().NotContainItemsAssignableTo(Type)`        | ``                                                   |
|                         | `.Should().NotContainItemsAssignableTo<TExpectation>()` | ``                                                   |
|                         | `.Should().NotContainNulls()`                        | ``                                                   |
|                         | `.Should().NotContainNulls<TKey>(Expression<Func<T, TKey>>)` | ``                                                   |
|                         | `.Should().NotEqual(IEnumerable<T>)`                 | ``                                                   |
|                         | `.Should().NotHaveCount(int)`                        | ``                                                   |
|                         | `.Should().NotHaveSameCount<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().NotIntersectWith(IEnumerable<T>)`         | ``                                                   |
|                         | `.Should().OnlyContain(Expression<Func<T, bool>>)`   | ``                                                   |
|                         | `.Should().OnlyHaveUniqueItems()`                    | ``                                                   |
|                         | `.Should().OnlyHaveUniqueItems<TKey>(Expression<Func<T, TKey>>)` | ``                                                   |
|                         | `.Should().Satisfy(Expression<Func<T, bool>>[])`     | ``                                                   |
|                         | `.Should().Satisfy(IEnumerable<Expression<Func<T, bool>>>)` | ``                                                   |
|                         | `.Should().SatisfyRespectively(Action<T>[])`         | ``                                                   |
|                         | `.Should().SatisfyRespectively(IEnumerable<Action<T>>)` | ``                                                   |
|                         | `.Should().StartWith(IEnumerable<T>)`                | ``                                                   |
|                         | `.Should().StartWith(T)`                             | ``                                                   |
|                         | `.Should().StartWith<TExpectation>(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` | ``                                                   |
| Guid                    | `.Should().Be(Guid)`                                 | ``                                                   |
|                         | `.Should().Be(string)`                               | ``                                                   |
|                         | `.Should().BeEmpty()`                                | ``                                                   |
|                         | `.Should().NotBe(Guid)`                              | ``                                                   |
|                         | `.Should().NotBe(string)`                            | ``                                                   |
|                         | `.Should().NotBeEmpty()`                             | ``                                                   |
| HttpResponseMessage     | `.Should().Be(HttpResponseMessage, IEqualityComparer<HttpResponseMessage>)` | ``                                                   |
|                         | `.Should().Be(HttpResponseMessage)`                  | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeOneOf(HttpResponseMessage[])`           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<HttpResponseMessage>, IEqualityComparer<HttpResponseMessage>)` | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<HttpResponseMessage>)` | ``                                                   |
|                         | `.Should().BeRedirection()`                          | ``                                                   |
|                         | `.Should().BeSameAs(HttpResponseMessage)`            | ``                                                   |
|                         | `.Should().BeSuccessful()`                           | ``                                                   |
|                         | `.Should().HaveClientError()`                        | ``                                                   |
|                         | `.Should().HaveError()`                              | ``                                                   |
|                         | `.Should().HaveServerError()`                        | ``                                                   |
|                         | `.Should().HaveStatusCode(HttpStatusCode)`           | ``                                                   |
|                         | `.Should().Match(Expression<Func<HttpResponseMessage, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(HttpResponseMessage, IEqualityComparer<HttpResponseMessage>)` | ``                                                   |
|                         | `.Should().NotBe(HttpResponseMessage)`               | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(HttpResponseMessage)`         | ``                                                   |
|                         | `.Should().NotHaveStatusCode(HttpStatusCode)`        | ``                                                   |
| Int16                   | `.Should().Be(short?)`                               | ``                                                   |
|                         | `.Should().Be(short)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(short)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(short)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(short)`            | ``                                                   |
|                         | `.Should().BeInRange(short, short)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(short)`                   | ``                                                   |
|                         | `.Should().BeLessThan(short)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(short)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<short>)`              | ``                                                   |
|                         | `.Should().BeOneOf(short[])`                         | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<short, bool>>)`     | ``                                                   |
|                         | `.Should().NotBe(short?)`                            | ``                                                   |
|                         | `.Should().NotBe(short)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(short, short)`               | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| Int32                   | `.Should().Be(int?)`                                 | ``                                                   |
|                         | `.Should().Be(int)`                                  | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(int)`                  | ``                                                   |
|                         | `.Should().BeGreaterThan(int)`                       | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(int)`              | ``                                                   |
|                         | `.Should().BeInRange(int, int)`                      | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(int)`                     | ``                                                   |
|                         | `.Should().BeLessThan(int)`                          | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(int)`                 | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<int>)`                | ``                                                   |
|                         | `.Should().BeOneOf(int[])`                           | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<int, bool>>)`       | ``                                                   |
|                         | `.Should().NotBe(int?)`                              | ``                                                   |
|                         | `.Should().NotBe(int)`                               | ``                                                   |
|                         | `.Should().NotBeInRange(int, int)`                   | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| Int64                   | `.Should().Be(long?)`                                | ``                                                   |
|                         | `.Should().Be(long)`                                 | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(long)`                 | ``                                                   |
|                         | `.Should().BeGreaterThan(long)`                      | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(long)`             | ``                                                   |
|                         | `.Should().BeInRange(long, long)`                    | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(long)`                    | ``                                                   |
|                         | `.Should().BeLessThan(long)`                         | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(long)`                | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<long>)`               | ``                                                   |
|                         | `.Should().BeOneOf(long[])`                          | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<long, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(long?)`                             | ``                                                   |
|                         | `.Should().NotBe(long)`                              | ``                                                   |
|                         | `.Should().NotBeInRange(long, long)`                 | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| MethodInfo              | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeAsync()`                                | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>()`            | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(MethodInfo)`                     | ``                                                   |
|                         | `.Should().BeVirtual()`                              | ``                                                   |
|                         | `.Should().HaveAccessModifier(CSharpAccessModifier)` | ``                                                   |
|                         | `.Should().Match(Expression<Func<MethodInfo, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeAsync()`                             | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>()`         | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(MethodInfo)`                  | ``                                                   |
|                         | `.Should().NotBeVirtual()`                           | ``                                                   |
|                         | `.Should().NotHaveAccessModifier(CSharpAccessModifier)` | ``                                                   |
|                         | `.Should().NotReturn(Type)`                          | ``                                                   |
|                         | `.Should().NotReturn<TReturn>()`                     | ``                                                   |
|                         | `.Should().NotReturnVoid()`                          | ``                                                   |
|                         | `.Should().Return(Type)`                             | ``                                                   |
|                         | `.Should().Return<TReturn>()`                        | ``                                                   |
|                         | `.Should().ReturnVoid()`                             | ``                                                   |
| MethodInfoSelector      | `.Should().Be(CSharpAccessModifier)`                 | ``                                                   |
|                         | `.Should().BeAsync()`                                | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>()`            | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeVirtual()`                              | ``                                                   |
|                         | `.Should().NotBe(CSharpAccessModifier)`              | ``                                                   |
|                         | `.Should().NotBeAsync()`                             | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>()`         | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeVirtual()`                           | ``                                                   |
| NonGenericAsyncFunction | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(Func<Task>)`                     | ``                                                   |
|                         | `.Should().CompleteWithinAsync(TimeSpan)`            | ``                                                   |
|                         | `.Should().Match(Expression<Func<Func<Task>, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(Func<Task>)`                  | ``                                                   |
|                         | `.Should().NotCompleteWithinAsync(TimeSpan)`         | ``                                                   |
|                         | `.Should().NotThrowAfterAsync(TimeSpan, TimeSpan)`   | ``                                                   |
|                         | `.Should().NotThrowAsync()`                          | ``                                                   |
|                         | `.Should().NotThrowAsync<TException>()`              | ``                                                   |
|                         | `.Should().ThrowAsync<TException>()`                 | ``                                                   |
|                         | `.Should().ThrowExactlyAsync<TException>()`          | ``                                                   |
|                         | `.Should().ThrowWithinAsync<TException>(TimeSpan)`   | ``                                                   |
| NullableBoolean         | `.Should().Be(bool?)`                                | ``                                                   |
|                         | `.Should().Be(bool)`                                 | ``                                                   |
|                         | `.Should().BeFalse()`                                | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeTrue()`                                 | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Imply(bool)`                              | ``                                                   |
|                         | `.Should().NotBe(bool?)`                             | ``                                                   |
|                         | `.Should().NotBe(bool)`                              | ``                                                   |
|                         | `.Should().NotBeFalse()`                             | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeTrue()`                              | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableByte            | `.Should().Be(byte?)`                                | ``                                                   |
|                         | `.Should().Be(byte)`                                 | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(byte)`                 | ``                                                   |
|                         | `.Should().BeGreaterThan(byte)`                      | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(byte)`             | ``                                                   |
|                         | `.Should().BeInRange(byte, byte)`                    | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(byte)`                    | ``                                                   |
|                         | `.Should().BeLessThan(byte)`                         | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(byte)`                | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(byte[])`                          | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<byte>)`               | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<byte, bool>>)`      | ``                                                   |
|                         | `.Should().Match(Expression<Func<byte?, bool>>)`     | ``                                                   |
|                         | `.Should().NotBe(byte?)`                             | ``                                                   |
|                         | `.Should().NotBe(byte)`                              | ``                                                   |
|                         | `.Should().NotBeInRange(byte, byte)`                 | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableDateOnly        | `.Should().Be(DateOnly)`                             | ``                                                   |
|                         | `.Should().Be(Nullable<DateOnly>)`                   | ``                                                   |
|                         | `.Should().BeAfter(DateOnly)`                        | ``                                                   |
|                         | `.Should().BeBefore(DateOnly)`                       | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOneOf(DateOnly[])`                      | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<DateOnly>)`           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateOnly>>)` | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<DateOnly>[])`            | ``                                                   |
|                         | `.Should().BeOnOrAfter(DateOnly)`                    | ``                                                   |
|                         | `.Should().BeOnOrBefore(DateOnly)`                   | ``                                                   |
|                         | `.Should().HaveDay(int)`                             | ``                                                   |
|                         | `.Should().HaveMonth(int)`                           | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().HaveYear(int)`                            | ``                                                   |
|                         | `.Should().NotBe(DateOnly)`                          | ``                                                   |
|                         | `.Should().NotBe(Nullable<DateOnly>)`                | ``                                                   |
|                         | `.Should().NotBeAfter(DateOnly)`                     | ``                                                   |
|                         | `.Should().NotBeBefore(DateOnly)`                    | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(DateOnly)`                 | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(DateOnly)`                | ``                                                   |
|                         | `.Should().NotHaveDay(int)`                          | ``                                                   |
|                         | `.Should().NotHaveMonth(int)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
|                         | `.Should().NotHaveYear(int)`                         | ``                                                   |
| NullableDateTime        | `.Should().Be(DateTime)`                             | ``                                                   |
|                         | `.Should().Be(Nullable<DateTime>)`                   | ``                                                   |
|                         | `.Should().BeAfter(DateTime)`                        | ``                                                   |
|                         | `.Should().BeAtLeast(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeBefore(DateTime)`                       | ``                                                   |
|                         | `.Should().BeCloseTo(DateTime, TimeSpan)`            | ``                                                   |
|                         | `.Should().BeExactly(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeIn(DateTimeKind)`                       | ``                                                   |
|                         | `.Should().BeLessThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeMoreThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOneOf(DateTime[])`                      | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<DateTime>)`           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTime>>)` | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<DateTime>[])`            | ``                                                   |
|                         | `.Should().BeOnOrAfter(DateTime)`                    | ``                                                   |
|                         | `.Should().BeOnOrBefore(DateTime)`                   | ``                                                   |
|                         | `.Should().BeSameDateAs(DateTime)`                   | ``                                                   |
|                         | `.Should().BeWithin(TimeSpan)`                       | ``                                                   |
|                         | `.Should().HaveDay(int)`                             | ``                                                   |
|                         | `.Should().HaveHour(int)`                            | ``                                                   |
|                         | `.Should().HaveMinute(int)`                          | ``                                                   |
|                         | `.Should().HaveMonth(int)`                           | ``                                                   |
|                         | `.Should().HaveSecond(int)`                          | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().HaveYear(int)`                            | ``                                                   |
|                         | `.Should().NotBe(DateTime)`                          | ``                                                   |
|                         | `.Should().NotBe(Nullable<DateTime>)`                | ``                                                   |
|                         | `.Should().NotBeAfter(DateTime)`                     | ``                                                   |
|                         | `.Should().NotBeBefore(DateTime)`                    | ``                                                   |
|                         | `.Should().NotBeCloseTo(DateTime, TimeSpan)`         | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(DateTime)`                 | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(DateTime)`                | ``                                                   |
|                         | `.Should().NotBeSameDateAs(DateTime)`                | ``                                                   |
|                         | `.Should().NotHaveDay(int)`                          | ``                                                   |
|                         | `.Should().NotHaveHour(int)`                         | ``                                                   |
|                         | `.Should().NotHaveMinute(int)`                       | ``                                                   |
|                         | `.Should().NotHaveMonth(int)`                        | ``                                                   |
|                         | `.Should().NotHaveSecond(int)`                       | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
|                         | `.Should().NotHaveYear(int)`                         | ``                                                   |
| NullableDateTimeOffset  | `.Should().Be(DateTimeOffset)`                       | ``                                                   |
|                         | `.Should().Be(Nullable<DateTimeOffset>)`             | ``                                                   |
|                         | `.Should().BeAfter(DateTimeOffset)`                  | ``                                                   |
|                         | `.Should().BeAtLeast(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeBefore(DateTimeOffset)`                 | ``                                                   |
|                         | `.Should().BeCloseTo(DateTimeOffset, TimeSpan)`      | ``                                                   |
|                         | `.Should().BeExactly(DateTimeOffset)`                | ``                                                   |
|                         | `.Should().BeExactly(Nullable<DateTimeOffset>)`      | ``                                                   |
|                         | `.Should().BeExactly(TimeSpan)`                      | ``                                                   |
|                         | `.Should().BeLessThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeMoreThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOneOf(DateTimeOffset[])`                | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<DateTimeOffset>)`     | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTimeOffset>>)` | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<DateTimeOffset>[])`      | ``                                                   |
|                         | `.Should().BeOnOrAfter(DateTimeOffset)`              | ``                                                   |
|                         | `.Should().BeOnOrBefore(DateTimeOffset)`             | ``                                                   |
|                         | `.Should().BeSameDateAs(DateTimeOffset)`             | ``                                                   |
|                         | `.Should().BeWithin(TimeSpan)`                       | ``                                                   |
|                         | `.Should().HaveDay(int)`                             | ``                                                   |
|                         | `.Should().HaveHour(int)`                            | ``                                                   |
|                         | `.Should().HaveMinute(int)`                          | ``                                                   |
|                         | `.Should().HaveMonth(int)`                           | ``                                                   |
|                         | `.Should().HaveOffset(TimeSpan)`                     | ``                                                   |
|                         | `.Should().HaveSecond(int)`                          | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().HaveYear(int)`                            | ``                                                   |
|                         | `.Should().NotBe(DateTimeOffset)`                    | ``                                                   |
|                         | `.Should().NotBe(Nullable<DateTimeOffset>)`          | ``                                                   |
|                         | `.Should().NotBeAfter(DateTimeOffset)`               | ``                                                   |
|                         | `.Should().NotBeBefore(DateTimeOffset)`              | ``                                                   |
|                         | `.Should().NotBeCloseTo(DateTimeOffset, TimeSpan)`   | ``                                                   |
|                         | `.Should().NotBeExactly(DateTimeOffset)`             | ``                                                   |
|                         | `.Should().NotBeExactly(Nullable<DateTimeOffset>)`   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(DateTimeOffset)`           | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(DateTimeOffset)`          | ``                                                   |
|                         | `.Should().NotBeSameDateAs(DateTimeOffset)`          | ``                                                   |
|                         | `.Should().NotHaveDay(int)`                          | ``                                                   |
|                         | `.Should().NotHaveHour(int)`                         | ``                                                   |
|                         | `.Should().NotHaveMinute(int)`                       | ``                                                   |
|                         | `.Should().NotHaveMonth(int)`                        | ``                                                   |
|                         | `.Should().NotHaveOffset(TimeSpan)`                  | ``                                                   |
|                         | `.Should().NotHaveSecond(int)`                       | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
|                         | `.Should().NotHaveYear(int)`                         | ``                                                   |
| NullableDecimal         | `.Should().Be(decimal?)`                             | ``                                                   |
|                         | `.Should().Be(decimal)`                              | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(decimal)`              | ``                                                   |
|                         | `.Should().BeGreaterThan(decimal)`                   | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(decimal)`          | ``                                                   |
|                         | `.Should().BeInRange(decimal, decimal)`              | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(decimal)`                 | ``                                                   |
|                         | `.Should().BeLessThan(decimal)`                      | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(decimal)`             | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(decimal[])`                       | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<decimal>)`            | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<decimal, bool>>)`   | ``                                                   |
|                         | `.Should().Match(Expression<Func<decimal?, bool>>)`  | ``                                                   |
|                         | `.Should().NotBe(decimal?)`                          | ``                                                   |
|                         | `.Should().NotBe(decimal)`                           | ``                                                   |
|                         | `.Should().NotBeInRange(decimal, decimal)`           | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableDouble          | `.Should().Be(double?)`                              | ``                                                   |
|                         | `.Should().Be(double)`                               | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(double)`               | ``                                                   |
|                         | `.Should().BeGreaterThan(double)`                    | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(double)`           | ``                                                   |
|                         | `.Should().BeInRange(double, double)`                | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(double)`                  | ``                                                   |
|                         | `.Should().BeLessThan(double)`                       | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(double)`              | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(double[])`                        | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<double>)`             | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<double, bool>>)`    | ``                                                   |
|                         | `.Should().Match(Expression<Func<double?, bool>>)`   | ``                                                   |
|                         | `.Should().NotBe(double?)`                           | ``                                                   |
|                         | `.Should().NotBe(double)`                            | ``                                                   |
|                         | `.Should().NotBeInRange(double, double)`             | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableEnum            | `.Should().Be(Nullable<TEnum>)`                      | ``                                                   |
|                         | `.Should().Be(TEnum)`                                | ``                                                   |
|                         | `.Should().BeDefined()`                              | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<TEnum>)`              | ``                                                   |
|                         | `.Should().BeOneOf(TEnum[])`                         | ``                                                   |
|                         | `.Should().HaveFlag(TEnum)`                          | ``                                                   |
|                         | `.Should().HaveSameNameAs<T>(T)`                     | ``                                                   |
|                         | `.Should().HaveSameValueAs<T>(T)`                    | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().HaveValue(decimal)`                       | ``                                                   |
|                         | `.Should().Match(Expression<Func<Nullable<TEnum>, bool>>)` | ``                                                   |
|                         | `.Should().NotBe(Nullable<TEnum>)`                   | ``                                                   |
|                         | `.Should().NotBe(TEnum)`                             | ``                                                   |
|                         | `.Should().NotBeDefined()`                           | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotHaveFlag(TEnum)`                       | ``                                                   |
|                         | `.Should().NotHaveSameNameAs<T>(T)`                  | ``                                                   |
|                         | `.Should().NotHaveSameValueAs<T>(T)`                 | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
|                         | `.Should().NotHaveValue(decimal)`                    | ``                                                   |
| NullableGuid            | `.Should().Be(Guid)`                                 | ``                                                   |
|                         | `.Should().Be(Nullable<Guid>)`                       | ``                                                   |
|                         | `.Should().Be(string)`                               | ``                                                   |
|                         | `.Should().BeEmpty()`                                | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().NotBe(Guid)`                              | ``                                                   |
|                         | `.Should().NotBe(string)`                            | ``                                                   |
|                         | `.Should().NotBeEmpty()`                             | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableInt16           | `.Should().Be(short?)`                               | ``                                                   |
|                         | `.Should().Be(short)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(short)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(short)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(short)`            | ``                                                   |
|                         | `.Should().BeInRange(short, short)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(short)`                   | ``                                                   |
|                         | `.Should().BeLessThan(short)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(short)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<short>)`              | ``                                                   |
|                         | `.Should().BeOneOf(short[])`                         | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<short, bool>>)`     | ``                                                   |
|                         | `.Should().Match(Expression<Func<short?, bool>>)`    | ``                                                   |
|                         | `.Should().NotBe(short?)`                            | ``                                                   |
|                         | `.Should().NotBe(short)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(short, short)`               | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableInt32           | `.Should().Be(int?)`                                 | ``                                                   |
|                         | `.Should().Be(int)`                                  | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(int)`                  | ``                                                   |
|                         | `.Should().BeGreaterThan(int)`                       | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(int)`              | ``                                                   |
|                         | `.Should().BeInRange(int, int)`                      | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(int)`                     | ``                                                   |
|                         | `.Should().BeLessThan(int)`                          | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(int)`                 | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<int>)`                | ``                                                   |
|                         | `.Should().BeOneOf(int[])`                           | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<int, bool>>)`       | ``                                                   |
|                         | `.Should().Match(Expression<Func<int?, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(int?)`                              | ``                                                   |
|                         | `.Should().NotBe(int)`                               | ``                                                   |
|                         | `.Should().NotBeInRange(int, int)`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableInt64           | `.Should().Be(long?)`                                | ``                                                   |
|                         | `.Should().Be(long)`                                 | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(long)`                 | ``                                                   |
|                         | `.Should().BeGreaterThan(long)`                      | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(long)`             | ``                                                   |
|                         | `.Should().BeInRange(long, long)`                    | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(long)`                    | ``                                                   |
|                         | `.Should().BeLessThan(long)`                         | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(long)`                | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<long>)`               | ``                                                   |
|                         | `.Should().BeOneOf(long[])`                          | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<long, bool>>)`      | ``                                                   |
|                         | `.Should().Match(Expression<Func<long?, bool>>)`     | ``                                                   |
|                         | `.Should().NotBe(long?)`                             | ``                                                   |
|                         | `.Should().NotBe(long)`                              | ``                                                   |
|                         | `.Should().NotBeInRange(long, long)`                 | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableNumeric         | `.Should().Be(Nullable<T>)`                          | ``                                                   |
|                         | `.Should().Be(T)`                                    | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(T)`                    | ``                                                   |
|                         | `.Should().BeGreaterThan(T)`                         | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(T)`                | ``                                                   |
|                         | `.Should().BeInRange(T, T)`                          | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(T)`                       | ``                                                   |
|                         | `.Should().BeLessThan(T)`                            | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(T)`                   | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<T>)`                  | ``                                                   |
|                         | `.Should().BeOneOf(T[])`                             | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<Nullable<T>, bool>>)` | ``                                                   |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         | ``                                                   |
|                         | `.Should().NotBe(Nullable<T>)`                       | ``                                                   |
|                         | `.Should().NotBe(T)`                                 | ``                                                   |
|                         | `.Should().NotBeInRange(T, T)`                       | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableSByte           | `.Should().Be(sbyte?)`                               | ``                                                   |
|                         | `.Should().Be(sbyte)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(sbyte)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(sbyte)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(sbyte)`            | ``                                                   |
|                         | `.Should().BeInRange(sbyte, sbyte)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(sbyte)`                   | ``                                                   |
|                         | `.Should().BeLessThan(sbyte)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(sbyte)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<sbyte>)`              | ``                                                   |
|                         | `.Should().BeOneOf(sbyte[])`                         | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<sbyte, bool>>)`     | ``                                                   |
|                         | `.Should().Match(Expression<Func<sbyte?, bool>>)`    | ``                                                   |
|                         | `.Should().NotBe(sbyte?)`                            | ``                                                   |
|                         | `.Should().NotBe(sbyte)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(sbyte, sbyte)`               | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableSimpleTimeSpan  | `.Should().Be(Nullable<TimeSpan>)`                   | ``                                                   |
|                         | `.Should().Be(TimeSpan)`                             | ``                                                   |
|                         | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             | ``                                                   |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                | ``                                                   |
|                         | `.Should().BeLessThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(TimeSpan)`            | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().NotBe(TimeSpan)`                          | ``                                                   |
|                         | `.Should().NotBeCloseTo(TimeSpan, TimeSpan)`         | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableSingle          | `.Should().Be(float?)`                               | ``                                                   |
|                         | `.Should().Be(float)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(float)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(float)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(float)`            | ``                                                   |
|                         | `.Should().BeInRange(float, float)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(float)`                   | ``                                                   |
|                         | `.Should().BeLessThan(float)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(float)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(float[])`                         | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<float>)`              | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<float, bool>>)`     | ``                                                   |
|                         | `.Should().Match(Expression<Func<float?, bool>>)`    | ``                                                   |
|                         | `.Should().NotBe(float?)`                            | ``                                                   |
|                         | `.Should().NotBe(float)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(float, float)`               | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableTimeOnly        | `.Should().Be(Nullable<TimeOnly>)`                   | ``                                                   |
|                         | `.Should().Be(TimeOnly)`                             | ``                                                   |
|                         | `.Should().BeAfter(TimeOnly)`                        | ``                                                   |
|                         | `.Should().BeBefore(TimeOnly)`                       | ``                                                   |
|                         | `.Should().BeCloseTo(TimeOnly, TimeSpan)`            | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<TimeOnly>>)` | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<TimeOnly>)`           | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<TimeOnly>[])`            | ``                                                   |
|                         | `.Should().BeOneOf(TimeOnly[])`                      | ``                                                   |
|                         | `.Should().BeOnOrAfter(TimeOnly)`                    | ``                                                   |
|                         | `.Should().BeOnOrBefore(TimeOnly)`                   | ``                                                   |
|                         | `.Should().HaveHours(int)`                           | ``                                                   |
|                         | `.Should().HaveMilliseconds(int)`                    | ``                                                   |
|                         | `.Should().HaveMinutes(int)`                         | ``                                                   |
|                         | `.Should().HaveSeconds(int)`                         | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().NotBe(Nullable<TimeOnly>)`                | ``                                                   |
|                         | `.Should().NotBe(TimeOnly)`                          | ``                                                   |
|                         | `.Should().NotBeAfter(TimeOnly)`                     | ``                                                   |
|                         | `.Should().NotBeBefore(TimeOnly)`                    | ``                                                   |
|                         | `.Should().NotBeCloseTo(TimeOnly, TimeSpan)`         | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(TimeOnly)`                 | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(TimeOnly)`                | ``                                                   |
|                         | `.Should().NotHaveHours(int)`                        | ``                                                   |
|                         | `.Should().NotHaveMilliseconds(int)`                 | ``                                                   |
|                         | `.Should().NotHaveMinutes(int)`                      | ``                                                   |
|                         | `.Should().NotHaveSeconds(int)`                      | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableUInt16          | `.Should().Be(ushort?)`                              | ``                                                   |
|                         | `.Should().Be(ushort)`                               | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(ushort)`               | ``                                                   |
|                         | `.Should().BeGreaterThan(ushort)`                    | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(ushort)`           | ``                                                   |
|                         | `.Should().BeInRange(ushort, ushort)`                | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(ushort)`                  | ``                                                   |
|                         | `.Should().BeLessThan(ushort)`                       | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(ushort)`              | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<ushort>)`             | ``                                                   |
|                         | `.Should().BeOneOf(ushort[])`                        | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<ushort, bool>>)`    | ``                                                   |
|                         | `.Should().Match(Expression<Func<ushort?, bool>>)`   | ``                                                   |
|                         | `.Should().NotBe(ushort?)`                           | ``                                                   |
|                         | `.Should().NotBe(ushort)`                            | ``                                                   |
|                         | `.Should().NotBeInRange(ushort, ushort)`             | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableUInt32          | `.Should().Be(uint?)`                                | ``                                                   |
|                         | `.Should().Be(uint)`                                 | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(uint)`                 | ``                                                   |
|                         | `.Should().BeGreaterThan(uint)`                      | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(uint)`             | ``                                                   |
|                         | `.Should().BeInRange(uint, uint)`                    | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(uint)`                    | ``                                                   |
|                         | `.Should().BeLessThan(uint)`                         | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(uint)`                | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<uint>)`               | ``                                                   |
|                         | `.Should().BeOneOf(uint[])`                          | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<uint, bool>>)`      | ``                                                   |
|                         | `.Should().Match(Expression<Func<uint?, bool>>)`     | ``                                                   |
|                         | `.Should().NotBe(uint?)`                             | ``                                                   |
|                         | `.Should().NotBe(uint)`                              | ``                                                   |
|                         | `.Should().NotBeInRange(uint, uint)`                 | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| NullableUInt64          | `.Should().Be(ulong?)`                               | ``                                                   |
|                         | `.Should().Be(ulong)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(ulong)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(ulong)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(ulong)`            | ``                                                   |
|                         | `.Should().BeInRange(ulong, ulong)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(ulong)`                   | ``                                                   |
|                         | `.Should().BeLessThan(ulong)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(ulong)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<ulong>)`              | ``                                                   |
|                         | `.Should().BeOneOf(ulong[])`                         | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().HaveValue()`                              | ``                                                   |
|                         | `.Should().Match(Expression<Func<ulong, bool>>)`     | ``                                                   |
|                         | `.Should().Match(Expression<Func<ulong?, bool>>)`    | ``                                                   |
|                         | `.Should().NotBe(ulong?)`                            | ``                                                   |
|                         | `.Should().NotBe(ulong)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(ulong, ulong)`               | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotHaveValue()`                           | ``                                                   |
| Numeric                 | `.Should().Be(Nullable<T>)`                          | ``                                                   |
|                         | `.Should().Be(T)`                                    | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(T)`                    | ``                                                   |
|                         | `.Should().BeGreaterThan(T)`                         | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(T)`                | ``                                                   |
|                         | `.Should().BeInRange(T, T)`                          | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(T)`                       | ``                                                   |
|                         | `.Should().BeLessThan(T)`                            | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(T)`                   | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<T>)`                  | ``                                                   |
|                         | `.Should().BeOneOf(T[])`                             | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         | ``                                                   |
|                         | `.Should().NotBe(Nullable<T>)`                       | ``                                                   |
|                         | `.Should().NotBe(T)`                                 | ``                                                   |
|                         | `.Should().NotBeInRange(T, T)`                       | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| Object                  | `.Should().Be(object, IEqualityComparer<object>)`    | ``                                                   |
|                         | `.Should().Be(object)`                               | ``                                                   |
|                         | `.Should().Be<TExpectation>(TExpectation, IEqualityComparer<TExpectation>)` | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<object>, IEqualityComparer<object>)` | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<object>)`             | ``                                                   |
|                         | `.Should().BeOneOf(object[])`                        | ``                                                   |
|                         | `.Should().BeOneOf<TExpectation>(IEnumerable<TExpectation>, IEqualityComparer<TExpectation>)` | ``                                                   |
|                         | `.Should().BeSameAs(object)`                         | ``                                                   |
|                         | `.Should().Match(Expression<Func<object, bool>>)`    | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(object, IEqualityComparer<object>)` | ``                                                   |
|                         | `.Should().NotBe(object)`                            | ``                                                   |
|                         | `.Should().NotBe<TExpectation>(TExpectation, IEqualityComparer<TExpectation>)` | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(object)`                      | ``                                                   |
| PropertyInfo            | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>()`            | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeReadable()`                             | ``                                                   |
|                         | `.Should().BeReadable(CSharpAccessModifier)`         | ``                                                   |
|                         | `.Should().BeSameAs(PropertyInfo)`                   | ``                                                   |
|                         | `.Should().BeVirtual()`                              | ``                                                   |
|                         | `.Should().BeWritable()`                             | ``                                                   |
|                         | `.Should().BeWritable(CSharpAccessModifier)`         | ``                                                   |
|                         | `.Should().Match(Expression<Func<PropertyInfo, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>()`         | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeReadable()`                          | ``                                                   |
|                         | `.Should().NotBeSameAs(PropertyInfo)`                | ``                                                   |
|                         | `.Should().NotBeVirtual()`                           | ``                                                   |
|                         | `.Should().NotBeWritable()`                          | ``                                                   |
|                         | `.Should().NotReturn(Type)`                          | ``                                                   |
|                         | `.Should().NotReturn<TReturn>()`                     | ``                                                   |
|                         | `.Should().Return(Type)`                             | ``                                                   |
|                         | `.Should().Return<TReturn>()`                        | ``                                                   |
| PropertyInfoSelector    | `.Should().BeDecoratedWith<TAttribute>()`            | ``                                                   |
|                         | `.Should().BeVirtual()`                              | ``                                                   |
|                         | `.Should().BeWritable()`                             | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>()`         | ``                                                   |
|                         | `.Should().NotBeVirtual()`                           | ``                                                   |
|                         | `.Should().NotBeWritable()`                          | ``                                                   |
| SByte                   | `.Should().Be(sbyte?)`                               | ``                                                   |
|                         | `.Should().Be(sbyte)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(sbyte)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(sbyte)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(sbyte)`            | ``                                                   |
|                         | `.Should().BeInRange(sbyte, sbyte)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(sbyte)`                   | ``                                                   |
|                         | `.Should().BeLessThan(sbyte)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(sbyte)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<sbyte>)`              | ``                                                   |
|                         | `.Should().BeOneOf(sbyte[])`                         | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<sbyte, bool>>)`     | ``                                                   |
|                         | `.Should().NotBe(sbyte?)`                            | ``                                                   |
|                         | `.Should().NotBe(sbyte)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(sbyte, sbyte)`               | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| SimpleTimeSpan          | `.Should().Be(TimeSpan)`                             | ``                                                   |
|                         | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             | ``                                                   |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                | ``                                                   |
|                         | `.Should().BeLessThan(TimeSpan)`                     | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(TimeSpan)`            | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().NotBe(TimeSpan)`                          | ``                                                   |
|                         | `.Should().NotBeCloseTo(TimeSpan, TimeSpan)`         | ``                                                   |
| Single                  | `.Should().Be(float?)`                               | ``                                                   |
|                         | `.Should().Be(float)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(float)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(float)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(float)`            | ``                                                   |
|                         | `.Should().BeInRange(float, float)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(float)`                   | ``                                                   |
|                         | `.Should().BeLessThan(float)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(float)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(float[])`                         | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<float>)`              | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<float, bool>>)`     | ``                                                   |
|                         | `.Should().NotBe(float?)`                            | ``                                                   |
|                         | `.Should().NotBe(float)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(float, float)`               | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| Stream                  | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeReadable()`                             | ``                                                   |
|                         | `.Should().BeReadOnly()`                             | ``                                                   |
|                         | `.Should().BeSameAs(Stream)`                         | ``                                                   |
|                         | `.Should().BeSeekable()`                             | ``                                                   |
|                         | `.Should().BeWritable()`                             | ``                                                   |
|                         | `.Should().BeWriteOnly()`                            | ``                                                   |
|                         | `.Should().HaveLength(long)`                         | ``                                                   |
|                         | `.Should().HavePosition(long)`                       | ``                                                   |
|                         | `.Should().Match(Expression<Func<Stream, bool>>)`    | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeReadable()`                          | ``                                                   |
|                         | `.Should().NotBeReadOnly()`                          | ``                                                   |
|                         | `.Should().NotBeSameAs(Stream)`                      | ``                                                   |
|                         | `.Should().NotBeSeekable()`                          | ``                                                   |
|                         | `.Should().NotBeWritable()`                          | ``                                                   |
|                         | `.Should().NotBeWriteOnly()`                         | ``                                                   |
|                         | `.Should().NotHaveLength(long)`                      | ``                                                   |
|                         | `.Should().NotHavePosition(long)`                    | ``                                                   |
| String                  | `.Should().Be(string)`                               | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEmpty()`                                | ``                                                   |
|                         | `.Should().BeEquivalentTo(string)`                   | ``                                                   |
|                         | `.Should().BeLowerCased()`                           | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeNullOrEmpty()`                          | ``                                                   |
|                         | `.Should().BeNullOrWhiteSpace()`                     | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<string>)`             | ``                                                   |
|                         | `.Should().BeOneOf(string[])`                        | ``                                                   |
|                         | `.Should().BeSameAs(string)`                         | ``                                                   |
|                         | `.Should().BeUpperCased()`                           | ``                                                   |
|                         | `.Should().Contain(string, OccurrenceConstraint)`    | ``                                                   |
|                         | `.Should().Contain(string)`                          | ``                                                   |
|                         | `.Should().ContainAll(IEnumerable<string>)`          | ``                                                   |
|                         | `.Should().ContainAll(string[])`                     | ``                                                   |
|                         | `.Should().ContainAny(IEnumerable<string>)`          | ``                                                   |
|                         | `.Should().ContainAny(string[])`                     | ``                                                   |
|                         | `.Should().ContainEquivalentOf(string, OccurrenceConstraint)` | ``                                                   |
|                         | `.Should().ContainEquivalentOf(string)`              | ``                                                   |
|                         | `.Should().EndWith(string)`                          | ``                                                   |
|                         | `.Should().EndWithEquivalentOf(string)`              | ``                                                   |
|                         | `.Should().HaveLength(int)`                          | ``                                                   |
|                         | `.Should().Match(Expression<Func<string, bool>>)`    | ``                                                   |
|                         | `.Should().Match(string)`                            | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().MatchEquivalentOf(string)`                | ``                                                   |
|                         | `.Should().MatchRegex(Regex, OccurrenceConstraint)`  | ``                                                   |
|                         | `.Should().MatchRegex(Regex)`                        | ``                                                   |
|                         | `.Should().MatchRegex(string, OccurrenceConstraint)` | ``                                                   |
|                         | `.Should().MatchRegex(string)`                       | ``                                                   |
|                         | `.Should().NotBe(string)`                            | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEmpty()`                             | ``                                                   |
|                         | `.Should().NotBeEquivalentTo(string)`                | ``                                                   |
|                         | `.Should().NotBeLowerCased()`                        | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeNullOrEmpty()`                       | ``                                                   |
|                         | `.Should().NotBeNullOrWhiteSpace()`                  | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(string)`                      | ``                                                   |
|                         | `.Should().NotBeUpperCased()`                        | ``                                                   |
|                         | `.Should().NotContain(string)`                       | ``                                                   |
|                         | `.Should().NotContainAll(IEnumerable<string>)`       | ``                                                   |
|                         | `.Should().NotContainAll(string[])`                  | ``                                                   |
|                         | `.Should().NotContainAny(IEnumerable<string>)`       | ``                                                   |
|                         | `.Should().NotContainAny(string[])`                  | ``                                                   |
|                         | `.Should().NotContainEquivalentOf(string)`           | ``                                                   |
|                         | `.Should().NotEndWith(string)`                       | ``                                                   |
|                         | `.Should().NotEndWithEquivalentOf(string)`           | ``                                                   |
|                         | `.Should().NotMatch(string)`                         | ``                                                   |
|                         | `.Should().NotMatchEquivalentOf(string)`             | ``                                                   |
|                         | `.Should().NotMatchRegex(Regex)`                     | ``                                                   |
|                         | `.Should().NotMatchRegex(string)`                    | ``                                                   |
|                         | `.Should().NotStartWith(string)`                     | ``                                                   |
|                         | `.Should().NotStartWithEquivalentOf(string)`         | ``                                                   |
|                         | `.Should().StartWith(string)`                        | ``                                                   |
|                         | `.Should().StartWithEquivalentOf(string)`            | ``                                                   |
| StringCollection        | `.Should().AllBe(string, Func<EquivalencyAssertionOptions<string>, EquivalencyAssertionOptions<string>>)` | ``                                                   |
|                         | `.Should().AllBe(string)`                            | ``                                                   |
|                         | `.Should().AllBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().AllBeAssignableTo<TExpectation>()`        | ``                                                   |
|                         | `.Should().AllBeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().AllBeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().AllBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().AllBeOfType<TExpectation>()`              | ``                                                   |
|                         | `.Should().AllSatisfy(Action<string>)`               | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEmpty()`                                | ``                                                   |
|                         | `.Should().BeEquivalentTo(IEnumerable<string>, Func<EquivalencyAssertionOptions<string>, EquivalencyAssertionOptions<string>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo(IEnumerable<string>)`      | ``                                                   |
|                         | `.Should().BeEquivalentTo(string[])`                 | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().BeInAscendingOrder()`                     | ``                                                   |
|                         | `.Should().BeInAscendingOrder(Func<string, string, int>)` | ``                                                   |
|                         | `.Should().BeInAscendingOrder(IComparer<string>)`    | ``                                                   |
|                         | `.Should().BeInAscendingOrder<TSelector>(Expression<Func<string, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().BeInAscendingOrder<TSelector>(Expression<Func<string, TSelector>>)` | ``                                                   |
|                         | `.Should().BeInDescendingOrder()`                    | ``                                                   |
|                         | `.Should().BeInDescendingOrder(Func<string, string, int>)` | ``                                                   |
|                         | `.Should().BeInDescendingOrder(IComparer<string>)`   | ``                                                   |
|                         | `.Should().BeInDescendingOrder<TSelector>(Expression<Func<string, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().BeInDescendingOrder<TSelector>(Expression<Func<string, TSelector>>)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeNullOrEmpty()`                          | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(TCollection)`                    | ``                                                   |
|                         | `.Should().BeSubsetOf(IEnumerable<string>)`          | ``                                                   |
|                         | `.Should().Contain(Expression<Func<string, bool>>)`  | ``                                                   |
|                         | `.Should().Contain(IEnumerable<string>)`             | ``                                                   |
|                         | `.Should().Contain(string)`                          | ``                                                   |
|                         | `.Should().ContainEquivalentOf<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().ContainEquivalentOf<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().ContainInConsecutiveOrder(IEnumerable<string>)` | ``                                                   |
|                         | `.Should().ContainInConsecutiveOrder(string[])`      | ``                                                   |
|                         | `.Should().ContainInOrder(IEnumerable<string>)`      | ``                                                   |
|                         | `.Should().ContainInOrder(string[])`                 | ``                                                   |
|                         | `.Should().ContainItemsAssignableTo<TExpectation>()` | ``                                                   |
|                         | `.Should().ContainMatch(string)`                     | ``                                                   |
|                         | `.Should().ContainSingle()`                          | ``                                                   |
|                         | `.Should().ContainSingle(Expression<Func<string, bool>>)` | ``                                                   |
|                         | `.Should().EndWith(IEnumerable<string>)`             | ``                                                   |
|                         | `.Should().EndWith(string)`                          | ``                                                   |
|                         | `.Should().EndWith<TExpectation>(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` | ``                                                   |
|                         | `.Should().Equal(IEnumerable<string>)`               | ``                                                   |
|                         | `.Should().Equal(string[])`                          | ``                                                   |
|                         | `.Should().Equal<TExpectation>(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` | ``                                                   |
|                         | `.Should().HaveCount(Expression<Func<int, bool>>)`   | ``                                                   |
|                         | `.Should().HaveCount(int)`                           | ``                                                   |
|                         | `.Should().HaveCountGreaterOrEqualTo(int)`           | ``                                                   |
|                         | `.Should().HaveCountGreaterThan(int)`                | ``                                                   |
|                         | `.Should().HaveCountGreaterThanOrEqualTo(int)`       | ``                                                   |
|                         | `.Should().HaveCountLessOrEqualTo(int)`              | ``                                                   |
|                         | `.Should().HaveCountLessThan(int)`                   | ``                                                   |
|                         | `.Should().HaveCountLessThanOrEqualTo(int)`          | ``                                                   |
|                         | `.Should().HaveElementAt(int, string)`               | ``                                                   |
|                         | `.Should().HaveElementPreceding(string, string)`     | ``                                                   |
|                         | `.Should().HaveElementSucceeding(string, string)`    | ``                                                   |
|                         | `.Should().HaveSameCount<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().IntersectWith(IEnumerable<string>)`       | ``                                                   |
|                         | `.Should().Match(Expression<Func<TCollection, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEmpty()`                             | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder()`                  | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder(Func<string, string, int>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder(IComparer<string>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder<TSelector>(Expression<Func<string, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder<TSelector>(Expression<Func<string, TSelector>>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder()`                 | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder(Func<string, string, int>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder(IComparer<string>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder<TSelector>(Expression<Func<string, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder<TSelector>(Expression<Func<string, TSelector>>)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeNullOrEmpty()`                       | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(TCollection)`                 | ``                                                   |
|                         | `.Should().NotBeSubsetOf(IEnumerable<string>)`       | ``                                                   |
|                         | `.Should().NotContain(Expression<Func<string, bool>>)` | ``                                                   |
|                         | `.Should().NotContain(IEnumerable<string>)`          | ``                                                   |
|                         | `.Should().NotContain(string)`                       | ``                                                   |
|                         | `.Should().NotContainEquivalentOf<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotContainEquivalentOf<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().NotContainInConsecutiveOrder(IEnumerable<string>)` | ``                                                   |
|                         | `.Should().NotContainInConsecutiveOrder(string[])`   | ``                                                   |
|                         | `.Should().NotContainInOrder(IEnumerable<string>)`   | ``                                                   |
|                         | `.Should().NotContainInOrder(string[])`              | ``                                                   |
|                         | `.Should().NotContainItemsAssignableTo(Type)`        | ``                                                   |
|                         | `.Should().NotContainItemsAssignableTo<TExpectation>()` | ``                                                   |
|                         | `.Should().NotContainMatch(string)`                  | ``                                                   |
|                         | `.Should().NotContainNulls()`                        | ``                                                   |
|                         | `.Should().NotContainNulls<TKey>(Expression<Func<string, TKey>>)` | ``                                                   |
|                         | `.Should().NotEqual(IEnumerable<string>)`            | ``                                                   |
|                         | `.Should().NotHaveCount(int)`                        | ``                                                   |
|                         | `.Should().NotHaveSameCount<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().NotIntersectWith(IEnumerable<string>)`    | ``                                                   |
|                         | `.Should().OnlyContain(Expression<Func<string, bool>>)` | ``                                                   |
|                         | `.Should().OnlyHaveUniqueItems()`                    | ``                                                   |
|                         | `.Should().OnlyHaveUniqueItems<TKey>(Expression<Func<string, TKey>>)` | ``                                                   |
|                         | `.Should().Satisfy(Expression<Func<string, bool>>[])` | ``                                                   |
|                         | `.Should().Satisfy(IEnumerable<Expression<Func<string, bool>>>)` | ``                                                   |
|                         | `.Should().SatisfyRespectively(Action<string>[])`    | ``                                                   |
|                         | `.Should().SatisfyRespectively(IEnumerable<Action<string>>)` | ``                                                   |
|                         | `.Should().StartWith(IEnumerable<string>)`           | ``                                                   |
|                         | `.Should().StartWith(string)`                        | ``                                                   |
|                         | `.Should().StartWith<TExpectation>(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` | ``                                                   |
| SubsequentOrdering      | `.Should().AllBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().AllBeAssignableTo<TExpectation>()`        | ``                                                   |
|                         | `.Should().AllBeEquivalentTo<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().AllBeEquivalentTo<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().AllBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().AllBeOfType<TExpectation>()`              | ``                                                   |
|                         | `.Should().AllSatisfy(Action<T>)`                    | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEmpty()`                                | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().BeEquivalentTo<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().BeInAscendingOrder()`                     | ``                                                   |
|                         | `.Should().BeInAscendingOrder(Func<T, T, int>)`      | ``                                                   |
|                         | `.Should().BeInAscendingOrder(IComparer<T>)`         | ``                                                   |
|                         | `.Should().BeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().BeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().BeInDescendingOrder()`                    | ``                                                   |
|                         | `.Should().BeInDescendingOrder(Func<T, T, int>)`     | ``                                                   |
|                         | `.Should().BeInDescendingOrder(IComparer<T>)`        | ``                                                   |
|                         | `.Should().BeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().BeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeNullOrEmpty()`                          | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(IEnumerable<T>)`                 | ``                                                   |
|                         | `.Should().BeSubsetOf(IEnumerable<T>)`               | ``                                                   |
|                         | `.Should().Contain(Expression<Func<T, bool>>)`       | ``                                                   |
|                         | `.Should().Contain(IEnumerable<T>)`                  | ``                                                   |
|                         | `.Should().Contain(T)`                               | ``                                                   |
|                         | `.Should().ContainEquivalentOf<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().ContainEquivalentOf<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().ContainInConsecutiveOrder(IEnumerable<T>)` | ``                                                   |
|                         | `.Should().ContainInConsecutiveOrder(T[])`           | ``                                                   |
|                         | `.Should().ContainInOrder(IEnumerable<T>)`           | ``                                                   |
|                         | `.Should().ContainInOrder(T[])`                      | ``                                                   |
|                         | `.Should().ContainItemsAssignableTo<TExpectation>()` | ``                                                   |
|                         | `.Should().ContainSingle()`                          | ``                                                   |
|                         | `.Should().ContainSingle(Expression<Func<T, bool>>)` | ``                                                   |
|                         | `.Should().EndWith(IEnumerable<T>)`                  | ``                                                   |
|                         | `.Should().EndWith(T)`                               | ``                                                   |
|                         | `.Should().EndWith<TExpectation>(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` | ``                                                   |
|                         | `.Should().Equal(IEnumerable<T>)`                    | ``                                                   |
|                         | `.Should().Equal(T[])`                               | ``                                                   |
|                         | `.Should().Equal<TExpectation>(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` | ``                                                   |
|                         | `.Should().HaveCount(Expression<Func<int, bool>>)`   | ``                                                   |
|                         | `.Should().HaveCount(int)`                           | ``                                                   |
|                         | `.Should().HaveCountGreaterOrEqualTo(int)`           | ``                                                   |
|                         | `.Should().HaveCountGreaterThan(int)`                | ``                                                   |
|                         | `.Should().HaveCountGreaterThanOrEqualTo(int)`       | ``                                                   |
|                         | `.Should().HaveCountLessOrEqualTo(int)`              | ``                                                   |
|                         | `.Should().HaveCountLessThan(int)`                   | ``                                                   |
|                         | `.Should().HaveCountLessThanOrEqualTo(int)`          | ``                                                   |
|                         | `.Should().HaveElementAt(int, T)`                    | ``                                                   |
|                         | `.Should().HaveElementPreceding(T, T)`               | ``                                                   |
|                         | `.Should().HaveElementSucceeding(T, T)`              | ``                                                   |
|                         | `.Should().HaveSameCount<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().IntersectWith(IEnumerable<T>)`            | ``                                                   |
|                         | `.Should().Match(Expression<Func<IEnumerable<T>, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEmpty()`                             | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotBeEquivalentTo<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder()`                  | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder(Func<T, T, int>)`   | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder(IComparer<T>)`      | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().NotBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder()`                 | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder(Func<T, T, int>)`  | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder(IComparer<T>)`     | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().NotBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeNullOrEmpty()`                       | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(IEnumerable<T>)`              | ``                                                   |
|                         | `.Should().NotBeSubsetOf(IEnumerable<T>)`            | ``                                                   |
|                         | `.Should().NotContain(Expression<Func<T, bool>>)`    | ``                                                   |
|                         | `.Should().NotContain(IEnumerable<T>)`               | ``                                                   |
|                         | `.Should().NotContain(T)`                            | ``                                                   |
|                         | `.Should().NotContainEquivalentOf<TExpectation>(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` | ``                                                   |
|                         | `.Should().NotContainEquivalentOf<TExpectation>(TExpectation)` | ``                                                   |
|                         | `.Should().NotContainInConsecutiveOrder(IEnumerable<T>)` | ``                                                   |
|                         | `.Should().NotContainInConsecutiveOrder(T[])`        | ``                                                   |
|                         | `.Should().NotContainInOrder(IEnumerable<T>)`        | ``                                                   |
|                         | `.Should().NotContainInOrder(T[])`                   | ``                                                   |
|                         | `.Should().NotContainItemsAssignableTo(Type)`        | ``                                                   |
|                         | `.Should().NotContainItemsAssignableTo<TExpectation>()` | ``                                                   |
|                         | `.Should().NotContainNulls()`                        | ``                                                   |
|                         | `.Should().NotContainNulls<TKey>(Expression<Func<T, TKey>>)` | ``                                                   |
|                         | `.Should().NotEqual(IEnumerable<T>)`                 | ``                                                   |
|                         | `.Should().NotHaveCount(int)`                        | ``                                                   |
|                         | `.Should().NotHaveSameCount<TExpectation>(IEnumerable<TExpectation>)` | ``                                                   |
|                         | `.Should().NotIntersectWith(IEnumerable<T>)`         | ``                                                   |
|                         | `.Should().OnlyContain(Expression<Func<T, bool>>)`   | ``                                                   |
|                         | `.Should().OnlyHaveUniqueItems()`                    | ``                                                   |
|                         | `.Should().OnlyHaveUniqueItems<TKey>(Expression<Func<T, TKey>>)` | ``                                                   |
|                         | `.Should().Satisfy(Expression<Func<T, bool>>[])`     | ``                                                   |
|                         | `.Should().Satisfy(IEnumerable<Expression<Func<T, bool>>>)` | ``                                                   |
|                         | `.Should().SatisfyRespectively(Action<T>[])`         | ``                                                   |
|                         | `.Should().SatisfyRespectively(IEnumerable<Action<T>>)` | ``                                                   |
|                         | `.Should().StartWith(IEnumerable<T>)`                | ``                                                   |
|                         | `.Should().StartWith(T)`                             | ``                                                   |
|                         | `.Should().StartWith<TExpectation>(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` | ``                                                   |
|                         | `.Should().ThenBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().ThenBeInAscendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
|                         | `.Should().ThenBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>, IComparer<TSelector>)` | ``                                                   |
|                         | `.Should().ThenBeInDescendingOrder<TSelector>(Expression<Func<T, TSelector>>)` | ``                                                   |
| TaskCompletionSource    | `.Should().CompleteWithinAsync(TimeSpan)`            | ``                                                   |
|                         | `.Should().NotCompleteWithinAsync(TimeSpan)`         | ``                                                   |
| TimeOnly                | `.Should().Be(Nullable<TimeOnly>)`                   | ``                                                   |
|                         | `.Should().Be(TimeOnly)`                             | ``                                                   |
|                         | `.Should().BeAfter(TimeOnly)`                        | ``                                                   |
|                         | `.Should().BeBefore(TimeOnly)`                       | ``                                                   |
|                         | `.Should().BeCloseTo(TimeOnly, TimeSpan)`            | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<TimeOnly>>)` | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<TimeOnly>)`           | ``                                                   |
|                         | `.Should().BeOneOf(Nullable<TimeOnly>[])`            | ``                                                   |
|                         | `.Should().BeOneOf(TimeOnly[])`                      | ``                                                   |
|                         | `.Should().BeOnOrAfter(TimeOnly)`                    | ``                                                   |
|                         | `.Should().BeOnOrBefore(TimeOnly)`                   | ``                                                   |
|                         | `.Should().HaveHours(int)`                           | ``                                                   |
|                         | `.Should().HaveMilliseconds(int)`                    | ``                                                   |
|                         | `.Should().HaveMinutes(int)`                         | ``                                                   |
|                         | `.Should().HaveSeconds(int)`                         | ``                                                   |
|                         | `.Should().NotBe(Nullable<TimeOnly>)`                | ``                                                   |
|                         | `.Should().NotBe(TimeOnly)`                          | ``                                                   |
|                         | `.Should().NotBeAfter(TimeOnly)`                     | ``                                                   |
|                         | `.Should().NotBeBefore(TimeOnly)`                    | ``                                                   |
|                         | `.Should().NotBeCloseTo(TimeOnly, TimeSpan)`         | ``                                                   |
|                         | `.Should().NotBeOnOrAfter(TimeOnly)`                 | ``                                                   |
|                         | `.Should().NotBeOnOrBefore(TimeOnly)`                | ``                                                   |
|                         | `.Should().NotHaveHours(int)`                        | ``                                                   |
|                         | `.Should().NotHaveMilliseconds(int)`                 | ``                                                   |
|                         | `.Should().NotHaveMinutes(int)`                      | ``                                                   |
|                         | `.Should().NotHaveSeconds(int)`                      | ``                                                   |
| Type                    | `.Should().Be(Type)`                                 | ``                                                   |
|                         | `.Should().Be<TExpected>()`                          | ``                                                   |
|                         | `.Should().BeAbstract()`                             | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>()`            | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeDecoratedWithOrInherit<TAttribute>()`   | ``                                                   |
|                         | `.Should().BeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeDerivedFrom(Type)`                      | ``                                                   |
|                         | `.Should().BeDerivedFrom<TBaseClass>()`              | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(Type)`                           | ``                                                   |
|                         | `.Should().BeSealed()`                               | ``                                                   |
|                         | `.Should().BeStatic()`                               | ``                                                   |
|                         | `.Should().HaveAccessModifier(CSharpAccessModifier)` | ``                                                   |
|                         | `.Should().HaveConstructor(IEnumerable<Type>)`       | ``                                                   |
|                         | `.Should().HaveDefaultConstructor()`                 | ``                                                   |
|                         | `.Should().HaveExplicitConversionOperator(Type, Type)` | ``                                                   |
|                         | `.Should().HaveExplicitConversionOperator<TSource, TTarget>()` | ``                                                   |
|                         | `.Should().HaveExplicitMethod(Type, string, IEnumerable<Type>)` | ``                                                   |
|                         | `.Should().HaveExplicitMethod<TInterface>(string, IEnumerable<Type>)` | ``                                                   |
|                         | `.Should().HaveExplicitProperty(Type, string)`       | ``                                                   |
|                         | `.Should().HaveExplicitProperty<TInterface>(string)` | ``                                                   |
|                         | `.Should().HaveImplicitConversionOperator(Type, Type)` | ``                                                   |
|                         | `.Should().HaveImplicitConversionOperator<TSource, TTarget>()` | ``                                                   |
|                         | `.Should().HaveIndexer(Type, IEnumerable<Type>)`     | ``                                                   |
|                         | `.Should().HaveMethod(string, IEnumerable<Type>)`    | ``                                                   |
|                         | `.Should().HaveProperty(Type, string)`               | ``                                                   |
|                         | `.Should().HaveProperty<TProperty>(string)`          | ``                                                   |
|                         | `.Should().Implement(Type)`                          | ``                                                   |
|                         | `.Should().Implement<TInterface>()`                  | ``                                                   |
|                         | `.Should().Match(Expression<Func<Type, bool>>)`      | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(Type)`                              | ``                                                   |
|                         | `.Should().NotBe<TUnexpected>()`                     | ``                                                   |
|                         | `.Should().NotBeAbstract()`                          | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>()`         | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeDecoratedWithOrInherit<TAttribute>()` | ``                                                   |
|                         | `.Should().NotBeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeDerivedFrom(Type)`                   | ``                                                   |
|                         | `.Should().NotBeDerivedFrom<TBaseClass>()`           | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(Type)`                        | ``                                                   |
|                         | `.Should().NotBeSealed()`                            | ``                                                   |
|                         | `.Should().NotBeStatic()`                            | ``                                                   |
|                         | `.Should().NotHaveAccessModifier(CSharpAccessModifier)` | ``                                                   |
|                         | `.Should().NotHaveConstructor(IEnumerable<Type>)`    | ``                                                   |
|                         | `.Should().NotHaveDefaultConstructor()`              | ``                                                   |
|                         | `.Should().NotHaveExplicitConversionOperator(Type, Type)` | ``                                                   |
|                         | `.Should().NotHaveExplicitConversionOperator<TSource, TTarget>()` | ``                                                   |
|                         | `.Should().NotHaveExplicitMethod(Type, string, IEnumerable<Type>)` | ``                                                   |
|                         | `.Should().NotHaveExplicitMethod<TInterface>(string, IEnumerable<Type>)` | ``                                                   |
|                         | `.Should().NotHaveExplicitProperty(Type, string)`    | ``                                                   |
|                         | `.Should().NotHaveExplicitProperty<TInterface>(string)` | ``                                                   |
|                         | `.Should().NotHaveImplicitConversionOperator(Type, Type)` | ``                                                   |
|                         | `.Should().NotHaveImplicitConversionOperator<TSource, TTarget>()` | ``                                                   |
|                         | `.Should().NotHaveIndexer(IEnumerable<Type>)`        | ``                                                   |
|                         | `.Should().NotHaveMethod(string, IEnumerable<Type>)` | ``                                                   |
|                         | `.Should().NotHaveProperty(string)`                  | ``                                                   |
|                         | `.Should().NotImplement(Type)`                       | ``                                                   |
|                         | `.Should().NotImplement<TInterface>()`               | ``                                                   |
| TypeSelector            | `.Should().BeDecoratedWith<TAttribute>()`            | ``                                                   |
|                         | `.Should().BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeDecoratedWithOrInherit<TAttribute>()`   | ``                                                   |
|                         | `.Should().BeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().BeInNamespace(string)`                    | ``                                                   |
|                         | `.Should().BeSealed()`                               | ``                                                   |
|                         | `.Should().BeUnderNamespace(string)`                 | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>()`         | ``                                                   |
|                         | `.Should().NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeDecoratedWithOrInherit<TAttribute>()` | ``                                                   |
|                         | `.Should().NotBeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>>)` | ``                                                   |
|                         | `.Should().NotBeInNamespace(string)`                 | ``                                                   |
|                         | `.Should().NotBeSealed()`                            | ``                                                   |
|                         | `.Should().NotBeUnderNamespace(string)`              | ``                                                   |
| UInt16                  | `.Should().Be(ushort?)`                              | ``                                                   |
|                         | `.Should().Be(ushort)`                               | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(ushort)`               | ``                                                   |
|                         | `.Should().BeGreaterThan(ushort)`                    | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(ushort)`           | ``                                                   |
|                         | `.Should().BeInRange(ushort, ushort)`                | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(ushort)`                  | ``                                                   |
|                         | `.Should().BeLessThan(ushort)`                       | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(ushort)`              | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<ushort>)`             | ``                                                   |
|                         | `.Should().BeOneOf(ushort[])`                        | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<ushort, bool>>)`    | ``                                                   |
|                         | `.Should().NotBe(ushort?)`                           | ``                                                   |
|                         | `.Should().NotBe(ushort)`                            | ``                                                   |
|                         | `.Should().NotBeInRange(ushort, ushort)`             | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| UInt32                  | `.Should().Be(uint?)`                                | ``                                                   |
|                         | `.Should().Be(uint)`                                 | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(uint)`                 | ``                                                   |
|                         | `.Should().BeGreaterThan(uint)`                      | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(uint)`             | ``                                                   |
|                         | `.Should().BeInRange(uint, uint)`                    | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(uint)`                    | ``                                                   |
|                         | `.Should().BeLessThan(uint)`                         | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(uint)`                | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<uint>)`               | ``                                                   |
|                         | `.Should().BeOneOf(uint[])`                          | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<uint, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(uint?)`                             | ``                                                   |
|                         | `.Should().NotBe(uint)`                              | ``                                                   |
|                         | `.Should().NotBeInRange(uint, uint)`                 | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| UInt64                  | `.Should().Be(ulong?)`                               | ``                                                   |
|                         | `.Should().Be(ulong)`                                | ``                                                   |
|                         | `.Should().BeGreaterOrEqualTo(ulong)`                | ``                                                   |
|                         | `.Should().BeGreaterThan(ulong)`                     | ``                                                   |
|                         | `.Should().BeGreaterThanOrEqualTo(ulong)`            | ``                                                   |
|                         | `.Should().BeInRange(ulong, ulong)`                  | ``                                                   |
|                         | `.Should().BeLessOrEqualTo(ulong)`                   | ``                                                   |
|                         | `.Should().BeLessThan(ulong)`                        | ``                                                   |
|                         | `.Should().BeLessThanOrEqualTo(ulong)`               | ``                                                   |
|                         | `.Should().BeNegative()`                             | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOneOf(IEnumerable<ulong>)`              | ``                                                   |
|                         | `.Should().BeOneOf(ulong[])`                         | ``                                                   |
|                         | `.Should().BePositive()`                             | ``                                                   |
|                         | `.Should().Match(Expression<Func<ulong, bool>>)`     | ``                                                   |
|                         | `.Should().NotBe(ulong?)`                            | ``                                                   |
|                         | `.Should().NotBe(ulong)`                             | ``                                                   |
|                         | `.Should().NotBeInRange(ulong, ulong)`               | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
| XAttribute              | `.Should().Be(XAttribute)`                           | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(XAttribute)`                     | ``                                                   |
|                         | `.Should().HaveValue(string)`                        | ``                                                   |
|                         | `.Should().Match(Expression<Func<XAttribute, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(XAttribute)`                        | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(XAttribute)`                  | ``                                                   |
| XDocument               | `.Should().Be(XDocument)`                            | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(XDocument)`                | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(XDocument)`                      | ``                                                   |
|                         | `.Should().HaveElement(string, OccurrenceConstraint)` | ``                                                   |
|                         | `.Should().HaveElement(string)`                      | ``                                                   |
|                         | `.Should().HaveElement(XName, OccurrenceConstraint)` | ``                                                   |
|                         | `.Should().HaveElement(XName)`                       | ``                                                   |
|                         | `.Should().HaveRoot(string)`                         | ``                                                   |
|                         | `.Should().HaveRoot(XName)`                          | ``                                                   |
|                         | `.Should().Match(Expression<Func<XDocument, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(XDocument)`                         | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEquivalentTo(XDocument)`             | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(XDocument)`                   | ``                                                   |
| XElement                | `.Should().Be(XElement)`                             | ``                                                   |
|                         | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(XElement)`                 | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(XElement)`                       | ``                                                   |
|                         | `.Should().HaveAttribute(string, string)`            | ``                                                   |
|                         | `.Should().HaveAttribute(XName, string)`             | ``                                                   |
|                         | `.Should().HaveElement(string, OccurrenceConstraint)` | ``                                                   |
|                         | `.Should().HaveElement(string)`                      | ``                                                   |
|                         | `.Should().HaveElement(XName, OccurrenceConstraint)` | ``                                                   |
|                         | `.Should().HaveElement(XName)`                       | ``                                                   |
|                         | `.Should().HaveValue(string)`                        | ``                                                   |
|                         | `.Should().Match(Expression<Func<XElement, bool>>)`  | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBe(XElement)`                          | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEquivalentTo(XElement)`              | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(XElement)`                    | ``                                                   |
| XmlElement              | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(XmlNode)`                  | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(XmlElement)`                     | ``                                                   |
|                         | `.Should().HaveAttribute(string, string)`            | ``                                                   |
|                         | `.Should().HaveAttributeWithNamespace(string, string, string)` | ``                                                   |
|                         | `.Should().HaveElement(string)`                      | ``                                                   |
|                         | `.Should().HaveElementWithNamespace(string, string)` | ``                                                   |
|                         | `.Should().HaveInnerText(string)`                    | ``                                                   |
|                         | `.Should().Match(Expression<Func<XmlElement, bool>>)` | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEquivalentTo(XmlNode)`               | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(XmlElement)`                  | ``                                                   |
| XmlNode                 | `.Should().BeAssignableTo(Type)`                     | ``                                                   |
|                         | `.Should().BeAssignableTo<T>()`                      | ``                                                   |
|                         | `.Should().BeEquivalentTo(XmlNode)`                  | ``                                                   |
|                         | `.Should().BeNull()`                                 | ``                                                   |
|                         | `.Should().BeOfType(Type)`                           | ``                                                   |
|                         | `.Should().BeOfType<T>()`                            | ``                                                   |
|                         | `.Should().BeSameAs(XmlNode)`                        | ``                                                   |
|                         | `.Should().Match(Expression<Func<XmlNode, bool>>)`   | ``                                                   |
|                         | `.Should().Match<T>(Expression<Func<T, bool>>)`      | ``                                                   |
|                         | `.Should().NotBeAssignableTo(Type)`                  | ``                                                   |
|                         | `.Should().NotBeAssignableTo<T>()`                   | ``                                                   |
|                         | `.Should().NotBeEquivalentTo(XmlNode)`               | ``                                                   |
|                         | `.Should().NotBeNull()`                              | ``                                                   |
|                         | `.Should().NotBeOfType(Type)`                        | ``                                                   |
|                         | `.Should().NotBeOfType<T>()`                         | ``                                                   |
|                         | `.Should().NotBeSameAs(XmlNode)`                     | ``                                                   |
