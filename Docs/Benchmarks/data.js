window.BENCHMARK_DATA = {
  "lastUpdate": 1731233720406,
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
      }
    ]
  }
}