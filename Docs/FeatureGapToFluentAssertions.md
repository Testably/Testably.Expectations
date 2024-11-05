# Feature Gap between FluentAssertions and Testably.Expectations

|        Category         |                   FluentAssertions                   |                Testably.Expectations                 |
| ----------------------- | ---------------------------------------------------- | ---------------------------------------------------- |
| Action                  | `.Should().Throw()`                                  |                                                      |
|                         | `.Should().NotThrow()`                               |                                                      |
|                         | `.Should().NotThrow()`                               |                                                      |
|                         | `.Should().ThrowExactly()`                           |                                                      |
|                         | `.Should().NotThrowAfter(TimeSpan, TimeSpan)`        |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(Action)`                         |                                                      |
|                         | `.Should().NotBeSameAs(Action)`                      |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<Action, bool>>)`    |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| Assembly                | `.Should().NotReference(Assembly)`                   |                                                      |
|                         | `.Should().Reference(Assembly)`                      |                                                      |
|                         | `.Should().DefineType(string, string)`               |                                                      |
|                         | `.Should().BeUnsigned()`                             |                                                      |
|                         | `.Should().BeSignedWithPublicKey(string)`            |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(Assembly)`                       |                                                      |
|                         | `.Should().NotBeSameAs(Assembly)`                    |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<Assembly, bool>>)`  |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| Boolean                 | `.Should().BeFalse()`                                | `.Should().BeFalse()`                                |
|                         | `.Should().BeTrue()`                                 | `.Should().BeTrue()`                                 |
|                         | `.Should().Be(bool)`                                 | `.Should().Be(bool)`                                 |
|                         | `.Should().NotBe(bool)`                              |                                                      |
|                         | `.Should().Imply(bool)`                              |                                                      |
| Boolean?                | `.Should().BeFalse()`                                |                                                      |
|                         | `.Should().BeTrue()`                                 |                                                      |
|                         | `.Should().Be(bool)`                                 |                                                      |
|                         | `.Should().NotBe(bool)`                              |                                                      |
|                         | `.Should().Imply(bool)`                              |                                                      |
| BufferedStream          | `.Should().HaveBufferSize(int)`                      |                                                      |
|                         | `.Should().NotHaveBufferSize(int)`                   |                                                      |
|                         | `.Should().BeWritable()`                             |                                                      |
|                         | `.Should().NotBeWritable()`                          |                                                      |
|                         | `.Should().BeSeekable()`                             |                                                      |
|                         | `.Should().NotBeSeekable()`                          |                                                      |
|                         | `.Should().BeReadable()`                             |                                                      |
|                         | `.Should().NotBeReadable()`                          |                                                      |
|                         | `.Should().HavePosition(long)`                       |                                                      |
|                         | `.Should().NotHavePosition(long)`                    |                                                      |
|                         | `.Should().HaveLength(long)`                         |                                                      |
|                         | `.Should().NotHaveLength(long)`                      |                                                      |
|                         | `.Should().BeReadOnly()`                             |                                                      |
|                         | `.Should().NotBeReadOnly()`                          |                                                      |
|                         | `.Should().BeWriteOnly()`                            |                                                      |
|                         | `.Should().NotBeWriteOnly()`                         |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(BufferedStream)`                 |                                                      |
|                         | `.Should().NotBeSameAs(BufferedStream)`              |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<BufferedStream, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| BufferedStream?         | `.Should().HaveBufferSize(int)`                      |                                                      |
|                         | `.Should().NotHaveBufferSize(int)`                   |                                                      |
|                         | `.Should().BeWritable()`                             |                                                      |
|                         | `.Should().NotBeWritable()`                          |                                                      |
|                         | `.Should().BeSeekable()`                             |                                                      |
|                         | `.Should().NotBeSeekable()`                          |                                                      |
|                         | `.Should().BeReadable()`                             |                                                      |
|                         | `.Should().NotBeReadable()`                          |                                                      |
|                         | `.Should().HavePosition(long)`                       |                                                      |
|                         | `.Should().NotHavePosition(long)`                    |                                                      |
|                         | `.Should().HaveLength(long)`                         |                                                      |
|                         | `.Should().NotHaveLength(long)`                      |                                                      |
|                         | `.Should().BeReadOnly()`                             |                                                      |
|                         | `.Should().NotBeReadOnly()`                          |                                                      |
|                         | `.Should().BeWriteOnly()`                            |                                                      |
|                         | `.Should().NotBeWriteOnly()`                         |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(BufferedStream)`                 |                                                      |
|                         | `.Should().NotBeSameAs(BufferedStream)`              |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<BufferedStream, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| Byte                    | `.Should().Be(byte)`                                 |                                                      |
|                         | `.Should().Be(byte?)`                                |                                                      |
|                         | `.Should().NotBe(byte)`                              |                                                      |
|                         | `.Should().NotBe(byte?)`                             |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(byte)`                         |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(byte)`                |                                                      |
|                         | `.Should().BeLessOrEqualTo(byte)`                    |                                                      |
|                         | `.Should().BeGreaterThan(byte)`                      |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(byte)`             |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(byte)`                 |                                                      |
|                         | `.Should().BeInRange(byte, byte)`                    |                                                      |
|                         | `.Should().NotBeInRange(byte, byte)`                 |                                                      |
|                         | `.Should().BeOneOf(byte[])`                          |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<byte>)`               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<byte, bool>>)`      |                                                      |
| ComparableType?         | `.Should().Be(T)`                                    |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation)`             |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBe(T)`                                 |                                                      |
|                         | `.Should().BeRankedEquallyTo(T)`                     |                                                      |
|                         | `.Should().NotBeRankedEquallyTo(T)`                  |                                                      |
|                         | `.Should().BeLessThan(T)`                            |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(T)`                   |                                                      |
|                         | `.Should().BeLessOrEqualTo(T)`                       |                                                      |
|                         | `.Should().BeGreaterThan(T)`                         |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(T)`                |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(T)`                    |                                                      |
|                         | `.Should().BeInRange(T, T)`                          |                                                      |
|                         | `.Should().NotBeInRange(T, T)`                       |                                                      |
|                         | `.Should().BeOneOf(T[])`                             |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<T>)`                  |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(IComparable<T>)`                 |                                                      |
|                         | `.Should().NotBeSameAs(IComparable<T>)`              |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<IComparable<T>, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| ConstructorInfo         | `.Should().HaveAccessModifier(CSharpAccessModifier)` |                                                      |
|                         | `.Should().NotHaveAccessModifier(CSharpAccessModifier)` |                                                      |
|                         | `.Should().BeDecoratedWith()`                        |                                                      |
|                         | `.Should().NotBeDecoratedWith()`                     |                                                      |
|                         | `.Should().BeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(ConstructorInfo)`                |                                                      |
|                         | `.Should().NotBeSameAs(ConstructorInfo)`             |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<ConstructorInfo, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| DataColumn              | `.Should().BeEquivalentTo(DataColumn)`               |                                                      |
|                         | `.Should().BeEquivalentTo(DataColumn, Func<IDataEquivalencyAssertionOptions<DataColumn>, IDataEquivalencyAssertionOptions<DataColumn>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(DataColumn)`                     |                                                      |
|                         | `.Should().NotBeSameAs(DataColumn)`                  |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<DataColumn, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| DataRow?                | `.Should().HaveColumn(string)`                       |                                                      |
|                         | `.Should().HaveColumns(string[])`                    |                                                      |
|                         | `.Should().HaveColumns(IEnumerable<string>)`         |                                                      |
|                         | `.Should().BeEquivalentTo(DataRow)`                  |                                                      |
|                         | `.Should().BeEquivalentTo(DataRow, Func<IDataEquivalencyAssertionOptions<DataRow>, IDataEquivalencyAssertionOptions<DataRow>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(TDataRow)`                       |                                                      |
|                         | `.Should().NotBeSameAs(TDataRow)`                    |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<TDataRow, bool>>)`  |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| DataSet?                | `.Should().HaveTableCount(int)`                      |                                                      |
|                         | `.Should().HaveTable(string)`                        |                                                      |
|                         | `.Should().HaveTables(string[])`                     |                                                      |
|                         | `.Should().HaveTables(IEnumerable<string>)`          |                                                      |
|                         | `.Should().BeEquivalentTo(DataSet)`                  |                                                      |
|                         | `.Should().BeEquivalentTo(DataSet, Func<IDataEquivalencyAssertionOptions<DataSet>, IDataEquivalencyAssertionOptions<DataSet>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(DataSet)`                        |                                                      |
|                         | `.Should().NotBeSameAs(DataSet)`                     |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<DataSet, bool>>)`   |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| DataTable?              | `.Should().HaveRowCount(int)`                        |                                                      |
|                         | `.Should().HaveColumn(string)`                       |                                                      |
|                         | `.Should().HaveColumns(string[])`                    |                                                      |
|                         | `.Should().HaveColumns(IEnumerable<string>)`         |                                                      |
|                         | `.Should().BeEquivalentTo(DataTable)`                |                                                      |
|                         | `.Should().BeEquivalentTo(DataTable, Func<IDataEquivalencyAssertionOptions<DataTable>, IDataEquivalencyAssertionOptions<DataTable>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(DataTable)`                      |                                                      |
|                         | `.Should().NotBeSameAs(DataTable)`                   |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<DataTable, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| DateOnly                | `.Should().Be(DateOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateOnly>)`                   |                                                      |
|                         | `.Should().NotBe(DateOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateOnly>)`                |                                                      |
|                         | `.Should().BeBefore(DateOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateOnly)`                |                                                      |
|                         | `.Should().BeAfter(DateOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateOnly)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateOnly>>)` |                                                      |
| DateOnly?               | `.Should().Be(DateOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateOnly>)`                   |                                                      |
|                         | `.Should().NotBe(DateOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateOnly>)`                |                                                      |
|                         | `.Should().BeBefore(DateOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateOnly)`                |                                                      |
|                         | `.Should().BeAfter(DateOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateOnly)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateOnly>>)` |                                                      |
| DateTime                | `.Should().Be(DateTime)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateTime>)`                   |                                                      |
|                         | `.Should().NotBe(DateTime)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateTime>)`                |                                                      |
|                         | `.Should().BeCloseTo(DateTime, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(DateTime, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(DateTime)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateTime)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateTime)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTime)`                |                                                      |
|                         | `.Should().BeAfter(DateTime)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateTime)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateTime)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTime)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTime)`                   |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTime)`                |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTime>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateTime[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTime>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTime>>)` |                                                      |
|                         | `.Should().BeIn(DateTimeKind)`                       |                                                      |
| DateTime?               | `.Should().Be(DateTime)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateTime>)`                   |                                                      |
|                         | `.Should().NotBe(DateTime)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateTime>)`                |                                                      |
|                         | `.Should().BeCloseTo(DateTime, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(DateTime, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(DateTime)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateTime)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateTime)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTime)`                |                                                      |
|                         | `.Should().BeAfter(DateTime)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateTime)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateTime)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTime)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTime)`                   |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTime)`                |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTime>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateTime[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTime>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTime>>)` |                                                      |
|                         | `.Should().BeIn(DateTimeKind)`                       |                                                      |
| DateTimeOffset          | `.Should().Be(DateTimeOffset)`                       |                                                      |
|                         | `.Should().Be(Nullable<DateTimeOffset>)`             |                                                      |
|                         | `.Should().NotBe(DateTimeOffset)`                    |                                                      |
|                         | `.Should().NotBe(Nullable<DateTimeOffset>)`          |                                                      |
|                         | `.Should().BeExactly(DateTimeOffset)`                |                                                      |
|                         | `.Should().BeExactly(Nullable<DateTimeOffset>)`      |                                                      |
|                         | `.Should().NotBeExactly(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeExactly(Nullable<DateTimeOffset>)`   |                                                      |
|                         | `.Should().BeCloseTo(DateTimeOffset, TimeSpan)`      |                                                      |
|                         | `.Should().NotBeCloseTo(DateTimeOffset, TimeSpan)`   |                                                      |
|                         | `.Should().BeBefore(DateTimeOffset)`                 |                                                      |
|                         | `.Should().NotBeBefore(DateTimeOffset)`              |                                                      |
|                         | `.Should().BeOnOrBefore(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeAfter(DateTimeOffset)`                  |                                                      |
|                         | `.Should().NotBeAfter(DateTimeOffset)`               |                                                      |
|                         | `.Should().BeOnOrAfter(DateTimeOffset)`              |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTimeOffset)`           |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().HaveOffset(TimeSpan)`                     |                                                      |
|                         | `.Should().NotHaveOffset(TimeSpan)`                  |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTimeOffset>[])`      |                                                      |
|                         | `.Should().BeOneOf(DateTimeOffset[])`                |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTimeOffset>)`     |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTimeOffset>>)` |                                                      |
| DateTimeOffset?         | `.Should().Be(DateTimeOffset)`                       |                                                      |
|                         | `.Should().Be(Nullable<DateTimeOffset>)`             |                                                      |
|                         | `.Should().NotBe(DateTimeOffset)`                    |                                                      |
|                         | `.Should().NotBe(Nullable<DateTimeOffset>)`          |                                                      |
|                         | `.Should().BeExactly(DateTimeOffset)`                |                                                      |
|                         | `.Should().BeExactly(Nullable<DateTimeOffset>)`      |                                                      |
|                         | `.Should().NotBeExactly(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeExactly(Nullable<DateTimeOffset>)`   |                                                      |
|                         | `.Should().BeCloseTo(DateTimeOffset, TimeSpan)`      |                                                      |
|                         | `.Should().NotBeCloseTo(DateTimeOffset, TimeSpan)`   |                                                      |
|                         | `.Should().BeBefore(DateTimeOffset)`                 |                                                      |
|                         | `.Should().NotBeBefore(DateTimeOffset)`              |                                                      |
|                         | `.Should().BeOnOrBefore(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeAfter(DateTimeOffset)`                  |                                                      |
|                         | `.Should().NotBeAfter(DateTimeOffset)`               |                                                      |
|                         | `.Should().BeOnOrAfter(DateTimeOffset)`              |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTimeOffset)`           |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().HaveOffset(TimeSpan)`                     |                                                      |
|                         | `.Should().NotHaveOffset(TimeSpan)`                  |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTimeOffset>[])`      |                                                      |
|                         | `.Should().BeOneOf(DateTimeOffset[])`                |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTimeOffset>)`     |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTimeOffset>>)` |                                                      |
| DateTimeOffsetRange?    | `.Should().Before(DateTimeOffset)`                   |                                                      |
|                         | `.Should().After(DateTimeOffset)`                    |                                                      |
| DateTimeRange?          | `.Should().Before(DateTime)`                         |                                                      |
|                         | `.Should().After(DateTime)`                          |                                                      |
| Decimal                 | `.Should().Be(decimal)`                              |                                                      |
|                         | `.Should().Be(decimal?)`                             |                                                      |
|                         | `.Should().NotBe(decimal)`                           |                                                      |
|                         | `.Should().NotBe(decimal?)`                          |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(decimal)`                      |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(decimal)`             |                                                      |
|                         | `.Should().BeLessOrEqualTo(decimal)`                 |                                                      |
|                         | `.Should().BeGreaterThan(decimal)`                   |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(decimal)`          |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(decimal)`              |                                                      |
|                         | `.Should().BeInRange(decimal, decimal)`              |                                                      |
|                         | `.Should().NotBeInRange(decimal, decimal)`           |                                                      |
|                         | `.Should().BeOneOf(decimal[])`                       |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<decimal>)`            |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<decimal, bool>>)`   |                                                      |
| Double                  | `.Should().Be(double)`                               |                                                      |
|                         | `.Should().Be(double?)`                              |                                                      |
|                         | `.Should().NotBe(double)`                            |                                                      |
|                         | `.Should().NotBe(double?)`                           |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(double)`                       |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(double)`              |                                                      |
|                         | `.Should().BeLessOrEqualTo(double)`                  |                                                      |
|                         | `.Should().BeGreaterThan(double)`                    |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(double)`           |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(double)`               |                                                      |
|                         | `.Should().BeInRange(double, double)`                |                                                      |
|                         | `.Should().NotBeInRange(double, double)`             |                                                      |
|                         | `.Should().BeOneOf(double[])`                        |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<double>)`             |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<double, bool>>)`    |                                                      |
| Enum?                   | `.Should().Be(TEnum)`                                |                                                      |
|                         | `.Should().Be(Nullable<TEnum>)`                      |                                                      |
|                         | `.Should().NotBe(TEnum)`                             |                                                      |
|                         | `.Should().NotBe(Nullable<TEnum>)`                   |                                                      |
|                         | `.Should().BeDefined()`                              |                                                      |
|                         | `.Should().NotBeDefined()`                           |                                                      |
|                         | `.Should().HaveValue(decimal)`                       |                                                      |
|                         | `.Should().NotHaveValue(decimal)`                    |                                                      |
|                         | `.Should().HaveSameValueAs(T)`                       |                                                      |
|                         | `.Should().NotHaveSameValueAs(T)`                    |                                                      |
|                         | `.Should().HaveSameNameAs(T)`                        |                                                      |
|                         | `.Should().NotHaveSameNameAs(T)`                     |                                                      |
|                         | `.Should().HaveFlag(TEnum)`                          |                                                      |
|                         | `.Should().NotHaveFlag(TEnum)`                       |                                                      |
|                         | `.Should().Match(Expression<Func<Nullable<TEnum>, bool>>)` |                                                      |
|                         | `.Should().BeOneOf(TEnum[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<TEnum>)`              |                                                      |
| Event?                  | `.Should().Raise(string)`                            |                                                      |
|                         | `.Should().NotRaise(string)`                         |                                                      |
|                         | `.Should().RaisePropertyChangeFor(Expression<Func<T, object>>)` |                                                      |
|                         | `.Should().NotRaisePropertyChangeFor(Expression<Func<T, object>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(T)`                              |                                                      |
|                         | `.Should().NotBeSameAs(T)`                           |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| Exception?              | `.Should().WithMessage(string)`                      |                                                      |
|                         | `.Should().WithInnerException()`                     |                                                      |
|                         | `.Should().WithInnerException(Type)`                 |                                                      |
|                         | `.Should().WithInnerExceptionExactly()`              |                                                      |
|                         | `.Should().WithInnerExceptionExactly(Type)`          |                                                      |
|                         | `.Should().Where(Expression<Func<TException, bool>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(IEnumerable<TException>)`        |                                                      |
|                         | `.Should().NotBeSameAs(IEnumerable<TException>)`     |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<IEnumerable<TException>, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| ExecutionTime           | `.Should().BeLessThanOrEqualTo(TimeSpan)`            |                                                      |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             |                                                      |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  |                                                      |
|                         | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            |                                                      |
| Function?               | `.Should().NotThrow()`                               |                                                      |
|                         | `.Should().NotThrowAfter(TimeSpan, TimeSpan)`        |                                                      |
|                         | `.Should().Throw()`                                  |                                                      |
|                         | `.Should().NotThrow()`                               |                                                      |
|                         | `.Should().NotThrow()`                               |                                                      |
|                         | `.Should().ThrowExactly()`                           |                                                      |
|                         | `.Should().NotThrowAfter(TimeSpan, TimeSpan)`        |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(Func<T>)`                        |                                                      |
|                         | `.Should().NotBeSameAs(Func<T>)`                     |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<Func<T>, bool>>)`   |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| GenericAsyncFunction?   | `.Should().CompleteWithinAsync(TimeSpan)`            |                                                      |
|                         | `.Should().NotThrowAsync()`                          |                                                      |
|                         | `.Should().NotThrowAfterAsync(TimeSpan, TimeSpan)`   |                                                      |
|                         | `.Should().CompleteWithinAsync(TimeSpan)`            |                                                      |
|                         | `.Should().NotCompleteWithinAsync(TimeSpan)`         |                                                      |
|                         | `.Should().ThrowExactlyAsync()`                      |                                                      |
|                         | `.Should().ThrowAsync()`                             |                                                      |
|                         | `.Should().ThrowWithinAsync(TimeSpan)`               |                                                      |
|                         | `.Should().NotThrowAsync()`                          |                                                      |
|                         | `.Should().NotThrowAsync()`                          |                                                      |
|                         | `.Should().NotThrowAfterAsync(TimeSpan, TimeSpan)`   |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(Func<Task<TResult>>)`            |                                                      |
|                         | `.Should().NotBeSameAs(Func<Task<TResult>>)`         |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<Func<Task<TResult>>, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| GenericCollection?      | `.Should().AllBeAssignableTo()`                      |                                                      |
|                         | `.Should().AllBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation)`          |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().AllBeOfType()`                            |                                                      |
|                         | `.Should().AllBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(IComparer<T>)`         |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInAscendingOrder()`                     |                                                      |
|                         | `.Should().BeInAscendingOrder(Func<T, T, int>)`      |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().BeInDescendingOrder(IComparer<T>)`        |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInDescendingOrder()`                    |                                                      |
|                         | `.Should().BeInDescendingOrder(Func<T, T, int>)`     |                                                      |
|                         | `.Should().BeNullOrEmpty()`                          |                                                      |
|                         | `.Should().BeSubsetOf(IEnumerable<T>)`               |                                                      |
|                         | `.Should().Contain(T)`                               |                                                      |
|                         | `.Should().Contain(Expression<Func<T, bool>>)`       |                                                      |
|                         | `.Should().Contain(IEnumerable<T>)`                  |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation)`        |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().ContainInOrder(T[])`                      |                                                      |
|                         | `.Should().ContainInOrder(IEnumerable<T>)`           |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(T[])`           |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(IEnumerable<T>)` |                                                      |
|                         | `.Should().ContainItemsAssignableTo()`               |                                                      |
|                         | `.Should().NotContainItemsAssignableTo()`            |                                                      |
|                         | `.Should().NotContainItemsAssignableTo(Type)`        |                                                      |
|                         | `.Should().ContainSingle()`                          |                                                      |
|                         | `.Should().ContainSingle(Expression<Func<T, bool>>)` |                                                      |
|                         | `.Should().EndWith(IEnumerable<T>)`                  |                                                      |
|                         | `.Should().EndWith(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` |                                                      |
|                         | `.Should().EndWith(T)`                               |                                                      |
|                         | `.Should().Equal(T[])`                               |                                                      |
|                         | `.Should().Equal(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` |                                                      |
|                         | `.Should().Equal(IEnumerable<T>)`                    |                                                      |
|                         | `.Should().HaveCount(int)`                           |                                                      |
|                         | `.Should().HaveCount(Expression<Func<int, bool>>)`   |                                                      |
|                         | `.Should().HaveCountGreaterThanOrEqualTo(int)`       |                                                      |
|                         | `.Should().HaveCountGreaterOrEqualTo(int)`           |                                                      |
|                         | `.Should().HaveCountGreaterThan(int)`                |                                                      |
|                         | `.Should().HaveCountLessThanOrEqualTo(int)`          |                                                      |
|                         | `.Should().HaveCountLessOrEqualTo(int)`              |                                                      |
|                         | `.Should().HaveCountLessThan(int)`                   |                                                      |
|                         | `.Should().HaveElementAt(int, T)`                    |                                                      |
|                         | `.Should().HaveElementPreceding(T, T)`               |                                                      |
|                         | `.Should().HaveElementSucceeding(T, T)`              |                                                      |
|                         | `.Should().HaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().IntersectWith(IEnumerable<T>)`            |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(IComparer<T>)`      |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder()`                  |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Func<T, T, int>)`   |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(IComparer<T>)`     |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder()`                 |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Func<T, T, int>)`  |                                                      |
|                         | `.Should().NotBeNullOrEmpty()`                       |                                                      |
|                         | `.Should().NotBeSubsetOf(IEnumerable<T>)`            |                                                      |
|                         | `.Should().NotContain(T)`                            |                                                      |
|                         | `.Should().NotContain(Expression<Func<T, bool>>)`    |                                                      |
|                         | `.Should().NotContain(IEnumerable<T>)`               |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation)`     |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotContainInOrder(T[])`                   |                                                      |
|                         | `.Should().NotContainInOrder(IEnumerable<T>)`        |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(T[])`        |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(IEnumerable<T>)` |                                                      |
|                         | `.Should().NotContainNulls(Expression<Func<T, TKey>>)` |                                                      |
|                         | `.Should().NotContainNulls()`                        |                                                      |
|                         | `.Should().NotEqual(IEnumerable<T>)`                 |                                                      |
|                         | `.Should().NotHaveCount(int)`                        |                                                      |
|                         | `.Should().NotHaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotIntersectWith(IEnumerable<T>)`         |                                                      |
|                         | `.Should().OnlyContain(Expression<Func<T, bool>>)`   |                                                      |
|                         | `.Should().OnlyHaveUniqueItems(Expression<Func<T, TKey>>)` |                                                      |
|                         | `.Should().OnlyHaveUniqueItems()`                    |                                                      |
|                         | `.Should().AllSatisfy(Action<T>)`                    |                                                      |
|                         | `.Should().SatisfyRespectively(Action<T>[])`         |                                                      |
|                         | `.Should().SatisfyRespectively(IEnumerable<Action<T>>)` |                                                      |
|                         | `.Should().Satisfy(Expression<Func<T, bool>>[])`     |                                                      |
|                         | `.Should().Satisfy(IEnumerable<Expression<Func<T, bool>>>)` |                                                      |
|                         | `.Should().StartWith(IEnumerable<T>)`                |                                                      |
|                         | `.Should().StartWith(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` |                                                      |
|                         | `.Should().StartWith(T)`                             |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(IEnumerable<T>)`                 |                                                      |
|                         | `.Should().NotBeSameAs(IEnumerable<T>)`              |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<IEnumerable<T>, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| Guid                    | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().Be(string)`                               |                                                      |
|                         | `.Should().Be(Guid)`                                 |                                                      |
|                         | `.Should().NotBe(string)`                            |                                                      |
|                         | `.Should().NotBe(Guid)`                              |                                                      |
| Guid?                   | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().Be(string)`                               |                                                      |
|                         | `.Should().Be(Guid)`                                 |                                                      |
|                         | `.Should().NotBe(string)`                            |                                                      |
|                         | `.Should().NotBe(Guid)`                              |                                                      |
| HttpResponseMessage     | `.Should().BeSuccessful()`                           |                                                      |
|                         | `.Should().BeRedirection()`                          |                                                      |
|                         | `.Should().HaveError()`                              |                                                      |
|                         | `.Should().HaveClientError()`                        |                                                      |
|                         | `.Should().HaveServerError()`                        |                                                      |
|                         | `.Should().HaveStatusCode(HttpStatusCode)`           |                                                      |
|                         | `.Should().NotHaveStatusCode(HttpStatusCode)`        |                                                      |
|                         | `.Should().Be(HttpResponseMessage)`                  |                                                      |
|                         | `.Should().Be(HttpResponseMessage, IEqualityComparer<HttpResponseMessage>)` |                                                      |
|                         | `.Should().NotBe(HttpResponseMessage)`               |                                                      |
|                         | `.Should().NotBe(HttpResponseMessage, IEqualityComparer<HttpResponseMessage>)` |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation)`             |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBeEquivalentTo(TExpectation)`          |                                                      |
|                         | `.Should().NotBeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().BeOneOf(HttpResponseMessage[])`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<HttpResponseMessage>)` |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<HttpResponseMessage>, IEqualityComparer<HttpResponseMessage>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(HttpResponseMessage)`            |                                                      |
|                         | `.Should().NotBeSameAs(HttpResponseMessage)`         |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<HttpResponseMessage, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| HttpResponseMessage?    | `.Should().BeSuccessful()`                           |                                                      |
|                         | `.Should().BeRedirection()`                          |                                                      |
|                         | `.Should().HaveError()`                              |                                                      |
|                         | `.Should().HaveClientError()`                        |                                                      |
|                         | `.Should().HaveServerError()`                        |                                                      |
|                         | `.Should().HaveStatusCode(HttpStatusCode)`           |                                                      |
|                         | `.Should().NotHaveStatusCode(HttpStatusCode)`        |                                                      |
|                         | `.Should().Be(HttpResponseMessage)`                  |                                                      |
|                         | `.Should().Be(HttpResponseMessage, IEqualityComparer<HttpResponseMessage>)` |                                                      |
|                         | `.Should().NotBe(HttpResponseMessage)`               |                                                      |
|                         | `.Should().NotBe(HttpResponseMessage, IEqualityComparer<HttpResponseMessage>)` |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation)`             |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBeEquivalentTo(TExpectation)`          |                                                      |
|                         | `.Should().NotBeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().BeOneOf(HttpResponseMessage[])`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<HttpResponseMessage>)` |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<HttpResponseMessage>, IEqualityComparer<HttpResponseMessage>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(HttpResponseMessage)`            |                                                      |
|                         | `.Should().NotBeSameAs(HttpResponseMessage)`         |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<HttpResponseMessage, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| Int16                   | `.Should().Be(short)`                                |                                                      |
|                         | `.Should().Be(short?)`                               |                                                      |
|                         | `.Should().NotBe(short)`                             |                                                      |
|                         | `.Should().NotBe(short?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(short)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(short)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(short)`                   |                                                      |
|                         | `.Should().BeGreaterThan(short)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(short)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(short)`                |                                                      |
|                         | `.Should().BeInRange(short, short)`                  |                                                      |
|                         | `.Should().NotBeInRange(short, short)`               |                                                      |
|                         | `.Should().BeOneOf(short[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<short>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<short, bool>>)`     |                                                      |
| Int32                   | `.Should().Be(int)`                                  |                                                      |
|                         | `.Should().Be(int?)`                                 |                                                      |
|                         | `.Should().NotBe(int)`                               |                                                      |
|                         | `.Should().NotBe(int?)`                              |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(int)`                          |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(int)`                 |                                                      |
|                         | `.Should().BeLessOrEqualTo(int)`                     |                                                      |
|                         | `.Should().BeGreaterThan(int)`                       |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(int)`              |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(int)`                  |                                                      |
|                         | `.Should().BeInRange(int, int)`                      |                                                      |
|                         | `.Should().NotBeInRange(int, int)`                   |                                                      |
|                         | `.Should().BeOneOf(int[])`                           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<int>)`                |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<int, bool>>)`       |                                                      |
| Int64                   | `.Should().Be(long)`                                 |                                                      |
|                         | `.Should().Be(long?)`                                |                                                      |
|                         | `.Should().NotBe(long)`                              |                                                      |
|                         | `.Should().NotBe(long?)`                             |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(long)`                         |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(long)`                |                                                      |
|                         | `.Should().BeLessOrEqualTo(long)`                    |                                                      |
|                         | `.Should().BeGreaterThan(long)`                      |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(long)`             |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(long)`                 |                                                      |
|                         | `.Should().BeInRange(long, long)`                    |                                                      |
|                         | `.Should().NotBeInRange(long, long)`                 |                                                      |
|                         | `.Should().BeOneOf(long[])`                          |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<long>)`               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<long, bool>>)`      |                                                      |
| MethodInfo              | `.Should().BeVirtual()`                              |                                                      |
|                         | `.Should().NotBeVirtual()`                           |                                                      |
|                         | `.Should().BeAsync()`                                |                                                      |
|                         | `.Should().NotBeAsync()`                             |                                                      |
|                         | `.Should().ReturnVoid()`                             |                                                      |
|                         | `.Should().Return(Type)`                             |                                                      |
|                         | `.Should().Return()`                                 |                                                      |
|                         | `.Should().NotReturnVoid()`                          |                                                      |
|                         | `.Should().NotReturn(Type)`                          |                                                      |
|                         | `.Should().NotReturn()`                              |                                                      |
|                         | `.Should().HaveAccessModifier(CSharpAccessModifier)` |                                                      |
|                         | `.Should().NotHaveAccessModifier(CSharpAccessModifier)` |                                                      |
|                         | `.Should().BeDecoratedWith()`                        |                                                      |
|                         | `.Should().NotBeDecoratedWith()`                     |                                                      |
|                         | `.Should().BeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(MethodInfo)`                     |                                                      |
|                         | `.Should().NotBeSameAs(MethodInfo)`                  |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<MethodInfo, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| MethodInfoSelector      | `.Should().BeVirtual()`                              |                                                      |
|                         | `.Should().NotBeVirtual()`                           |                                                      |
|                         | `.Should().BeAsync()`                                |                                                      |
|                         | `.Should().NotBeAsync()`                             |                                                      |
|                         | `.Should().BeDecoratedWith()`                        |                                                      |
|                         | `.Should().BeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWith()`                     |                                                      |
|                         | `.Should().NotBeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().Be(CSharpAccessModifier)`                 |                                                      |
|                         | `.Should().NotBe(CSharpAccessModifier)`              |                                                      |
| NonGenericAsyncFunction | `.Should().CompleteWithinAsync(TimeSpan)`            |                                                      |
|                         | `.Should().NotCompleteWithinAsync(TimeSpan)`         |                                                      |
|                         | `.Should().ThrowExactlyAsync()`                      |                                                      |
|                         | `.Should().ThrowAsync()`                             |                                                      |
|                         | `.Should().ThrowWithinAsync(TimeSpan)`               |                                                      |
|                         | `.Should().NotThrowAsync()`                          |                                                      |
|                         | `.Should().NotThrowAsync()`                          |                                                      |
|                         | `.Should().NotThrowAfterAsync(TimeSpan, TimeSpan)`   |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(Func<Task>)`                     |                                                      |
|                         | `.Should().NotBeSameAs(Func<Task>)`                  |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<Func<Task>, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| NullableBoolean         | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(bool?)`                                |                                                      |
|                         | `.Should().NotBe(bool?)`                             |                                                      |
|                         | `.Should().NotBeFalse()`                             |                                                      |
|                         | `.Should().NotBeTrue()`                              |                                                      |
|                         | `.Should().BeFalse()`                                |                                                      |
|                         | `.Should().BeTrue()`                                 |                                                      |
|                         | `.Should().Be(bool)`                                 |                                                      |
|                         | `.Should().NotBe(bool)`                              |                                                      |
|                         | `.Should().Imply(bool)`                              |                                                      |
| NullableBoolean?        | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(bool?)`                                |                                                      |
|                         | `.Should().NotBe(bool?)`                             |                                                      |
|                         | `.Should().NotBeFalse()`                             |                                                      |
|                         | `.Should().NotBeTrue()`                              |                                                      |
|                         | `.Should().BeFalse()`                                |                                                      |
|                         | `.Should().BeTrue()`                                 |                                                      |
|                         | `.Should().Be(bool)`                                 |                                                      |
|                         | `.Should().NotBe(bool)`                              |                                                      |
|                         | `.Should().Imply(bool)`                              |                                                      |
| NullableByte            | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<byte?, bool>>)`     |                                                      |
|                         | `.Should().Be(byte)`                                 |                                                      |
|                         | `.Should().Be(byte?)`                                |                                                      |
|                         | `.Should().NotBe(byte)`                              |                                                      |
|                         | `.Should().NotBe(byte?)`                             |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(byte)`                         |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(byte)`                |                                                      |
|                         | `.Should().BeLessOrEqualTo(byte)`                    |                                                      |
|                         | `.Should().BeGreaterThan(byte)`                      |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(byte)`             |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(byte)`                 |                                                      |
|                         | `.Should().BeInRange(byte, byte)`                    |                                                      |
|                         | `.Should().NotBeInRange(byte, byte)`                 |                                                      |
|                         | `.Should().BeOneOf(byte[])`                          |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<byte>)`               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<byte, bool>>)`      |                                                      |
| NullableDateOnly        | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(DateOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateOnly>)`                   |                                                      |
|                         | `.Should().NotBe(DateOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateOnly>)`                |                                                      |
|                         | `.Should().BeBefore(DateOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateOnly)`                |                                                      |
|                         | `.Should().BeAfter(DateOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateOnly)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateOnly>>)` |                                                      |
| NullableDateOnly?       | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(DateOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateOnly>)`                   |                                                      |
|                         | `.Should().NotBe(DateOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateOnly>)`                |                                                      |
|                         | `.Should().BeBefore(DateOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateOnly)`                |                                                      |
|                         | `.Should().BeAfter(DateOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateOnly)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateOnly>>)` |                                                      |
| NullableDateTime        | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(DateTime)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateTime>)`                   |                                                      |
|                         | `.Should().NotBe(DateTime)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateTime>)`                |                                                      |
|                         | `.Should().BeCloseTo(DateTime, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(DateTime, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(DateTime)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateTime)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateTime)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTime)`                |                                                      |
|                         | `.Should().BeAfter(DateTime)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateTime)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateTime)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTime)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTime)`                   |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTime)`                |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTime>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateTime[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTime>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTime>>)` |                                                      |
|                         | `.Should().BeIn(DateTimeKind)`                       |                                                      |
| NullableDateTime?       | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(DateTime)`                             |                                                      |
|                         | `.Should().Be(Nullable<DateTime>)`                   |                                                      |
|                         | `.Should().NotBe(DateTime)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<DateTime>)`                |                                                      |
|                         | `.Should().BeCloseTo(DateTime, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(DateTime, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(DateTime)`                       |                                                      |
|                         | `.Should().NotBeBefore(DateTime)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(DateTime)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTime)`                |                                                      |
|                         | `.Should().BeAfter(DateTime)`                        |                                                      |
|                         | `.Should().NotBeAfter(DateTime)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(DateTime)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTime)`                 |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTime)`                   |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTime)`                |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTime>[])`            |                                                      |
|                         | `.Should().BeOneOf(DateTime[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTime>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTime>>)` |                                                      |
|                         | `.Should().BeIn(DateTimeKind)`                       |                                                      |
| NullableDateTimeOffset  | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(DateTimeOffset)`                       |                                                      |
|                         | `.Should().Be(Nullable<DateTimeOffset>)`             |                                                      |
|                         | `.Should().NotBe(DateTimeOffset)`                    |                                                      |
|                         | `.Should().NotBe(Nullable<DateTimeOffset>)`          |                                                      |
|                         | `.Should().BeExactly(DateTimeOffset)`                |                                                      |
|                         | `.Should().BeExactly(Nullable<DateTimeOffset>)`      |                                                      |
|                         | `.Should().NotBeExactly(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeExactly(Nullable<DateTimeOffset>)`   |                                                      |
|                         | `.Should().BeCloseTo(DateTimeOffset, TimeSpan)`      |                                                      |
|                         | `.Should().NotBeCloseTo(DateTimeOffset, TimeSpan)`   |                                                      |
|                         | `.Should().BeBefore(DateTimeOffset)`                 |                                                      |
|                         | `.Should().NotBeBefore(DateTimeOffset)`              |                                                      |
|                         | `.Should().BeOnOrBefore(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeAfter(DateTimeOffset)`                  |                                                      |
|                         | `.Should().NotBeAfter(DateTimeOffset)`               |                                                      |
|                         | `.Should().BeOnOrAfter(DateTimeOffset)`              |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTimeOffset)`           |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().HaveOffset(TimeSpan)`                     |                                                      |
|                         | `.Should().NotHaveOffset(TimeSpan)`                  |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTimeOffset>[])`      |                                                      |
|                         | `.Should().BeOneOf(DateTimeOffset[])`                |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTimeOffset>)`     |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTimeOffset>>)` |                                                      |
| NullableDateTimeOffset? | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(DateTimeOffset)`                       |                                                      |
|                         | `.Should().Be(Nullable<DateTimeOffset>)`             |                                                      |
|                         | `.Should().NotBe(DateTimeOffset)`                    |                                                      |
|                         | `.Should().NotBe(Nullable<DateTimeOffset>)`          |                                                      |
|                         | `.Should().BeExactly(DateTimeOffset)`                |                                                      |
|                         | `.Should().BeExactly(Nullable<DateTimeOffset>)`      |                                                      |
|                         | `.Should().NotBeExactly(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeExactly(Nullable<DateTimeOffset>)`   |                                                      |
|                         | `.Should().BeCloseTo(DateTimeOffset, TimeSpan)`      |                                                      |
|                         | `.Should().NotBeCloseTo(DateTimeOffset, TimeSpan)`   |                                                      |
|                         | `.Should().BeBefore(DateTimeOffset)`                 |                                                      |
|                         | `.Should().NotBeBefore(DateTimeOffset)`              |                                                      |
|                         | `.Should().BeOnOrBefore(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeOnOrBefore(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeAfter(DateTimeOffset)`                  |                                                      |
|                         | `.Should().NotBeAfter(DateTimeOffset)`               |                                                      |
|                         | `.Should().BeOnOrAfter(DateTimeOffset)`              |                                                      |
|                         | `.Should().NotBeOnOrAfter(DateTimeOffset)`           |                                                      |
|                         | `.Should().HaveYear(int)`                            |                                                      |
|                         | `.Should().NotHaveYear(int)`                         |                                                      |
|                         | `.Should().HaveMonth(int)`                           |                                                      |
|                         | `.Should().NotHaveMonth(int)`                        |                                                      |
|                         | `.Should().HaveDay(int)`                             |                                                      |
|                         | `.Should().NotHaveDay(int)`                          |                                                      |
|                         | `.Should().HaveHour(int)`                            |                                                      |
|                         | `.Should().NotHaveHour(int)`                         |                                                      |
|                         | `.Should().HaveMinute(int)`                          |                                                      |
|                         | `.Should().NotHaveMinute(int)`                       |                                                      |
|                         | `.Should().HaveSecond(int)`                          |                                                      |
|                         | `.Should().NotHaveSecond(int)`                       |                                                      |
|                         | `.Should().HaveOffset(TimeSpan)`                     |                                                      |
|                         | `.Should().NotHaveOffset(TimeSpan)`                  |                                                      |
|                         | `.Should().BeMoreThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeAtLeast(TimeSpan)`                      |                                                      |
|                         | `.Should().BeExactly(TimeSpan)`                      |                                                      |
|                         | `.Should().BeWithin(TimeSpan)`                       |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeSameDateAs(DateTimeOffset)`             |                                                      |
|                         | `.Should().NotBeSameDateAs(DateTimeOffset)`          |                                                      |
|                         | `.Should().BeOneOf(Nullable<DateTimeOffset>[])`      |                                                      |
|                         | `.Should().BeOneOf(DateTimeOffset[])`                |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<DateTimeOffset>)`     |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<DateTimeOffset>>)` |                                                      |
| NullableDecimal         | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<decimal?, bool>>)`  |                                                      |
|                         | `.Should().Be(decimal)`                              |                                                      |
|                         | `.Should().Be(decimal?)`                             |                                                      |
|                         | `.Should().NotBe(decimal)`                           |                                                      |
|                         | `.Should().NotBe(decimal?)`                          |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(decimal)`                      |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(decimal)`             |                                                      |
|                         | `.Should().BeLessOrEqualTo(decimal)`                 |                                                      |
|                         | `.Should().BeGreaterThan(decimal)`                   |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(decimal)`          |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(decimal)`              |                                                      |
|                         | `.Should().BeInRange(decimal, decimal)`              |                                                      |
|                         | `.Should().NotBeInRange(decimal, decimal)`           |                                                      |
|                         | `.Should().BeOneOf(decimal[])`                       |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<decimal>)`            |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<decimal, bool>>)`   |                                                      |
| NullableDouble          | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<double?, bool>>)`   |                                                      |
|                         | `.Should().Be(double)`                               |                                                      |
|                         | `.Should().Be(double?)`                              |                                                      |
|                         | `.Should().NotBe(double)`                            |                                                      |
|                         | `.Should().NotBe(double?)`                           |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(double)`                       |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(double)`              |                                                      |
|                         | `.Should().BeLessOrEqualTo(double)`                  |                                                      |
|                         | `.Should().BeGreaterThan(double)`                    |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(double)`           |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(double)`               |                                                      |
|                         | `.Should().BeInRange(double, double)`                |                                                      |
|                         | `.Should().NotBeInRange(double, double)`             |                                                      |
|                         | `.Should().BeOneOf(double[])`                        |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<double>)`             |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<double, bool>>)`    |                                                      |
| NullableEnum?           | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(TEnum)`                                |                                                      |
|                         | `.Should().Be(Nullable<TEnum>)`                      |                                                      |
|                         | `.Should().NotBe(TEnum)`                             |                                                      |
|                         | `.Should().NotBe(Nullable<TEnum>)`                   |                                                      |
|                         | `.Should().BeDefined()`                              |                                                      |
|                         | `.Should().NotBeDefined()`                           |                                                      |
|                         | `.Should().HaveValue(decimal)`                       |                                                      |
|                         | `.Should().NotHaveValue(decimal)`                    |                                                      |
|                         | `.Should().HaveSameValueAs(T)`                       |                                                      |
|                         | `.Should().NotHaveSameValueAs(T)`                    |                                                      |
|                         | `.Should().HaveSameNameAs(T)`                        |                                                      |
|                         | `.Should().NotHaveSameNameAs(T)`                     |                                                      |
|                         | `.Should().HaveFlag(TEnum)`                          |                                                      |
|                         | `.Should().NotHaveFlag(TEnum)`                       |                                                      |
|                         | `.Should().Match(Expression<Func<Nullable<TEnum>, bool>>)` |                                                      |
|                         | `.Should().BeOneOf(TEnum[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<TEnum>)`              |                                                      |
| NullableGuid            | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(Nullable<Guid>)`                       |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().Be(string)`                               |                                                      |
|                         | `.Should().Be(Guid)`                                 |                                                      |
|                         | `.Should().NotBe(string)`                            |                                                      |
|                         | `.Should().NotBe(Guid)`                              |                                                      |
| NullableGuid?           | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(Nullable<Guid>)`                       |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().Be(string)`                               |                                                      |
|                         | `.Should().Be(Guid)`                                 |                                                      |
|                         | `.Should().NotBe(string)`                            |                                                      |
|                         | `.Should().NotBe(Guid)`                              |                                                      |
| NullableInt16           | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<short?, bool>>)`    |                                                      |
|                         | `.Should().Be(short)`                                |                                                      |
|                         | `.Should().Be(short?)`                               |                                                      |
|                         | `.Should().NotBe(short)`                             |                                                      |
|                         | `.Should().NotBe(short?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(short)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(short)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(short)`                   |                                                      |
|                         | `.Should().BeGreaterThan(short)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(short)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(short)`                |                                                      |
|                         | `.Should().BeInRange(short, short)`                  |                                                      |
|                         | `.Should().NotBeInRange(short, short)`               |                                                      |
|                         | `.Should().BeOneOf(short[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<short>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<short, bool>>)`     |                                                      |
| NullableInt32           | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<int?, bool>>)`      |                                                      |
|                         | `.Should().Be(int)`                                  |                                                      |
|                         | `.Should().Be(int?)`                                 |                                                      |
|                         | `.Should().NotBe(int)`                               |                                                      |
|                         | `.Should().NotBe(int?)`                              |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(int)`                          |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(int)`                 |                                                      |
|                         | `.Should().BeLessOrEqualTo(int)`                     |                                                      |
|                         | `.Should().BeGreaterThan(int)`                       |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(int)`              |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(int)`                  |                                                      |
|                         | `.Should().BeInRange(int, int)`                      |                                                      |
|                         | `.Should().NotBeInRange(int, int)`                   |                                                      |
|                         | `.Should().BeOneOf(int[])`                           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<int>)`                |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<int, bool>>)`       |                                                      |
| NullableInt64           | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<long?, bool>>)`     |                                                      |
|                         | `.Should().Be(long)`                                 |                                                      |
|                         | `.Should().Be(long?)`                                |                                                      |
|                         | `.Should().NotBe(long)`                              |                                                      |
|                         | `.Should().NotBe(long?)`                             |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(long)`                         |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(long)`                |                                                      |
|                         | `.Should().BeLessOrEqualTo(long)`                    |                                                      |
|                         | `.Should().BeGreaterThan(long)`                      |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(long)`             |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(long)`                 |                                                      |
|                         | `.Should().BeInRange(long, long)`                    |                                                      |
|                         | `.Should().NotBeInRange(long, long)`                 |                                                      |
|                         | `.Should().BeOneOf(long[])`                          |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<long>)`               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<long, bool>>)`      |                                                      |
| NullableNumeric?        | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<Nullable<T>, bool>>)` |                                                      |
|                         | `.Should().Be(T)`                                    |                                                      |
|                         | `.Should().Be(Nullable<T>)`                          |                                                      |
|                         | `.Should().NotBe(T)`                                 |                                                      |
|                         | `.Should().NotBe(Nullable<T>)`                       |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(T)`                            |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(T)`                   |                                                      |
|                         | `.Should().BeLessOrEqualTo(T)`                       |                                                      |
|                         | `.Should().BeGreaterThan(T)`                         |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(T)`                |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(T)`                    |                                                      |
|                         | `.Should().BeInRange(T, T)`                          |                                                      |
|                         | `.Should().NotBeInRange(T, T)`                       |                                                      |
|                         | `.Should().BeOneOf(T[])`                             |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<T>)`                  |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| NullableSByte           | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<sbyte?, bool>>)`    |                                                      |
|                         | `.Should().Be(sbyte)`                                |                                                      |
|                         | `.Should().Be(sbyte?)`                               |                                                      |
|                         | `.Should().NotBe(sbyte)`                             |                                                      |
|                         | `.Should().NotBe(sbyte?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(sbyte)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(sbyte)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(sbyte)`                   |                                                      |
|                         | `.Should().BeGreaterThan(sbyte)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(sbyte)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(sbyte)`                |                                                      |
|                         | `.Should().BeInRange(sbyte, sbyte)`                  |                                                      |
|                         | `.Should().NotBeInRange(sbyte, sbyte)`               |                                                      |
|                         | `.Should().BeOneOf(sbyte[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<sbyte>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<sbyte, bool>>)`     |                                                      |
| NullableSimpleTimeSpan  | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(Nullable<TimeSpan>)`                   |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().Be(TimeSpan)`                             |                                                      |
|                         | `.Should().NotBe(TimeSpan)`                          |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(TimeSpan)`            |                                                      |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                |                                                      |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             |                                                      |
|                         | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeSpan, TimeSpan)`         |                                                      |
| NullableSimpleTimeSpan? | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(Nullable<TimeSpan>)`                   |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().Be(TimeSpan)`                             |                                                      |
|                         | `.Should().NotBe(TimeSpan)`                          |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(TimeSpan)`            |                                                      |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                |                                                      |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             |                                                      |
|                         | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeSpan, TimeSpan)`         |                                                      |
| NullableSingle          | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<float?, bool>>)`    |                                                      |
|                         | `.Should().Be(float)`                                |                                                      |
|                         | `.Should().Be(float?)`                               |                                                      |
|                         | `.Should().NotBe(float)`                             |                                                      |
|                         | `.Should().NotBe(float?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(float)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(float)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(float)`                   |                                                      |
|                         | `.Should().BeGreaterThan(float)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(float)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(float)`                |                                                      |
|                         | `.Should().BeInRange(float, float)`                  |                                                      |
|                         | `.Should().NotBeInRange(float, float)`               |                                                      |
|                         | `.Should().BeOneOf(float[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<float>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<float, bool>>)`     |                                                      |
| NullableTimeOnly        | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(TimeOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<TimeOnly>)`                   |                                                      |
|                         | `.Should().NotBe(TimeOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<TimeOnly>)`                |                                                      |
|                         | `.Should().BeCloseTo(TimeOnly, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeOnly, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(TimeOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(TimeOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(TimeOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(TimeOnly)`                |                                                      |
|                         | `.Should().BeAfter(TimeOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(TimeOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(TimeOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(TimeOnly)`                 |                                                      |
|                         | `.Should().HaveHours(int)`                           |                                                      |
|                         | `.Should().NotHaveHours(int)`                        |                                                      |
|                         | `.Should().HaveMinutes(int)`                         |                                                      |
|                         | `.Should().NotHaveMinutes(int)`                      |                                                      |
|                         | `.Should().HaveSeconds(int)`                         |                                                      |
|                         | `.Should().NotHaveSeconds(int)`                      |                                                      |
|                         | `.Should().HaveMilliseconds(int)`                    |                                                      |
|                         | `.Should().NotHaveMilliseconds(int)`                 |                                                      |
|                         | `.Should().BeOneOf(Nullable<TimeOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(TimeOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<TimeOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<TimeOnly>>)` |                                                      |
| NullableTimeOnly?       | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Be(TimeOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<TimeOnly>)`                   |                                                      |
|                         | `.Should().NotBe(TimeOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<TimeOnly>)`                |                                                      |
|                         | `.Should().BeCloseTo(TimeOnly, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeOnly, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(TimeOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(TimeOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(TimeOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(TimeOnly)`                |                                                      |
|                         | `.Should().BeAfter(TimeOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(TimeOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(TimeOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(TimeOnly)`                 |                                                      |
|                         | `.Should().HaveHours(int)`                           |                                                      |
|                         | `.Should().NotHaveHours(int)`                        |                                                      |
|                         | `.Should().HaveMinutes(int)`                         |                                                      |
|                         | `.Should().NotHaveMinutes(int)`                      |                                                      |
|                         | `.Should().HaveSeconds(int)`                         |                                                      |
|                         | `.Should().NotHaveSeconds(int)`                      |                                                      |
|                         | `.Should().HaveMilliseconds(int)`                    |                                                      |
|                         | `.Should().NotHaveMilliseconds(int)`                 |                                                      |
|                         | `.Should().BeOneOf(Nullable<TimeOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(TimeOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<TimeOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<TimeOnly>>)` |                                                      |
| NullableUInt16          | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<ushort?, bool>>)`   |                                                      |
|                         | `.Should().Be(ushort)`                               |                                                      |
|                         | `.Should().Be(ushort?)`                              |                                                      |
|                         | `.Should().NotBe(ushort)`                            |                                                      |
|                         | `.Should().NotBe(ushort?)`                           |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(ushort)`                       |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(ushort)`              |                                                      |
|                         | `.Should().BeLessOrEqualTo(ushort)`                  |                                                      |
|                         | `.Should().BeGreaterThan(ushort)`                    |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(ushort)`           |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(ushort)`               |                                                      |
|                         | `.Should().BeInRange(ushort, ushort)`                |                                                      |
|                         | `.Should().NotBeInRange(ushort, ushort)`             |                                                      |
|                         | `.Should().BeOneOf(ushort[])`                        |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<ushort>)`             |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<ushort, bool>>)`    |                                                      |
| NullableUInt32          | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<uint?, bool>>)`     |                                                      |
|                         | `.Should().Be(uint)`                                 |                                                      |
|                         | `.Should().Be(uint?)`                                |                                                      |
|                         | `.Should().NotBe(uint)`                              |                                                      |
|                         | `.Should().NotBe(uint?)`                             |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(uint)`                         |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(uint)`                |                                                      |
|                         | `.Should().BeLessOrEqualTo(uint)`                    |                                                      |
|                         | `.Should().BeGreaterThan(uint)`                      |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(uint)`             |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(uint)`                 |                                                      |
|                         | `.Should().BeInRange(uint, uint)`                    |                                                      |
|                         | `.Should().NotBeInRange(uint, uint)`                 |                                                      |
|                         | `.Should().BeOneOf(uint[])`                          |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<uint>)`               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<uint, bool>>)`      |                                                      |
| NullableUInt64          | `.Should().HaveValue()`                              |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().NotHaveValue()`                           |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().Match(Expression<Func<ulong?, bool>>)`    |                                                      |
|                         | `.Should().Be(ulong)`                                |                                                      |
|                         | `.Should().Be(ulong?)`                               |                                                      |
|                         | `.Should().NotBe(ulong)`                             |                                                      |
|                         | `.Should().NotBe(ulong?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(ulong)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(ulong)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(ulong)`                   |                                                      |
|                         | `.Should().BeGreaterThan(ulong)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(ulong)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(ulong)`                |                                                      |
|                         | `.Should().BeInRange(ulong, ulong)`                  |                                                      |
|                         | `.Should().NotBeInRange(ulong, ulong)`               |                                                      |
|                         | `.Should().BeOneOf(ulong[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<ulong>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<ulong, bool>>)`     |                                                      |
| Numeric?                | `.Should().Be(T)`                                    |                                                      |
|                         | `.Should().Be(Nullable<T>)`                          |                                                      |
|                         | `.Should().NotBe(T)`                                 |                                                      |
|                         | `.Should().NotBe(Nullable<T>)`                       |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(T)`                            |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(T)`                   |                                                      |
|                         | `.Should().BeLessOrEqualTo(T)`                       |                                                      |
|                         | `.Should().BeGreaterThan(T)`                         |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(T)`                |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(T)`                    |                                                      |
|                         | `.Should().BeInRange(T, T)`                          |                                                      |
|                         | `.Should().NotBeInRange(T, T)`                       |                                                      |
|                         | `.Should().BeOneOf(T[])`                             |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<T>)`                  |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| Object                  | `.Should().Be(TExpectation, IEqualityComparer<TExpectation>)` |                                                      |
|                         | `.Should().NotBe(TExpectation, IEqualityComparer<TExpectation>)` |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<TExpectation>, IEqualityComparer<TExpectation>)` |                                                      |
|                         | `.Should().Be(object)`                               |                                                      |
|                         | `.Should().Be(object, IEqualityComparer<object>)`    |                                                      |
|                         | `.Should().NotBe(object)`                            |                                                      |
|                         | `.Should().NotBe(object, IEqualityComparer<object>)` |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation)`             |                                                      |
|                         | `.Should().BeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBeEquivalentTo(TExpectation)`          |                                                      |
|                         | `.Should().NotBeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().BeOneOf(object[])`                        |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<object>)`             |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<object>, IEqualityComparer<object>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(object)`                         |                                                      |
|                         | `.Should().NotBeSameAs(object)`                      |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<object, bool>>)`    |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| PropertyInfo            | `.Should().BeVirtual()`                              |                                                      |
|                         | `.Should().NotBeVirtual()`                           |                                                      |
|                         | `.Should().BeWritable()`                             |                                                      |
|                         | `.Should().BeWritable(CSharpAccessModifier)`         |                                                      |
|                         | `.Should().NotBeWritable()`                          |                                                      |
|                         | `.Should().BeReadable()`                             |                                                      |
|                         | `.Should().BeReadable(CSharpAccessModifier)`         |                                                      |
|                         | `.Should().NotBeReadable()`                          |                                                      |
|                         | `.Should().Return(Type)`                             |                                                      |
|                         | `.Should().Return()`                                 |                                                      |
|                         | `.Should().NotReturn(Type)`                          |                                                      |
|                         | `.Should().NotReturn()`                              |                                                      |
|                         | `.Should().BeDecoratedWith()`                        |                                                      |
|                         | `.Should().NotBeDecoratedWith()`                     |                                                      |
|                         | `.Should().BeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(PropertyInfo)`                   |                                                      |
|                         | `.Should().NotBeSameAs(PropertyInfo)`                |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<PropertyInfo, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| PropertyInfoSelector    | `.Should().BeVirtual()`                              |                                                      |
|                         | `.Should().NotBeVirtual()`                           |                                                      |
|                         | `.Should().BeWritable()`                             |                                                      |
|                         | `.Should().NotBeWritable()`                          |                                                      |
|                         | `.Should().BeDecoratedWith()`                        |                                                      |
|                         | `.Should().NotBeDecoratedWith()`                     |                                                      |
| SByte                   | `.Should().Be(sbyte)`                                |                                                      |
|                         | `.Should().Be(sbyte?)`                               |                                                      |
|                         | `.Should().NotBe(sbyte)`                             |                                                      |
|                         | `.Should().NotBe(sbyte?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(sbyte)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(sbyte)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(sbyte)`                   |                                                      |
|                         | `.Should().BeGreaterThan(sbyte)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(sbyte)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(sbyte)`                |                                                      |
|                         | `.Should().BeInRange(sbyte, sbyte)`                  |                                                      |
|                         | `.Should().NotBeInRange(sbyte, sbyte)`               |                                                      |
|                         | `.Should().BeOneOf(sbyte[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<sbyte>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<sbyte, bool>>)`     |                                                      |
| SimpleTimeSpan          | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().Be(TimeSpan)`                             |                                                      |
|                         | `.Should().NotBe(TimeSpan)`                          |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(TimeSpan)`            |                                                      |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                |                                                      |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             |                                                      |
|                         | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeSpan, TimeSpan)`         |                                                      |
| SimpleTimeSpan?         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().Be(TimeSpan)`                             |                                                      |
|                         | `.Should().NotBe(TimeSpan)`                          |                                                      |
|                         | `.Should().BeLessThan(TimeSpan)`                     |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(TimeSpan)`            |                                                      |
|                         | `.Should().BeLessOrEqualTo(TimeSpan)`                |                                                      |
|                         | `.Should().BeGreaterThan(TimeSpan)`                  |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(TimeSpan)`         |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(TimeSpan)`             |                                                      |
|                         | `.Should().BeCloseTo(TimeSpan, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeSpan, TimeSpan)`         |                                                      |
| Single                  | `.Should().Be(float)`                                |                                                      |
|                         | `.Should().Be(float?)`                               |                                                      |
|                         | `.Should().NotBe(float)`                             |                                                      |
|                         | `.Should().NotBe(float?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(float)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(float)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(float)`                   |                                                      |
|                         | `.Should().BeGreaterThan(float)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(float)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(float)`                |                                                      |
|                         | `.Should().BeInRange(float, float)`                  |                                                      |
|                         | `.Should().NotBeInRange(float, float)`               |                                                      |
|                         | `.Should().BeOneOf(float[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<float>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<float, bool>>)`     |                                                      |
| Stream                  | `.Should().BeWritable()`                             |                                                      |
|                         | `.Should().NotBeWritable()`                          |                                                      |
|                         | `.Should().BeSeekable()`                             |                                                      |
|                         | `.Should().NotBeSeekable()`                          |                                                      |
|                         | `.Should().BeReadable()`                             |                                                      |
|                         | `.Should().NotBeReadable()`                          |                                                      |
|                         | `.Should().HavePosition(long)`                       |                                                      |
|                         | `.Should().NotHavePosition(long)`                    |                                                      |
|                         | `.Should().HaveLength(long)`                         |                                                      |
|                         | `.Should().NotHaveLength(long)`                      |                                                      |
|                         | `.Should().BeReadOnly()`                             |                                                      |
|                         | `.Should().NotBeReadOnly()`                          |                                                      |
|                         | `.Should().BeWriteOnly()`                            |                                                      |
|                         | `.Should().NotBeWriteOnly()`                         |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(Stream)`                         |                                                      |
|                         | `.Should().NotBeSameAs(Stream)`                      |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<Stream, bool>>)`    |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| String                  | `.Should().Be(string)`                               |                                                      |
|                         | `.Should().BeOneOf(string[])`                        |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<string>)`             |                                                      |
|                         | `.Should().BeEquivalentTo(string)`                   |                                                      |
|                         | `.Should().NotBeEquivalentTo(string)`                |                                                      |
|                         | `.Should().NotBe(string)`                            |                                                      |
|                         | `.Should().Match(string)`                            |                                                      |
|                         | `.Should().NotMatch(string)`                         |                                                      |
|                         | `.Should().MatchEquivalentOf(string)`                |                                                      |
|                         | `.Should().NotMatchEquivalentOf(string)`             |                                                      |
|                         | `.Should().MatchRegex(string, OccurrenceConstraint)` |                                                      |
|                         | `.Should().MatchRegex(string)`                       |                                                      |
|                         | `.Should().MatchRegex(Regex, OccurrenceConstraint)`  |                                                      |
|                         | `.Should().MatchRegex(Regex)`                        |                                                      |
|                         | `.Should().NotMatchRegex(string)`                    |                                                      |
|                         | `.Should().NotMatchRegex(Regex)`                     |                                                      |
|                         | `.Should().StartWith(string)`                        |                                                      |
|                         | `.Should().NotStartWith(string)`                     |                                                      |
|                         | `.Should().StartWithEquivalentOf(string)`            |                                                      |
|                         | `.Should().NotStartWithEquivalentOf(string)`         |                                                      |
|                         | `.Should().EndWith(string)`                          |                                                      |
|                         | `.Should().NotEndWith(string)`                       |                                                      |
|                         | `.Should().EndWithEquivalentOf(string)`              |                                                      |
|                         | `.Should().NotEndWithEquivalentOf(string)`           |                                                      |
|                         | `.Should().Contain(string)`                          |                                                      |
|                         | `.Should().Contain(string, OccurrenceConstraint)`    |                                                      |
|                         | `.Should().ContainEquivalentOf(string)`              |                                                      |
|                         | `.Should().ContainEquivalentOf(string, OccurrenceConstraint)` |                                                      |
|                         | `.Should().ContainAll(IEnumerable<string>)`          |                                                      |
|                         | `.Should().ContainAll(string[])`                     |                                                      |
|                         | `.Should().ContainAny(IEnumerable<string>)`          |                                                      |
|                         | `.Should().ContainAny(string[])`                     |                                                      |
|                         | `.Should().NotContain(string)`                       |                                                      |
|                         | `.Should().NotContainAll(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotContainAll(string[])`                  |                                                      |
|                         | `.Should().NotContainAny(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotContainAny(string[])`                  |                                                      |
|                         | `.Should().NotContainEquivalentOf(string)`           |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().HaveLength(int)`                          |                                                      |
|                         | `.Should().NotBeNullOrEmpty()`                       |                                                      |
|                         | `.Should().BeNullOrEmpty()`                          |                                                      |
|                         | `.Should().NotBeNullOrWhiteSpace()`                  |                                                      |
|                         | `.Should().BeNullOrWhiteSpace()`                     |                                                      |
|                         | `.Should().BeUpperCased()`                           |                                                      |
|                         | `.Should().NotBeUpperCased()`                        |                                                      |
|                         | `.Should().BeLowerCased()`                           |                                                      |
|                         | `.Should().NotBeLowerCased()`                        |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(string)`                         |                                                      |
|                         | `.Should().NotBeSameAs(string)`                      |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<string, bool>>)`    |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| String?                 | `.Should().Be(string)`                               |                                                      |
|                         | `.Should().BeOneOf(string[])`                        |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<string>)`             |                                                      |
|                         | `.Should().BeEquivalentTo(string)`                   |                                                      |
|                         | `.Should().NotBeEquivalentTo(string)`                |                                                      |
|                         | `.Should().NotBe(string)`                            |                                                      |
|                         | `.Should().Match(string)`                            |                                                      |
|                         | `.Should().NotMatch(string)`                         |                                                      |
|                         | `.Should().MatchEquivalentOf(string)`                |                                                      |
|                         | `.Should().NotMatchEquivalentOf(string)`             |                                                      |
|                         | `.Should().MatchRegex(string, OccurrenceConstraint)` |                                                      |
|                         | `.Should().MatchRegex(string)`                       |                                                      |
|                         | `.Should().MatchRegex(Regex, OccurrenceConstraint)`  |                                                      |
|                         | `.Should().MatchRegex(Regex)`                        |                                                      |
|                         | `.Should().NotMatchRegex(string)`                    |                                                      |
|                         | `.Should().NotMatchRegex(Regex)`                     |                                                      |
|                         | `.Should().StartWith(string)`                        |                                                      |
|                         | `.Should().NotStartWith(string)`                     |                                                      |
|                         | `.Should().StartWithEquivalentOf(string)`            |                                                      |
|                         | `.Should().NotStartWithEquivalentOf(string)`         |                                                      |
|                         | `.Should().EndWith(string)`                          |                                                      |
|                         | `.Should().NotEndWith(string)`                       |                                                      |
|                         | `.Should().EndWithEquivalentOf(string)`              |                                                      |
|                         | `.Should().NotEndWithEquivalentOf(string)`           |                                                      |
|                         | `.Should().Contain(string)`                          |                                                      |
|                         | `.Should().Contain(string, OccurrenceConstraint)`    |                                                      |
|                         | `.Should().ContainEquivalentOf(string)`              |                                                      |
|                         | `.Should().ContainEquivalentOf(string, OccurrenceConstraint)` |                                                      |
|                         | `.Should().ContainAll(IEnumerable<string>)`          |                                                      |
|                         | `.Should().ContainAll(string[])`                     |                                                      |
|                         | `.Should().ContainAny(IEnumerable<string>)`          |                                                      |
|                         | `.Should().ContainAny(string[])`                     |                                                      |
|                         | `.Should().NotContain(string)`                       |                                                      |
|                         | `.Should().NotContainAll(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotContainAll(string[])`                  |                                                      |
|                         | `.Should().NotContainAny(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotContainAny(string[])`                  |                                                      |
|                         | `.Should().NotContainEquivalentOf(string)`           |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().HaveLength(int)`                          |                                                      |
|                         | `.Should().NotBeNullOrEmpty()`                       |                                                      |
|                         | `.Should().BeNullOrEmpty()`                          |                                                      |
|                         | `.Should().NotBeNullOrWhiteSpace()`                  |                                                      |
|                         | `.Should().BeNullOrWhiteSpace()`                     |                                                      |
|                         | `.Should().BeUpperCased()`                           |                                                      |
|                         | `.Should().NotBeUpperCased()`                        |                                                      |
|                         | `.Should().BeLowerCased()`                           |                                                      |
|                         | `.Should().NotBeLowerCased()`                        |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(string)`                         |                                                      |
|                         | `.Should().NotBeSameAs(string)`                      |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<string, bool>>)`    |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| StringCollection        | `.Should().Equal(string[])`                          |                                                      |
|                         | `.Should().Equal(IEnumerable<string>)`               |                                                      |
|                         | `.Should().BeEquivalentTo(string[])`                 |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<string>)`      |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<string>, Func<EquivalencyAssertionOptions<string>, EquivalencyAssertionOptions<string>>)` |                                                      |
|                         | `.Should().AllBe(string)`                            |                                                      |
|                         | `.Should().AllBe(string, Func<EquivalencyAssertionOptions<string>, EquivalencyAssertionOptions<string>>)` |                                                      |
|                         | `.Should().ContainMatch(string)`                     |                                                      |
|                         | `.Should().NotContainMatch(string)`                  |                                                      |
|                         | `.Should().AllBeAssignableTo()`                      |                                                      |
|                         | `.Should().AllBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation)`          |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().AllBeOfType()`                            |                                                      |
|                         | `.Should().AllBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(IComparer<string>)`    |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInAscendingOrder()`                     |                                                      |
|                         | `.Should().BeInAscendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().BeInDescendingOrder(IComparer<string>)`   |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInDescendingOrder()`                    |                                                      |
|                         | `.Should().BeInDescendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().BeNullOrEmpty()`                          |                                                      |
|                         | `.Should().BeSubsetOf(IEnumerable<string>)`          |                                                      |
|                         | `.Should().Contain(string)`                          |                                                      |
|                         | `.Should().Contain(Expression<Func<string, bool>>)`  |                                                      |
|                         | `.Should().Contain(IEnumerable<string>)`             |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation)`        |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().ContainInOrder(string[])`                 |                                                      |
|                         | `.Should().ContainInOrder(IEnumerable<string>)`      |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(string[])`      |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(IEnumerable<string>)` |                                                      |
|                         | `.Should().ContainItemsAssignableTo()`               |                                                      |
|                         | `.Should().NotContainItemsAssignableTo()`            |                                                      |
|                         | `.Should().NotContainItemsAssignableTo(Type)`        |                                                      |
|                         | `.Should().ContainSingle()`                          |                                                      |
|                         | `.Should().ContainSingle(Expression<Func<string, bool>>)` |                                                      |
|                         | `.Should().EndWith(IEnumerable<string>)`             |                                                      |
|                         | `.Should().EndWith(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` |                                                      |
|                         | `.Should().EndWith(string)`                          |                                                      |
|                         | `.Should().Equal(string[])`                          |                                                      |
|                         | `.Should().Equal(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` |                                                      |
|                         | `.Should().Equal(IEnumerable<string>)`               |                                                      |
|                         | `.Should().HaveCount(int)`                           |                                                      |
|                         | `.Should().HaveCount(Expression<Func<int, bool>>)`   |                                                      |
|                         | `.Should().HaveCountGreaterThanOrEqualTo(int)`       |                                                      |
|                         | `.Should().HaveCountGreaterOrEqualTo(int)`           |                                                      |
|                         | `.Should().HaveCountGreaterThan(int)`                |                                                      |
|                         | `.Should().HaveCountLessThanOrEqualTo(int)`          |                                                      |
|                         | `.Should().HaveCountLessOrEqualTo(int)`              |                                                      |
|                         | `.Should().HaveCountLessThan(int)`                   |                                                      |
|                         | `.Should().HaveElementAt(int, string)`               |                                                      |
|                         | `.Should().HaveElementPreceding(string, string)`     |                                                      |
|                         | `.Should().HaveElementSucceeding(string, string)`    |                                                      |
|                         | `.Should().HaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().IntersectWith(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(IComparer<string>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder()`                  |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(IComparer<string>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder()`                 |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().NotBeNullOrEmpty()`                       |                                                      |
|                         | `.Should().NotBeSubsetOf(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotContain(string)`                       |                                                      |
|                         | `.Should().NotContain(Expression<Func<string, bool>>)` |                                                      |
|                         | `.Should().NotContain(IEnumerable<string>)`          |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation)`     |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotContainInOrder(string[])`              |                                                      |
|                         | `.Should().NotContainInOrder(IEnumerable<string>)`   |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(string[])`   |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(IEnumerable<string>)` |                                                      |
|                         | `.Should().NotContainNulls(Expression<Func<string, TKey>>)` |                                                      |
|                         | `.Should().NotContainNulls()`                        |                                                      |
|                         | `.Should().NotEqual(IEnumerable<string>)`            |                                                      |
|                         | `.Should().NotHaveCount(int)`                        |                                                      |
|                         | `.Should().NotHaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotIntersectWith(IEnumerable<string>)`    |                                                      |
|                         | `.Should().OnlyContain(Expression<Func<string, bool>>)` |                                                      |
|                         | `.Should().OnlyHaveUniqueItems(Expression<Func<string, TKey>>)` |                                                      |
|                         | `.Should().OnlyHaveUniqueItems()`                    |                                                      |
|                         | `.Should().AllSatisfy(Action<string>)`               |                                                      |
|                         | `.Should().SatisfyRespectively(Action<string>[])`    |                                                      |
|                         | `.Should().SatisfyRespectively(IEnumerable<Action<string>>)` |                                                      |
|                         | `.Should().Satisfy(Expression<Func<string, bool>>[])` |                                                      |
|                         | `.Should().Satisfy(IEnumerable<Expression<Func<string, bool>>>)` |                                                      |
|                         | `.Should().StartWith(IEnumerable<string>)`           |                                                      |
|                         | `.Should().StartWith(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` |                                                      |
|                         | `.Should().StartWith(string)`                        |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(IEnumerable<string>)`            |                                                      |
|                         | `.Should().NotBeSameAs(IEnumerable<string>)`         |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<IEnumerable<string>, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| StringCollection?       | `.Should().Equal(string[])`                          |                                                      |
|                         | `.Should().Equal(IEnumerable<string>)`               |                                                      |
|                         | `.Should().BeEquivalentTo(string[])`                 |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<string>)`      |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<string>, Func<EquivalencyAssertionOptions<string>, EquivalencyAssertionOptions<string>>)` |                                                      |
|                         | `.Should().AllBe(string)`                            |                                                      |
|                         | `.Should().AllBe(string, Func<EquivalencyAssertionOptions<string>, EquivalencyAssertionOptions<string>>)` |                                                      |
|                         | `.Should().ContainMatch(string)`                     |                                                      |
|                         | `.Should().NotContainMatch(string)`                  |                                                      |
|                         | `.Should().AllBeAssignableTo()`                      |                                                      |
|                         | `.Should().AllBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation)`          |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().AllBeOfType()`                            |                                                      |
|                         | `.Should().AllBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(IComparer<string>)`    |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInAscendingOrder()`                     |                                                      |
|                         | `.Should().BeInAscendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().BeInDescendingOrder(IComparer<string>)`   |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInDescendingOrder()`                    |                                                      |
|                         | `.Should().BeInDescendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().BeNullOrEmpty()`                          |                                                      |
|                         | `.Should().BeSubsetOf(IEnumerable<string>)`          |                                                      |
|                         | `.Should().Contain(string)`                          |                                                      |
|                         | `.Should().Contain(Expression<Func<string, bool>>)`  |                                                      |
|                         | `.Should().Contain(IEnumerable<string>)`             |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation)`        |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().ContainInOrder(string[])`                 |                                                      |
|                         | `.Should().ContainInOrder(IEnumerable<string>)`      |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(string[])`      |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(IEnumerable<string>)` |                                                      |
|                         | `.Should().ContainItemsAssignableTo()`               |                                                      |
|                         | `.Should().NotContainItemsAssignableTo()`            |                                                      |
|                         | `.Should().NotContainItemsAssignableTo(Type)`        |                                                      |
|                         | `.Should().ContainSingle()`                          |                                                      |
|                         | `.Should().ContainSingle(Expression<Func<string, bool>>)` |                                                      |
|                         | `.Should().EndWith(IEnumerable<string>)`             |                                                      |
|                         | `.Should().EndWith(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` |                                                      |
|                         | `.Should().EndWith(string)`                          |                                                      |
|                         | `.Should().Equal(string[])`                          |                                                      |
|                         | `.Should().Equal(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` |                                                      |
|                         | `.Should().Equal(IEnumerable<string>)`               |                                                      |
|                         | `.Should().HaveCount(int)`                           |                                                      |
|                         | `.Should().HaveCount(Expression<Func<int, bool>>)`   |                                                      |
|                         | `.Should().HaveCountGreaterThanOrEqualTo(int)`       |                                                      |
|                         | `.Should().HaveCountGreaterOrEqualTo(int)`           |                                                      |
|                         | `.Should().HaveCountGreaterThan(int)`                |                                                      |
|                         | `.Should().HaveCountLessThanOrEqualTo(int)`          |                                                      |
|                         | `.Should().HaveCountLessOrEqualTo(int)`              |                                                      |
|                         | `.Should().HaveCountLessThan(int)`                   |                                                      |
|                         | `.Should().HaveElementAt(int, string)`               |                                                      |
|                         | `.Should().HaveElementPreceding(string, string)`     |                                                      |
|                         | `.Should().HaveElementSucceeding(string, string)`    |                                                      |
|                         | `.Should().HaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().IntersectWith(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(IComparer<string>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder()`                  |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<string, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(IComparer<string>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<string, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder()`                 |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Func<string, string, int>)` |                                                      |
|                         | `.Should().NotBeNullOrEmpty()`                       |                                                      |
|                         | `.Should().NotBeSubsetOf(IEnumerable<string>)`       |                                                      |
|                         | `.Should().NotContain(string)`                       |                                                      |
|                         | `.Should().NotContain(Expression<Func<string, bool>>)` |                                                      |
|                         | `.Should().NotContain(IEnumerable<string>)`          |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation)`     |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotContainInOrder(string[])`              |                                                      |
|                         | `.Should().NotContainInOrder(IEnumerable<string>)`   |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(string[])`   |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(IEnumerable<string>)` |                                                      |
|                         | `.Should().NotContainNulls(Expression<Func<string, TKey>>)` |                                                      |
|                         | `.Should().NotContainNulls()`                        |                                                      |
|                         | `.Should().NotEqual(IEnumerable<string>)`            |                                                      |
|                         | `.Should().NotHaveCount(int)`                        |                                                      |
|                         | `.Should().NotHaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotIntersectWith(IEnumerable<string>)`    |                                                      |
|                         | `.Should().OnlyContain(Expression<Func<string, bool>>)` |                                                      |
|                         | `.Should().OnlyHaveUniqueItems(Expression<Func<string, TKey>>)` |                                                      |
|                         | `.Should().OnlyHaveUniqueItems()`                    |                                                      |
|                         | `.Should().AllSatisfy(Action<string>)`               |                                                      |
|                         | `.Should().SatisfyRespectively(Action<string>[])`    |                                                      |
|                         | `.Should().SatisfyRespectively(IEnumerable<Action<string>>)` |                                                      |
|                         | `.Should().Satisfy(Expression<Func<string, bool>>[])` |                                                      |
|                         | `.Should().Satisfy(IEnumerable<Expression<Func<string, bool>>>)` |                                                      |
|                         | `.Should().StartWith(IEnumerable<string>)`           |                                                      |
|                         | `.Should().StartWith(IEnumerable<TExpectation>, Func<string, TExpectation, bool>)` |                                                      |
|                         | `.Should().StartWith(string)`                        |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(TCollection)`                    |                                                      |
|                         | `.Should().NotBeSameAs(TCollection)`                 |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<TCollection, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| SubsequentOrdering?     | `.Should().ThenBeInAscendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().ThenBeInAscendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().ThenBeInDescendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().ThenBeInDescendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().AllBeAssignableTo()`                      |                                                      |
|                         | `.Should().AllBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation)`          |                                                      |
|                         | `.Should().AllBeEquivalentTo(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().AllBeOfType()`                            |                                                      |
|                         | `.Should().AllBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeEmpty()`                                |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().BeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().BeInAscendingOrder(IComparer<T>)`         |                                                      |
|                         | `.Should().BeInAscendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInAscendingOrder()`                     |                                                      |
|                         | `.Should().BeInAscendingOrder(Func<T, T, int>)`      |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().BeInDescendingOrder(IComparer<T>)`        |                                                      |
|                         | `.Should().BeInDescendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().BeInDescendingOrder()`                    |                                                      |
|                         | `.Should().BeInDescendingOrder(Func<T, T, int>)`     |                                                      |
|                         | `.Should().BeNullOrEmpty()`                          |                                                      |
|                         | `.Should().BeSubsetOf(IEnumerable<T>)`               |                                                      |
|                         | `.Should().Contain(T)`                               |                                                      |
|                         | `.Should().Contain(Expression<Func<T, bool>>)`       |                                                      |
|                         | `.Should().Contain(IEnumerable<T>)`                  |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation)`        |                                                      |
|                         | `.Should().ContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().ContainInOrder(T[])`                      |                                                      |
|                         | `.Should().ContainInOrder(IEnumerable<T>)`           |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(T[])`           |                                                      |
|                         | `.Should().ContainInConsecutiveOrder(IEnumerable<T>)` |                                                      |
|                         | `.Should().ContainItemsAssignableTo()`               |                                                      |
|                         | `.Should().NotContainItemsAssignableTo()`            |                                                      |
|                         | `.Should().NotContainItemsAssignableTo(Type)`        |                                                      |
|                         | `.Should().ContainSingle()`                          |                                                      |
|                         | `.Should().ContainSingle(Expression<Func<T, bool>>)` |                                                      |
|                         | `.Should().EndWith(IEnumerable<T>)`                  |                                                      |
|                         | `.Should().EndWith(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` |                                                      |
|                         | `.Should().EndWith(T)`                               |                                                      |
|                         | `.Should().Equal(T[])`                               |                                                      |
|                         | `.Should().Equal(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` |                                                      |
|                         | `.Should().Equal(IEnumerable<T>)`                    |                                                      |
|                         | `.Should().HaveCount(int)`                           |                                                      |
|                         | `.Should().HaveCount(Expression<Func<int, bool>>)`   |                                                      |
|                         | `.Should().HaveCountGreaterThanOrEqualTo(int)`       |                                                      |
|                         | `.Should().HaveCountGreaterOrEqualTo(int)`           |                                                      |
|                         | `.Should().HaveCountGreaterThan(int)`                |                                                      |
|                         | `.Should().HaveCountLessThanOrEqualTo(int)`          |                                                      |
|                         | `.Should().HaveCountLessOrEqualTo(int)`              |                                                      |
|                         | `.Should().HaveCountLessThan(int)`                   |                                                      |
|                         | `.Should().HaveElementAt(int, T)`                    |                                                      |
|                         | `.Should().HaveElementPreceding(T, T)`               |                                                      |
|                         | `.Should().HaveElementSucceeding(T, T)`              |                                                      |
|                         | `.Should().HaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().IntersectWith(IEnumerable<T>)`            |                                                      |
|                         | `.Should().NotBeEmpty()`                             |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotBeEquivalentTo(IEnumerable<TExpectation>, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder(IComparer<T>)`      |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInAscendingOrder()`                  |                                                      |
|                         | `.Should().NotBeInAscendingOrder(Func<T, T, int>)`   |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<T, TSelector>>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder(IComparer<T>)`     |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Expression<Func<T, TSelector>>, IComparer<TSelector>)` |                                                      |
|                         | `.Should().NotBeInDescendingOrder()`                 |                                                      |
|                         | `.Should().NotBeInDescendingOrder(Func<T, T, int>)`  |                                                      |
|                         | `.Should().NotBeNullOrEmpty()`                       |                                                      |
|                         | `.Should().NotBeSubsetOf(IEnumerable<T>)`            |                                                      |
|                         | `.Should().NotContain(T)`                            |                                                      |
|                         | `.Should().NotContain(Expression<Func<T, bool>>)`    |                                                      |
|                         | `.Should().NotContain(IEnumerable<T>)`               |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation)`     |                                                      |
|                         | `.Should().NotContainEquivalentOf(TExpectation, Func<EquivalencyAssertionOptions<TExpectation>, EquivalencyAssertionOptions<TExpectation>>)` |                                                      |
|                         | `.Should().NotContainInOrder(T[])`                   |                                                      |
|                         | `.Should().NotContainInOrder(IEnumerable<T>)`        |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(T[])`        |                                                      |
|                         | `.Should().NotContainInConsecutiveOrder(IEnumerable<T>)` |                                                      |
|                         | `.Should().NotContainNulls(Expression<Func<T, TKey>>)` |                                                      |
|                         | `.Should().NotContainNulls()`                        |                                                      |
|                         | `.Should().NotEqual(IEnumerable<T>)`                 |                                                      |
|                         | `.Should().NotHaveCount(int)`                        |                                                      |
|                         | `.Should().NotHaveSameCount(IEnumerable<TExpectation>)` |                                                      |
|                         | `.Should().NotIntersectWith(IEnumerable<T>)`         |                                                      |
|                         | `.Should().OnlyContain(Expression<Func<T, bool>>)`   |                                                      |
|                         | `.Should().OnlyHaveUniqueItems(Expression<Func<T, TKey>>)` |                                                      |
|                         | `.Should().OnlyHaveUniqueItems()`                    |                                                      |
|                         | `.Should().AllSatisfy(Action<T>)`                    |                                                      |
|                         | `.Should().SatisfyRespectively(Action<T>[])`         |                                                      |
|                         | `.Should().SatisfyRespectively(IEnumerable<Action<T>>)` |                                                      |
|                         | `.Should().Satisfy(Expression<Func<T, bool>>[])`     |                                                      |
|                         | `.Should().Satisfy(IEnumerable<Expression<Func<T, bool>>>)` |                                                      |
|                         | `.Should().StartWith(IEnumerable<T>)`                |                                                      |
|                         | `.Should().StartWith(IEnumerable<TExpectation>, Func<T, TExpectation, bool>)` |                                                      |
|                         | `.Should().StartWith(T)`                             |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(IEnumerable<T>)`                 |                                                      |
|                         | `.Should().NotBeSameAs(IEnumerable<T>)`              |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<IEnumerable<T>, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| TaskCompletionSource    | `.Should().CompleteWithinAsync(TimeSpan)`            |                                                      |
|                         | `.Should().NotCompleteWithinAsync(TimeSpan)`         |                                                      |
| TaskCompletionSource?   | `.Should().CompleteWithinAsync(TimeSpan)`            |                                                      |
|                         | `.Should().NotCompleteWithinAsync(TimeSpan)`         |                                                      |
| TimeOnly                | `.Should().Be(TimeOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<TimeOnly>)`                   |                                                      |
|                         | `.Should().NotBe(TimeOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<TimeOnly>)`                |                                                      |
|                         | `.Should().BeCloseTo(TimeOnly, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeOnly, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(TimeOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(TimeOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(TimeOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(TimeOnly)`                |                                                      |
|                         | `.Should().BeAfter(TimeOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(TimeOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(TimeOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(TimeOnly)`                 |                                                      |
|                         | `.Should().HaveHours(int)`                           |                                                      |
|                         | `.Should().NotHaveHours(int)`                        |                                                      |
|                         | `.Should().HaveMinutes(int)`                         |                                                      |
|                         | `.Should().NotHaveMinutes(int)`                      |                                                      |
|                         | `.Should().HaveSeconds(int)`                         |                                                      |
|                         | `.Should().NotHaveSeconds(int)`                      |                                                      |
|                         | `.Should().HaveMilliseconds(int)`                    |                                                      |
|                         | `.Should().NotHaveMilliseconds(int)`                 |                                                      |
|                         | `.Should().BeOneOf(Nullable<TimeOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(TimeOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<TimeOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<TimeOnly>>)` |                                                      |
| TimeOnly?               | `.Should().Be(TimeOnly)`                             |                                                      |
|                         | `.Should().Be(Nullable<TimeOnly>)`                   |                                                      |
|                         | `.Should().NotBe(TimeOnly)`                          |                                                      |
|                         | `.Should().NotBe(Nullable<TimeOnly>)`                |                                                      |
|                         | `.Should().BeCloseTo(TimeOnly, TimeSpan)`            |                                                      |
|                         | `.Should().NotBeCloseTo(TimeOnly, TimeSpan)`         |                                                      |
|                         | `.Should().BeBefore(TimeOnly)`                       |                                                      |
|                         | `.Should().NotBeBefore(TimeOnly)`                    |                                                      |
|                         | `.Should().BeOnOrBefore(TimeOnly)`                   |                                                      |
|                         | `.Should().NotBeOnOrBefore(TimeOnly)`                |                                                      |
|                         | `.Should().BeAfter(TimeOnly)`                        |                                                      |
|                         | `.Should().NotBeAfter(TimeOnly)`                     |                                                      |
|                         | `.Should().BeOnOrAfter(TimeOnly)`                    |                                                      |
|                         | `.Should().NotBeOnOrAfter(TimeOnly)`                 |                                                      |
|                         | `.Should().HaveHours(int)`                           |                                                      |
|                         | `.Should().NotHaveHours(int)`                        |                                                      |
|                         | `.Should().HaveMinutes(int)`                         |                                                      |
|                         | `.Should().NotHaveMinutes(int)`                      |                                                      |
|                         | `.Should().HaveSeconds(int)`                         |                                                      |
|                         | `.Should().NotHaveSeconds(int)`                      |                                                      |
|                         | `.Should().HaveMilliseconds(int)`                    |                                                      |
|                         | `.Should().NotHaveMilliseconds(int)`                 |                                                      |
|                         | `.Should().BeOneOf(Nullable<TimeOnly>[])`            |                                                      |
|                         | `.Should().BeOneOf(TimeOnly[])`                      |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<TimeOnly>)`           |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<Nullable<TimeOnly>>)` |                                                      |
| Type                    | `.Should().Be()`                                     |                                                      |
|                         | `.Should().Be(Type)`                                 |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().NotBe()`                                  |                                                      |
|                         | `.Should().NotBe(Type)`                              |                                                      |
|                         | `.Should().BeDecoratedWith()`                        |                                                      |
|                         | `.Should().BeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().BeDecoratedWithOrInherit()`               |                                                      |
|                         | `.Should().BeDecoratedWithOrInherit(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWith()`                     |                                                      |
|                         | `.Should().NotBeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWithOrInherit()`            |                                                      |
|                         | `.Should().NotBeDecoratedWithOrInherit(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().Implement(Type)`                          |                                                      |
|                         | `.Should().Implement()`                              |                                                      |
|                         | `.Should().NotImplement(Type)`                       |                                                      |
|                         | `.Should().NotImplement()`                           |                                                      |
|                         | `.Should().BeDerivedFrom(Type)`                      |                                                      |
|                         | `.Should().BeDerivedFrom()`                          |                                                      |
|                         | `.Should().NotBeDerivedFrom(Type)`                   |                                                      |
|                         | `.Should().NotBeDerivedFrom()`                       |                                                      |
|                         | `.Should().BeSealed()`                               |                                                      |
|                         | `.Should().NotBeSealed()`                            |                                                      |
|                         | `.Should().BeAbstract()`                             |                                                      |
|                         | `.Should().NotBeAbstract()`                          |                                                      |
|                         | `.Should().BeStatic()`                               |                                                      |
|                         | `.Should().NotBeStatic()`                            |                                                      |
|                         | `.Should().HaveProperty(Type, string)`               |                                                      |
|                         | `.Should().HaveProperty(string)`                     |                                                      |
|                         | `.Should().NotHaveProperty(string)`                  |                                                      |
|                         | `.Should().HaveExplicitProperty(Type, string)`       |                                                      |
|                         | `.Should().HaveExplicitProperty(string)`             |                                                      |
|                         | `.Should().NotHaveExplicitProperty(Type, string)`    |                                                      |
|                         | `.Should().NotHaveExplicitProperty(string)`          |                                                      |
|                         | `.Should().HaveExplicitMethod(Type, string, IEnumerable<Type>)` |                                                      |
|                         | `.Should().HaveExplicitMethod(string, IEnumerable<Type>)` |                                                      |
|                         | `.Should().NotHaveExplicitMethod(Type, string, IEnumerable<Type>)` |                                                      |
|                         | `.Should().NotHaveExplicitMethod(string, IEnumerable<Type>)` |                                                      |
|                         | `.Should().HaveIndexer(Type, IEnumerable<Type>)`     |                                                      |
|                         | `.Should().NotHaveIndexer(IEnumerable<Type>)`        |                                                      |
|                         | `.Should().HaveMethod(string, IEnumerable<Type>)`    |                                                      |
|                         | `.Should().NotHaveMethod(string, IEnumerable<Type>)` |                                                      |
|                         | `.Should().HaveConstructor(IEnumerable<Type>)`       |                                                      |
|                         | `.Should().HaveDefaultConstructor()`                 |                                                      |
|                         | `.Should().NotHaveConstructor(IEnumerable<Type>)`    |                                                      |
|                         | `.Should().NotHaveDefaultConstructor()`              |                                                      |
|                         | `.Should().HaveAccessModifier(CSharpAccessModifier)` |                                                      |
|                         | `.Should().NotHaveAccessModifier(CSharpAccessModifier)` |                                                      |
|                         | `.Should().HaveImplicitConversionOperator()`         |                                                      |
|                         | `.Should().HaveImplicitConversionOperator(Type, Type)` |                                                      |
|                         | `.Should().NotHaveImplicitConversionOperator()`      |                                                      |
|                         | `.Should().NotHaveImplicitConversionOperator(Type, Type)` |                                                      |
|                         | `.Should().HaveExplicitConversionOperator()`         |                                                      |
|                         | `.Should().HaveExplicitConversionOperator(Type, Type)` |                                                      |
|                         | `.Should().NotHaveExplicitConversionOperator()`      |                                                      |
|                         | `.Should().NotHaveExplicitConversionOperator(Type, Type)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(Type)`                           |                                                      |
|                         | `.Should().NotBeSameAs(Type)`                        |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<Type, bool>>)`      |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| TypeSelector            | `.Should().BeDecoratedWith()`                        |                                                      |
|                         | `.Should().BeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().BeDecoratedWithOrInherit()`               |                                                      |
|                         | `.Should().BeDecoratedWithOrInherit(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWith()`                     |                                                      |
|                         | `.Should().NotBeDecoratedWith(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().NotBeDecoratedWithOrInherit()`            |                                                      |
|                         | `.Should().NotBeDecoratedWithOrInherit(Expression<Func<TAttribute, bool>>)` |                                                      |
|                         | `.Should().BeSealed()`                               |                                                      |
|                         | `.Should().NotBeSealed()`                            |                                                      |
|                         | `.Should().BeInNamespace(string)`                    |                                                      |
|                         | `.Should().NotBeInNamespace(string)`                 |                                                      |
|                         | `.Should().BeUnderNamespace(string)`                 |                                                      |
|                         | `.Should().NotBeUnderNamespace(string)`              |                                                      |
| UInt16                  | `.Should().Be(ushort)`                               |                                                      |
|                         | `.Should().Be(ushort?)`                              |                                                      |
|                         | `.Should().NotBe(ushort)`                            |                                                      |
|                         | `.Should().NotBe(ushort?)`                           |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(ushort)`                       |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(ushort)`              |                                                      |
|                         | `.Should().BeLessOrEqualTo(ushort)`                  |                                                      |
|                         | `.Should().BeGreaterThan(ushort)`                    |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(ushort)`           |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(ushort)`               |                                                      |
|                         | `.Should().BeInRange(ushort, ushort)`                |                                                      |
|                         | `.Should().NotBeInRange(ushort, ushort)`             |                                                      |
|                         | `.Should().BeOneOf(ushort[])`                        |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<ushort>)`             |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<ushort, bool>>)`    |                                                      |
| UInt32                  | `.Should().Be(uint)`                                 |                                                      |
|                         | `.Should().Be(uint?)`                                |                                                      |
|                         | `.Should().NotBe(uint)`                              |                                                      |
|                         | `.Should().NotBe(uint?)`                             |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(uint)`                         |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(uint)`                |                                                      |
|                         | `.Should().BeLessOrEqualTo(uint)`                    |                                                      |
|                         | `.Should().BeGreaterThan(uint)`                      |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(uint)`             |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(uint)`                 |                                                      |
|                         | `.Should().BeInRange(uint, uint)`                    |                                                      |
|                         | `.Should().NotBeInRange(uint, uint)`                 |                                                      |
|                         | `.Should().BeOneOf(uint[])`                          |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<uint>)`               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<uint, bool>>)`      |                                                      |
| UInt64                  | `.Should().Be(ulong)`                                |                                                      |
|                         | `.Should().Be(ulong?)`                               |                                                      |
|                         | `.Should().NotBe(ulong)`                             |                                                      |
|                         | `.Should().NotBe(ulong?)`                            |                                                      |
|                         | `.Should().BePositive()`                             |                                                      |
|                         | `.Should().BeNegative()`                             |                                                      |
|                         | `.Should().BeLessThan(ulong)`                        |                                                      |
|                         | `.Should().BeLessThanOrEqualTo(ulong)`               |                                                      |
|                         | `.Should().BeLessOrEqualTo(ulong)`                   |                                                      |
|                         | `.Should().BeGreaterThan(ulong)`                     |                                                      |
|                         | `.Should().BeGreaterThanOrEqualTo(ulong)`            |                                                      |
|                         | `.Should().BeGreaterOrEqualTo(ulong)`                |                                                      |
|                         | `.Should().BeInRange(ulong, ulong)`                  |                                                      |
|                         | `.Should().NotBeInRange(ulong, ulong)`               |                                                      |
|                         | `.Should().BeOneOf(ulong[])`                         |                                                      |
|                         | `.Should().BeOneOf(IEnumerable<ulong>)`              |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().Match(Expression<Func<ulong, bool>>)`     |                                                      |
| XAttribute              | `.Should().Be(XAttribute)`                           |                                                      |
|                         | `.Should().NotBe(XAttribute)`                        |                                                      |
|                         | `.Should().HaveValue(string)`                        |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(XAttribute)`                     |                                                      |
|                         | `.Should().NotBeSameAs(XAttribute)`                  |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<XAttribute, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| XDocument               | `.Should().Be(XDocument)`                            |                                                      |
|                         | `.Should().NotBe(XDocument)`                         |                                                      |
|                         | `.Should().BeEquivalentTo(XDocument)`                |                                                      |
|                         | `.Should().NotBeEquivalentTo(XDocument)`             |                                                      |
|                         | `.Should().HaveRoot(string)`                         |                                                      |
|                         | `.Should().HaveRoot(XName)`                          |                                                      |
|                         | `.Should().HaveElement(string)`                      |                                                      |
|                         | `.Should().HaveElement(string, OccurrenceConstraint)` |                                                      |
|                         | `.Should().HaveElement(XName)`                       |                                                      |
|                         | `.Should().HaveElement(XName, OccurrenceConstraint)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(XDocument)`                      |                                                      |
|                         | `.Should().NotBeSameAs(XDocument)`                   |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<XDocument, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| XElement                | `.Should().Be(XElement)`                             |                                                      |
|                         | `.Should().NotBe(XElement)`                          |                                                      |
|                         | `.Should().BeEquivalentTo(XElement)`                 |                                                      |
|                         | `.Should().NotBeEquivalentTo(XElement)`              |                                                      |
|                         | `.Should().HaveValue(string)`                        |                                                      |
|                         | `.Should().HaveAttribute(string, string)`            |                                                      |
|                         | `.Should().HaveAttribute(XName, string)`             |                                                      |
|                         | `.Should().HaveElement(string)`                      |                                                      |
|                         | `.Should().HaveElement(XName)`                       |                                                      |
|                         | `.Should().HaveElement(XName, OccurrenceConstraint)` |                                                      |
|                         | `.Should().HaveElement(string, OccurrenceConstraint)` |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(XElement)`                       |                                                      |
|                         | `.Should().NotBeSameAs(XElement)`                    |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<XElement, bool>>)`  |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| XmlElement              | `.Should().HaveInnerText(string)`                    |                                                      |
|                         | `.Should().HaveAttribute(string, string)`            |                                                      |
|                         | `.Should().HaveAttributeWithNamespace(string, string, string)` |                                                      |
|                         | `.Should().HaveElement(string)`                      |                                                      |
|                         | `.Should().HaveElementWithNamespace(string, string)` |                                                      |
|                         | `.Should().BeEquivalentTo(XmlNode)`                  |                                                      |
|                         | `.Should().NotBeEquivalentTo(XmlNode)`               |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(XmlElement)`                     |                                                      |
|                         | `.Should().NotBeSameAs(XmlElement)`                  |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<XmlElement, bool>>)` |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
| XmlNode                 | `.Should().BeEquivalentTo(XmlNode)`                  |                                                      |
|                         | `.Should().NotBeEquivalentTo(XmlNode)`               |                                                      |
|                         | `.Should().BeNull()`                                 |                                                      |
|                         | `.Should().NotBeNull()`                              |                                                      |
|                         | `.Should().BeSameAs(XmlNode)`                        |                                                      |
|                         | `.Should().NotBeSameAs(XmlNode)`                     |                                                      |
|                         | `.Should().BeOfType()`                               |                                                      |
|                         | `.Should().BeOfType(Type)`                           |                                                      |
|                         | `.Should().NotBeOfType()`                            |                                                      |
|                         | `.Should().NotBeOfType(Type)`                        |                                                      |
|                         | `.Should().BeAssignableTo()`                         |                                                      |
|                         | `.Should().BeAssignableTo(Type)`                     |                                                      |
|                         | `.Should().NotBeAssignableTo()`                      |                                                      |
|                         | `.Should().NotBeAssignableTo(Type)`                  |                                                      |
|                         | `.Should().Match(Expression<Func<XmlNode, bool>>)`   |                                                      |
|                         | `.Should().Match(Expression<Func<T, bool>>)`         |                                                      |
