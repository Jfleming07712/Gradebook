using System;
using Xunit;

namespace GradeBook.test
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange Section
            var book = new Book("John's Grade Book");
            
            {

            }

            //action section
            var result = book.GetStatistics();
            //assert section
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);


        }
    }
}
