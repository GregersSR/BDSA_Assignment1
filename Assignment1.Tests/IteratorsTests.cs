using Xunit;
using Iterators;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void flatten_returns_intarray_given_intarrayarray()
        {
        //Arrange
        var input = new int[3, 3];
        var desiredOutput = new[] {0, 1, 2, 0, 1, 2, 0, 1, 2};

        //Act
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                input[i, j] = j;
            }
        }
        
        //Assert
        var output = Iterators.flatten(input);
        Assert.Equal(output, desiredOutput);
    }
}
