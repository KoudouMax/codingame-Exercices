Unit test
=========

Use code coverage for unit testing
----------------------------------

- [x] Step 1: dotnet test --collect:"XPlat Code Coverage"
- [x] Step 2: dotnet tool install -g dotnet-reportgenerator-globaltool
- [x] Step 3: reportgenerator -reports:"Path\To\TestProject\TestResults\{guid}\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
