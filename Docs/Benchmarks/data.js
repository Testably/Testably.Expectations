window.BENCHMARK_DATA = {
  "lastUpdate": 1731519136866,
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
        "date": 1731264248904,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 233.62158036231995,
            "unit": "ns",
            "range": "± 1.05900778647767"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 298.9362648010254,
            "unit": "ns",
            "range": "± 2.1146670716291016"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 656.9032852808634,
            "unit": "ns",
            "range": "± 5.569730610098333"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 419.9620007106236,
            "unit": "ns",
            "range": "± 3.029939867418661"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 454.4908361117045,
            "unit": "ns",
            "range": "± 2.590958323166978"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1386.6543276860164,
            "unit": "ns",
            "range": "± 14.150717333218816"
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
          "id": "b2092af98504ef23635a8dce8b5424925d7c5053",
          "message": "feat: add support for nullable `DateTimeOffset` (#157)\n\nSupport nullable `DateTimeOffset` with the `Be` method",
          "timestamp": "2024-11-12T14:48:56Z",
          "tree_id": "ccb2017e31325f0bd9be761c4e8ab404f588bbfd",
          "url": "https://github.com/Testably/Testably.Expectations/commit/b2092af98504ef23635a8dce8b5424925d7c5053"
        },
        "date": 1731423133826,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 226.72857233456202,
            "unit": "ns",
            "range": "± 1.8332837540218576"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 293.8473629951477,
            "unit": "ns",
            "range": "± 2.5392937672265554"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 663.0240126291911,
            "unit": "ns",
            "range": "± 5.848658211248516"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 404.99270076018115,
            "unit": "ns",
            "range": "± 2.694549927127409"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 481.8928180422102,
            "unit": "ns",
            "range": "± 3.679040222960862"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1389.2814937319074,
            "unit": "ns",
            "range": "± 10.298525390392117"
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
          "id": "917e22276ef7a6edd15ac0a3b65ddb97ef8f054d",
          "message": "docs: add link to benchmarks in readme (#158)\n\nAdd a link to the benchmark page in the README.md.",
          "timestamp": "2024-11-12T16:09:11+01:00",
          "tree_id": "781f0967e7e6ec9427b7975445bde0144020af81",
          "url": "https://github.com/Testably/Testably.Expectations/commit/917e22276ef7a6edd15ac0a3b65ddb97ef8f054d"
        },
        "date": 1731424373335,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 227.77836092880793,
            "unit": "ns",
            "range": "± 2.1592757750130773"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 315.20230801900226,
            "unit": "ns",
            "range": "± 1.3527706019479002"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 645.7986221313477,
            "unit": "ns",
            "range": "± 3.774623254360758"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 416.2192128499349,
            "unit": "ns",
            "range": "± 2.8192670558064177"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 447.3453282356262,
            "unit": "ns",
            "range": "± 3.211755590066838"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1353.339626566569,
            "unit": "ns",
            "range": "± 9.252369462216903"
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
          "id": "ca1a84365295428b139b60c2a77a2d8cc567dee8",
          "message": "feat: add `BeAfter`/`BeBefore` for `DateTimeOffset` (#159)\n\nfrom #129 \r\nAdd the following expectations for `DateTimeOffset`:\r\n- `BeAfter` / `NotBeAfter`\r\n- `BeBefore` / `NotBeBefore`\r\n- `BeOnOrAfter` / `NotBeOnOrAfter`\r\n- `BeOnOrBefore` / `NotBeOnOrBefore`",
          "timestamp": "2024-11-12T21:50:40+01:00",
          "tree_id": "93945dfa7ace7b1d75ca91a40c6ae188e78378d4",
          "url": "https://github.com/Testably/Testably.Expectations/commit/ca1a84365295428b139b60c2a77a2d8cc567dee8"
        },
        "date": 1731444855379,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 221.4791898557118,
            "unit": "ns",
            "range": "± 1.4948364989355416"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 294.70770638783773,
            "unit": "ns",
            "range": "± 0.697049865646878"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 659.6057526906332,
            "unit": "ns",
            "range": "± 3.158920204838963"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 408.0745369706835,
            "unit": "ns",
            "range": "± 3.0217100818199536"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 464.6016073593727,
            "unit": "ns",
            "range": "± 2.6284276165390876"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1385.073644365583,
            "unit": "ns",
            "range": "± 6.600621095593919"
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
          "id": "5610a0464f73e320374c006574eb59bde93e0843",
          "message": "feat: add `HaveHour`, `HaveMinute`, `HaveSecond` and `HaveMillisecond` for `TimeOnly` (#160)\n\nFrom #127\r\nAdd the following expectations for `TimeOnly`:\r\n- `HaveHour` / `NotHaveHour`\r\n- `HaveMinute` / `NotHaveMinute`\r\n- `HaveSecond` / `NotHaveSecond`\r\n- `HaveMilliseconds` / `NotHaveMilliseconds`",
          "timestamp": "2024-11-12T21:17:45Z",
          "tree_id": "091e11b3cd1ba771596fe70621fc19dfbb33f6fe",
          "url": "https://github.com/Testably/Testably.Expectations/commit/5610a0464f73e320374c006574eb59bde93e0843"
        },
        "date": 1731446478645,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 214.94696274825506,
            "unit": "ns",
            "range": "± 2.020114838166824"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 283.4445134162903,
            "unit": "ns",
            "range": "± 2.260906417998972"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 645.6803504943848,
            "unit": "ns",
            "range": "± 3.9873336401091084"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 395.1602522986276,
            "unit": "ns",
            "range": "± 3.009594144936853"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 444.192113049825,
            "unit": "ns",
            "range": "± 1.3048804047477256"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1472.8937675476075,
            "unit": "ns",
            "range": "± 10.219067944030963"
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
          "id": "3bf7cd352e31230bdd42dd389953f4c1e87d40c1",
          "message": "fix: tolerance for `NotBeAfter.Within`/`NotBeBefore.Within` (#161)\n\nThe tolerance for\r\n`NotBeAfter`/`NotBeBefore`/`NotBeOnOrAfter`/`NotBeOnOrBefore` is not\r\napplied correctly for `DateOnly` and `TimeOnly`.",
          "timestamp": "2024-11-13T08:48:30Z",
          "tree_id": "f09eaf58d0d84996fbfef528ef7a83be2d63ad0d",
          "url": "https://github.com/Testably/Testably.Expectations/commit/3bf7cd352e31230bdd42dd389953f4c1e87d40c1"
        },
        "date": 1731487918094,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 212.83286545826837,
            "unit": "ns",
            "range": "± 1.987063116119944"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 286.1541848182678,
            "unit": "ns",
            "range": "± 0.6103587652700636"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 624.3998407217173,
            "unit": "ns",
            "range": "± 2.2554885581593886"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 395.4768909386226,
            "unit": "ns",
            "range": "± 3.71923301138482"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 433.5152122633798,
            "unit": "ns",
            "range": "± 2.0986990654166453"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1443.6281449635824,
            "unit": "ns",
            "range": "± 7.26617561797841"
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
          "id": "111637b4c65a733cf3fbfec63ce0107c81f6cd2b",
          "message": "feat: add property expectations for DateOnly (#162)\n\nAdd property expectations for `DateOnly`:\n- `HaveYear` / `NotHaveYear`\n- `HaveMonth` / `NotHaveMonth`\n- `HaveDay` / `NotHaveDay`",
          "timestamp": "2024-11-13T11:45:33+01:00",
          "tree_id": "1d3a2ce68204d5b842a5719628ad5fe9de47c917",
          "url": "https://github.com/Testably/Testably.Expectations/commit/111637b4c65a733cf3fbfec63ce0107c81f6cd2b"
        },
        "date": 1731494939911,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 212.1721953323909,
            "unit": "ns",
            "range": "± 2.105996343461402"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 281.2347474416097,
            "unit": "ns",
            "range": "± 1.8250576792886504"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 622.898862361908,
            "unit": "ns",
            "range": "± 5.350347696632538"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 388.22877007264356,
            "unit": "ns",
            "range": "± 1.3219861048639947"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 437.63180742263796,
            "unit": "ns",
            "range": "± 1.8585543531814483"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1422.3460948944091,
            "unit": "ns",
            "range": "± 8.100348022980032"
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
          "id": "d558faa0a6228d8d85078f3cf373389a7bddec1c",
          "message": "feat: add property expectations for `DateTime` (#163)\n\nFrom #129 \r\nAdd property expectations for `DateTime`:\r\n- `HaveYear` / `NotHaveYear`\r\n- `HaveMonth` / `NotHaveMonth`\r\n- `HaveDay` / `NotHaveDay`\r\n- `HaveHour` / `NotHaveHour`\r\n- `HaveMinute` / `NotHaveMinute`\r\n- `HaveSecond` / `NotHaveSecond`\r\n- `HaveMillisecond` / `NotHaveMillisecond`\r\n- `HaveKind` / `NotHaveKind`",
          "timestamp": "2024-11-13T16:53:54Z",
          "tree_id": "ad5d62c9c35f79c697cca0c4f66c5365a2e0cc55",
          "url": "https://github.com/Testably/Testably.Expectations/commit/d558faa0a6228d8d85078f3cf373389a7bddec1c"
        },
        "date": 1731517046974,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 218.46944171648758,
            "unit": "ns",
            "range": "± 0.9212096230855528"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 287.0030254999796,
            "unit": "ns",
            "range": "± 2.2694541331430864"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 648.1974428176879,
            "unit": "ns",
            "range": "± 4.038969515570516"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 405.1878536860148,
            "unit": "ns",
            "range": "± 1.6887134391708276"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 445.07006107966106,
            "unit": "ns",
            "range": "± 2.4537874700148774"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1411.7127881368,
            "unit": "ns",
            "range": "± 8.889775299787747"
          }
        ]
      },
      {
        "commit": {
          "author": {
            "email": "valentin.breuss@baur.eu",
            "name": "Valentin",
            "username": "vbreuss"
          },
          "committer": {
            "email": "valentin.breuss@baur.eu",
            "name": "Valentin",
            "username": "vbreuss"
          },
          "distinct": true,
          "id": "9e02c6d0787d84d33a3d4816c2377e14b2fcbb05",
          "message": "Accept API changes",
          "timestamp": "2024-11-13T18:14:32+01:00",
          "tree_id": "802e6d4c92f3695ac3a29322aa58eb03c8489166",
          "url": "https://github.com/Testably/Testably.Expectations/commit/9e02c6d0787d84d33a3d4816c2377e14b2fcbb05"
        },
        "date": 1731518300828,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 220.46039595603943,
            "unit": "ns",
            "range": "± 2.023001843162665"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 287.9714822428567,
            "unit": "ns",
            "range": "± 2.1428997489521593"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 644.030905859811,
            "unit": "ns",
            "range": "± 3.379216987988673"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 404.94679979177624,
            "unit": "ns",
            "range": "± 3.9843889672190635"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 441.65681438446046,
            "unit": "ns",
            "range": "± 3.2533183404410835"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1473.0798961639405,
            "unit": "ns",
            "range": "± 15.450736132033347"
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
          "id": "d558faa0a6228d8d85078f3cf373389a7bddec1c",
          "message": "feat: add property expectations for `DateTime` (#163)\n\nFrom #129 \r\nAdd property expectations for `DateTime`:\r\n- `HaveYear` / `NotHaveYear`\r\n- `HaveMonth` / `NotHaveMonth`\r\n- `HaveDay` / `NotHaveDay`\r\n- `HaveHour` / `NotHaveHour`\r\n- `HaveMinute` / `NotHaveMinute`\r\n- `HaveSecond` / `NotHaveSecond`\r\n- `HaveMillisecond` / `NotHaveMillisecond`\r\n- `HaveKind` / `NotHaveKind`",
          "timestamp": "2024-11-13T16:53:54Z",
          "tree_id": "ad5d62c9c35f79c697cca0c4f66c5365a2e0cc55",
          "url": "https://github.com/Testably/Testably.Expectations/commit/d558faa0a6228d8d85078f3cf373389a7bddec1c"
        },
        "date": 1731518600599,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 221.41491038458688,
            "unit": "ns",
            "range": "± 1.5486652024676313"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 299.83895448275973,
            "unit": "ns",
            "range": "± 1.5598612464245447"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 632.2568460305532,
            "unit": "ns",
            "range": "± 2.9425459675772787"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 406.358073870341,
            "unit": "ns",
            "range": "± 2.752151913557011"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 443.15258383750916,
            "unit": "ns",
            "range": "± 2.1013058983508563"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1456.1561321258546,
            "unit": "ns",
            "range": "± 12.61342434970214"
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
          "id": "65c4bdcdfb56414e9ef8974ccd48b590bd92cebb",
          "message": "feat: add property expectations for `DateTimeOffset` (#164)\n\nFrom #129 \r\nAdd property expectations for `DateTimeOffset`:\r\n- `HaveYear` / `NotHaveYear`\r\n- `HaveMonth` / `NotHaveMonth`\r\n- `HaveDay` / `NotHaveDay`\r\n- `HaveHour` / `NotHaveHour`\r\n- `HaveMinute` / `NotHaveMinute`\r\n- `HaveSecond` / `NotHaveSecond`\r\n- `HaveMillisecond` / `NotHaveMillisecond`\r\n- `HaveOffset` / `NotHaveOffset`",
          "timestamp": "2024-11-13T17:28:46Z",
          "tree_id": "4e5a125c3e80f4296ea23d84b87721ac9f7b1b66",
          "url": "https://github.com/Testably/Testably.Expectations/commit/65c4bdcdfb56414e9ef8974ccd48b590bd92cebb"
        },
        "date": 1731519135349,
        "tool": "benchmarkdotnet",
        "benches": [
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_FluentAssertions",
            "value": 225.3312591654914,
            "unit": "ns",
            "range": "± 1.4556992135942795"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TestablyExpectations",
            "value": 302.34123277664185,
            "unit": "ns",
            "range": "± 2.431968406727903"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.Bool_TUnit",
            "value": 648.3094309488932,
            "unit": "ns",
            "range": "± 6.194114855247609"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_FluentAssertions",
            "value": 414.2573178927104,
            "unit": "ns",
            "range": "± 4.290156000637056"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TestablyExpectations",
            "value": 448.17269931520735,
            "unit": "ns",
            "range": "± 3.1161662913750274"
          },
          {
            "name": "Testably.Expectations.Benchmarks.HappyCaseBenchmarks.String_TUnit",
            "value": 1398.634435926165,
            "unit": "ns",
            "range": "± 11.61620473614626"
          }
        ]
      }
    ]
  }
}