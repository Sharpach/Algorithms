# Algorithms
Some algorithms implementation for self-training.
## [Reverse Polish Notation](https://en.wikipedia.org/wiki/Reverse_Polish_notation)
Very simple algorithm just to convert infix notation to postfix notation.

Examples:
```
1+1 will turn into 11+
2+2*2 will turn into 222*+
```
But:
```
2 -2* 2 is nonsense. You won't get the right answer.
2(-2)*2 is nonsense too.
And 2- 2*2 is so.
```
