window.BENCHMARK_DATA = {
  "lastUpdate": 1731261594173,
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
          "id": "73a0a6b2e695a040116fc421a3cde618908bdcf1",
          "message": "refactor: make chronology tests more resilient (#152)\n\nMake Chronology-Tests more resilient by adjusting min-max values of\r\nrandom current time to allow +/- 100 seconds (days) to be a valid value",
          "timestamp": "2024-11-10T14:03:53Z",
          "tree_id": "96287d5de77a996ce1cdf61a928d39d4648ece00",
          "url": "https://github.com/Testably/Testably.Expectations/commit/73a0a6b2e695a040116fc421a3cde618908bdcf1"
        },
        "date": 1731247633378,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 224.43843685663663,
            "unit": "ns",
            "range": "± 0.9345790027157462"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 292.308470694224,
            "unit": "ns",
            "range": "± 2.4638372765151053"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 650.4342516581218,
            "unit": "ns",
            "range": "± 6.050968907664431"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 403.79427777017867,
            "unit": "ns",
            "range": "± 1.1080549765914078"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 447.2884476001446,
            "unit": "ns",
            "range": "± 2.7409025463825003"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1434.351681436811,
            "unit": "ns",
            "range": "± 8.93975378025529"
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
          "id": "04a9795ad43498a480332a1409e6d697a250691f",
          "message": "feat: Add workflow for github pages (#153)",
          "timestamp": "2024-11-10T14:16:51Z",
          "tree_id": "1ab3a4cdb4e24d76cae6e3e60c62d1ce7f8d91d8",
          "url": "https://github.com/Testably/Testably.Expectations/commit/04a9795ad43498a480332a1409e6d697a250691f"
        },
        "date": 1731248403363,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 216.46007132530212,
            "unit": "ns",
            "range": "± 1.3224365529877649"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 284.57064822514855,
            "unit": "ns",
            "range": "± 2.5388069569838216"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 631.8529075895037,
            "unit": "ns",
            "range": "± 3.630213696092942"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 386.3392347971598,
            "unit": "ns",
            "range": "± 1.7363159762152305"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 440.9900715192159,
            "unit": "ns",
            "range": "± 2.9611957094779924"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1386.7418332417806,
            "unit": "ns",
            "range": "± 10.945158104530364"
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
          "id": "1aaca7885876b26244830eab4dbc177c57b309b5",
          "message": "refactor: separate expectations and tests in Chronology to their respective types (#154)\n\nMove the expectations and tests under `Chronology` to their respective\r\ntypes. This affects:\r\n- DateTimes\r\n- DateTimeOffsets\r\n- DateOnlys\r\n- TimeOnlys\r\n- TimeSpans",
          "timestamp": "2024-11-10T16:04:32Z",
          "tree_id": "b317949549092bfd580f051e1871e367ae880ff2",
          "url": "https://github.com/Testably/Testably.Expectations/commit/1aaca7885876b26244830eab4dbc177c57b309b5"
        },
        "date": 1731254871015,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 216.72207025119238,
            "unit": "ns",
            "range": "± 1.1580089025899505"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 288.9929835796356,
            "unit": "ns",
            "range": "± 1.0541912406379452"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 644.4516975696271,
            "unit": "ns",
            "range": "± 2.703445356688473"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 389.57822058995566,
            "unit": "ns",
            "range": "± 1.9400942176669025"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 435.29317934172497,
            "unit": "ns",
            "range": "± 0.764834763495559"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1418.9397478103638,
            "unit": "ns",
            "range": "± 7.880048282000287"
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
          "id": "0f42c1497bf4539d14f27d11c122be39098dfcb1",
          "message": "feat: add `EditorBrowsable` attribute (#155)\n\nExclude `Equals`, `GetHashCode`, `ToString()`, ... from IntelliSense via\r\nthe\r\n[`EditorBrowsable`](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.editorbrowsableattribute?view=net-8.0)\r\nattribute.",
          "timestamp": "2024-11-10T17:56:34Z",
          "tree_id": "8f409ee6717041cf4b1ea81d05dd83abcea80667",
          "url": "https://github.com/Testably/Testably.Expectations/commit/0f42c1497bf4539d14f27d11c122be39098dfcb1"
        },
        "date": 1731261593609,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 220.7546913964408,
            "unit": "ns",
            "range": "± 1.5986074895835443"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 283.0423843065898,
            "unit": "ns",
            "range": "± 0.8866866603560025"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 635.3028348286947,
            "unit": "ns",
            "range": "± 1.5456776976335178"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 394.8485062462943,
            "unit": "ns",
            "range": "± 1.5713895946307697"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 438.8522559483846,
            "unit": "ns",
            "range": "± 3.3113918977091616"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1401.9338188171387,
            "unit": "ns",
            "range": "± 8.363523236401408"
          }
        ]
      }
    ]
  }
}