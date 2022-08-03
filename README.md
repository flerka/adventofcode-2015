## Advent Of Code 2015 with C#

__*I solved 25/25 days.*__

This repository contains my solutions for [Advent of code 2015 🎄](https://adventofcode.com/2015). All tasks are solved with **C#** and have unit tests to validate them. 

I tried solving all tasks using only .Net 6 without external libraries. You can run any solution from the corresponding test. 

I made a point not to share any code between parts one and two.

## Navigation
In project [adventofcode-2015](./code/adventofcode-2015) you can find solution algorithms and in [adventofcode-2015.Tests](./code/adventofcode-2015.Tests) you can find tests that run said solutions. I store the first and the second parts in different folders. The same structure applies to both projects.

You can find input data files and input parsers code in [adventofcode-2015.Tests](./code/adventofcode-2015.Tests) project. To use your input data instead of mine, you should update the data file you can find in the same folder as a test runner. For example - [data file for the day one part one](./code/adventofcode-2015.Tests/Task1/Data.txt). For several tasks, if there is no point in parsing data, you can find hardcoded input in the test C# file. 

## How to run
1) Install .Net 6.
2) Clone my repository.
3) Inside [code folder](./code) run in console

    `dotnet test --filter "DisplayName~Task1_"`

    *Task1_* should be replaced with the task number you want to run.
