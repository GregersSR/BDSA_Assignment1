using Xunit;
using Assignment1;
using System;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void flatten_returns_int_list_of_same_numbers_in_given_list_of_int_lists()
        {
        //Arrange
        List<List<int>> input = new List<List<int>>();
        List<int> nestedListOne = new List<int>();
        List<int> nestedListTwo = new List<int>();
        List<int> nestedListThree = new List<int>();
        input.Add(nestedListOne);
        input.Add(nestedListTwo);
        input.Add(nestedListThree);
        List<int> desiredOutput = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                input[i].Add(j);
                desiredOutput.Add(j); 
            }
        }

        //Act
        IEnumerable<int> output = Iterators.Flatten(input);

        //Assert
        Assert.Equal(output, desiredOutput);
        }

        [Fact]
        public void filter_only_returns_ints_over_10_in_list_given_list_with_lesser_ints_included()
        {
        //Arrange
        Predicate<int> isOverTen = (int i) => { return i > 10; };
        List<int> input = new List<int>();
        List<int> desiredOutput = new List<int>();
        for (int i = 1; i <= 20; i++)
        {
            input.Add(i);
            if (isOverTen(i)) { desiredOutput.Add(i); };
        }

        //Act
        IEnumerable<int> output = Iterators.Filter(input, isOverTen);

        //Assert
        Assert.Equal(output, desiredOutput);
        }
    }
}
