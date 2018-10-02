using System;
using System.Collections.Generic;
using Algorithms.DecisionTree;
using FluentAssertions;
using Xunit;

namespace Algorithms.Tests.DecisionTreeTests
{
    public class DecisionTreeTests
    {
        [Fact]
        public void Test_DecisionTree_CharABCD()
        {
            // Arrange
            // Tree declaration
            var abDecision = new Func<char, IDecision<char, string>>(
                c => new Decision<char, string>(c,
                    (decision, s) => new Either<IDecision<char, string>, string>($"Result is {c+1}")));

            var сdDecision = new Func<char, IDecision<char, string>>(
                s => new Decision<char, string>(s,
                    (decision, c) => new Either<IDecision<char, string>, string>($"Result is {c-1}")));

            var abcdRoot = new Func<char, IDecision<char, string>>(
                s => new Decision<char, string>(s, 
                    (decision, c) =>
                    {
                        switch (c)
                        {
                            case 'A':
                            case 'B':
                                return new Either<IDecision<char, string>, string>(abDecision(s));
                            case 'С':
                            case 'D':
                                return new Either<IDecision<char, string>, string>(сdDecision(s));
                            default:
                                return new Either<IDecision<char, string>, string>("there is no such letter");
                        }
                    }));
            
            
            var root = abcdRoot('B');
            var tree = new DecisionTree<char, string>(root);

            // Act & Assert
            tree.Solve().Should().Be("Result is 67");
        }
    }
}