# Contributing

## How to contribute an implementation (code)?

- Have a look at open issues. They contain the list of algorithms/DS we plan
to be implemented. Pick an unassigned issue.
- Feel free to add a new issue for an algorithm that is not in the list.
- **Make sure you are assigned for the issue.**
- Implement the algorithm/DS. You are allowed to use any language. See the styleguide below.
- Always write test on your algorithm or data structure
- Make a PR (see checklist below).
- Be sure to not include any compiled binaries in the patch.
- While sending a PR make sure you follow one issue per PR rule.

### Checklist before creating a Pull Request
Submit only relevant commits. We don't mind many commits in a pull request, but they must be relevant as explained below.

- __Use a feature branch__ The pull request should be created from a feature branch, and not from _dev_. See below for why.
- __Descriptive commit messages__ If a commit's message isn't descriptive, change it using [interactive rebase](https://help.github.com/articles/about-git-rebase). Refer to issues using `#issue`. Example of a bad message ~~"Small cleanup"~~. Example of good message: _"Fixing issue #5 by adding Trie class with supoort of Insert, FindPrefix and Clear and added relevant unit test."_. Don't be afraid to write long messages, if needed. The Erlang repo has some info on [writing good commit messages](https://github.com/erlang/otp/wiki/Writing-good-commit-messages).
- __No one-commit-to-rule-them-all__ Large commits that change too many things at the same time are very hard to review. Split large commits into smaller. See this [StackOverflow question](http://stackoverflow.com/questions/6217156/break-a-previous-commit-into-multiple-commits) for information on how to do this.
- __Tests__ Add relevant tests and make sure all existing ones still pass.
- __No Warnings__ Make sure your code do not produce any build warnings.

## Common Coding Style

- Code should be modular.
- Don't use global variables.
- Use separate folders for each language, if it is not exist - create it! Folder name should be in PascalCase (e.g. AlgorithmsPython).
- For some historical reasons Algorithms folder is for C# language implementations.
- Prefer classes instead of multiple helper functions (where applicable).
- Currently we are accepting contributions in any language.
- Use meaningful variable, method and function names and comments.
- Use external libraries only when no other solution is possible/plausible.

### C# Coding Style
- Follow the [Microsoft Naming Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/naming-guidelines)
- Preferable test framework - **xUnit**
- You allowed to use FluentAssertions