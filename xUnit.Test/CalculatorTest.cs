using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.APP;
using Xunit;

namespace xUnit.Test
{

    public class CalculatorTest
    {
        private Calculator calculator { get; set; }
        private Mock<ICalculatorService> mymock { get; set; } 
        public CalculatorTest()
        {
            var mymock = new Mock<ICalculatorService>();
            this.calculator = new Calculator(mymock.Object);
        }
        //[Fact]
        //public void AddTest()
        //{
        //    //// Arrange
        //    //int a= 5 ;
        //    //int b= 20;

        //    ////Act
        //    //var total = calculator.Add(a,b);
        //    ////Assert
        //    //Assert.NotEqual<int>(26,total); 

        //    // Assert.DoesNotContain("Kenan1", "Kenan Qedirov");
        //    //var names = new List<string> { "Name1", "Name2", "Name3" };
        //    //Assert.Contains(names, x => x == "Name12");

        //    //Assert.False("a".GetType() == typeof(string));

        //    //string regEx = "^dog";
        //    //Assert.Matches(regEx, "dog cat");

        //    //Assert.StartsWith("One", "One table");
        //    //Assert.EndsWith("Two", " One Two");

        //    //Assert.Empty(new List<int> { 1,12,23});
        //    //Assert.NotEmpty(new List<int> { 1,12,23});

        //    //Assert.InRange(10, 2, 20);
        //    //Assert.NotInRange(30, 2, 20);
        //    //Assert.Single(new List<string> { "Kenan" });

        //    //Assert.IsNotType<string>("Kenan");
        //    //Assert.IsAssignableFrom<IEnumerable<string>>(new List<string> { "a", "b" });
        //    //Assert.IsAssignableFrom<Object>("kenan");

        //    //string a = null ;
        //    //Assert.Null(a);

        //    //Assert.Equal<int>(4+1, 5);
        //}

        //[Theory]
        //[InlineData(5,10,15)]
        //[InlineData(15,10,25)]
        //[InlineData(35,10,45)]
        //public void AddTest2(int a , int b ,int expectedTotal)
        //{
        //    var actualTotal = calculator.Add(a, b);
        //    Assert.Equal( expectedTotal, actualTotal);
        //} 

        [Theory]
        [InlineData(0, 10, 0)]
        [InlineData(35, 0, 1)]
        public void Add_SimpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {          
            mymock.Setup(x=>x.Add(a, b)).Returns(expectedTotal);

            var actualTotal = calculator.Add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
            mymock.Verify(x=>x.Add(a,b),Times.Once);
        }

        [Theory]
        [InlineData(15, 10, 25)]
        [InlineData(35, 10, 45)]
        public void Add_ZeroValues_ReturnValue(int a, int b, int expectedTotal)
        {
            var actualTotal = calculator.Add(a, b);
            Assert.Equal(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(3,5,15)]
        public void Multip_SimpleValues_ReturnsMultipleValue(int a, int b , int expectedTotal)
        {
            mymock.Setup(x => x.Multip(a, b)).Returns(expectedTotal);
            Assert.Equal(15, calculator.Multip(a, b));
        }
    }
} 
