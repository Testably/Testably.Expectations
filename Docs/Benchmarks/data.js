window.BENCHMARK_DATA = {
  "lastUpdate": 1731245318378,
  "repoUrl": "https://github.com/Testably/Testably.Expectations",
  "entries": {
    "Benchmark.Net Benchmark": [
      {
        "commit": {
          "author": {
            "name": "Valentin Breuß",
            "username": "vbreuss",
            "email": "vbreuss@gmail.com"
          },
          "committer": {
            "name": "GitHub",
            "username": "web-flow",
            "email": "noreply@github.com"
          },
          "id": "f161f267486dbd4e645c4fda8c137686b9113772",
          "message": "Update build.yml",
          "timestamp": "2024-11-10T10:10:22Z",
          "url": "https://github.com/Testably/Testably.Expectations/commit/f161f267486dbd4e645c4fda8c137686b9113772"
        },
        "date": 1731233719633,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 223.71290619032723,
            "unit": "ns",
            "range": "± 0.9824994791885284"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 293.10680683453876,
            "unit": "ns",
            "range": "± 1.0800133745774851"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 646.4990128835042,
            "unit": "ns",
            "range": "± 2.459467255687573"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 404.90180892944335,
            "unit": "ns",
            "range": "± 2.780572939295524"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 446.45077065059115,
            "unit": "ns",
            "range": "± 1.4857544364505064"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1355.23776108878,
            "unit": "ns",
            "range": "± 10.779287028811426"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "vbreuss@gmail.com",
            "name": "Valentin Breuß",
            "username": "vbreuss"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "372d9673affeb0e12faca6e1c4b2ebd2a8c2446d",
          "message": "feat: add initial benchmark project (#149)\n\nFrom #147:\nAdd initial benchmarks for comparison between `TUnit.Assertions`,\n`FluentAssertions` and this project:\n- Happy Case for string should be equal\n- Happy Case for bool should be true",
          "timestamp": "2024-11-10T11:23:45+01:00",
          "tree_id": "4bcdabd6b8a04ba093b75a735bbeaa5028e8e741",
          "url": "https://github.com/Testably/Testably.Expectations/commit/372d9673affeb0e12faca6e1c4b2ebd2a8c2446d"
        },
        "date": 1731234426740,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 220.91200603757585,
            "unit": "ns",
            "range": "± 1.6673221741150637"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 287.3064190864563,
            "unit": "ns",
            "range": "± 1.8987624217673886"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 657.3793855813833,
            "unit": "ns",
            "range": "± 2.017588380190715"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 391.971413675944,
            "unit": "ns",
            "range": "± 2.2096639792726607"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 438.5044598238809,
            "unit": "ns",
            "range": "± 1.5135455385680785"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1396.38973903656,
            "unit": "ns",
            "range": "± 6.76543995059669"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "vbreuss@gmail.com",
            "name": "Valentin Breuß",
            "username": "vbreuss"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "fcea0df51d34eaf0896efaf1b77746d3a6f9f64d",
          "message": "feat: add `TimeOnly` expectation (#150)\n\nFrom #127:\r\nAdd `TimeOnly` expectations:\r\n- `BeAfter` / `NotBeAfter`\r\n- `BeOnOrAfter` / `NotBeOnOrAfter`\r\n- `BeBefore` / `NotBeBefore`\r\n- `BeOnOrBefore` / `NotBeOnOrBefore`",
          "timestamp": "2024-11-10T11:00:24Z",
          "tree_id": "56512c8efb26c65a3705dd8962ba2ae60489583e",
          "url": "https://github.com/Testably/Testably.Expectations/commit/fcea0df51d34eaf0896efaf1b77746d3a6f9f64d"
        },
        "date": 1731236636838,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 221.24531308809915,
            "unit": "ns",
            "range": "± 2.7567662285223835"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 290.2114628278292,
            "unit": "ns",
            "range": "± 1.38390463018621"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 656.8612679072788,
            "unit": "ns",
            "range": "± 5.822501986901396"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 411.2567177500044,
            "unit": "ns",
            "range": "± 3.2486096660092723"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 447.9265311559041,
            "unit": "ns",
            "range": "± 5.013208854186453"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1355.0822670800346,
            "unit": "ns",
            "range": "± 9.529984021371916"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "vbreuss@gmail.com",
            "name": "Valentin Breuß",
            "username": "vbreuss"
          },
          "committer": {
            "email": "noreply@github.com",
            "name": "GitHub",
            "username": "web-flow"
          },
          "distinct": true,
          "id": "bb7c1007414be398350ea5ac3a1d0a1a5f0c0370",
          "message": "refactor: consolidate `#if` statements (#151)\n\nConsolidate the `#if` statements to only use positive statements.\nAdd test for `Expect.Should()` with expectationbuilder callback",
          "timestamp": "2024-11-10T13:25:06Z",
          "tree_id": "7a3e71b93711f6d9c5d862a50b6cee7db698ea3e",
          "url": "https://github.com/Testably/Testably.Expectations/commit/bb7c1007414be398350ea5ac3a1d0a1a5f0c0370"
        },
        "date": 1731245317670,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 231.95924600533075,
            "unit": "ns",
            "range": "± 2.009931400826811"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 309.1715818132673,
            "unit": "ns",
            "range": "± 3.4751504840649656"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 670.4935470727773,
            "unit": "ns",
            "range": "± 3.399065626447531"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 409.7361055374146,
            "unit": "ns",
            "range": "± 6.891673280914807"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 449.8361392974854,
            "unit": "ns",
            "range": "± 3.3563971734779092"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1396.362138748169,
            "unit": "ns",
            "range": "± 7.339711269690868"
          }
        ]
      }
    ]
  }
}