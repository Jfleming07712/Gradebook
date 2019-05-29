using System;
using Xunit;

namespace GradeBook.test
{
    public class TypeTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange Section
            var book1 = GetBook("Book1");
            GetBookSetName(book1, "New Name");

            //action section

            //assert section
            Assert.Equal("Book1", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            //Arrange Section
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");

            //action section

            //assert section
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Arrange Section
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");



            //action section

            //assert section
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //Arrange Section
            var book1 = GetBook("Book1");
            var book2 = book1;



            //action section

            //assert section
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book1", book2.Name);

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));

        }

        private Book GetBook(string name)
        {
            return new Book(name);

        }
    }
}
