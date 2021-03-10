using System;
using BinFaTeszt;
using FluentAssertions;
using Xunit;

namespace BinFaTests
{
    public class UnitTest1
    {
        [Fact]
        public void Root_node_should_be_set_to_first_item()
        {
            var tree = new BinFa<string>("x");
            
            tree.Root.Core.Should().Be("x");
        }
        
        [Theory]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        public void Get_should_return_nth_fibonacci_number(int n, int expected)
        {
            var i = Fibonacci.Get(n);
            
            i.Should().Be(expected);
        }
        
        [Fact]
        public void Get_should_throw_ArgumentOutOfRangeException_when_n_is_lower_than_1()
        {
            Action action = () => Fibonacci.Get(0);
            action.Should().Throw<ArgumentException>();
        }
        
        
    }
}
