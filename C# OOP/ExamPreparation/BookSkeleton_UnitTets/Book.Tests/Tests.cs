namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        [Test]
        public void TestIfConstructorIscalledAndInitializeABook()
        {
            var book1 = new Book("Harry Potter", "JJ Rowling");

            Assert.AreEqual("Harry Potter", book1.BookName);
            Assert.AreEqual("JJ Rowling", book1.Author);
        }
        [Test]
        public void TestFootNoteCount()
        {
            var book1 = new Book("Harry Potter", "JJ Rowling");
            book1.AddFootnote(1, "First FootNote");
            book1.AddFootnote(2, "Second FootNote");
            book1.AddFootnote(3, "Third FootNote");

            var actualCount = book1.FootnoteCount;
            var expectedCount = 3;

            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void TestIfBookNameIsValid()
        {
            

            Assert.Throws<ArgumentException>(() =>
            {
                var book1 = new Book("", "JJ Rowling");
            },$"Invalid Book Name!") ;
        }
        [Test]
        public void TestIfAuthorIsValid()
        {


            Assert.Throws<ArgumentException>(() =>
            {
                var book1 = new Book("Harry Potter", "");
            }, $"Invalid Author!");
        }
        [Test]
        public void TestFootNoteIsUnique()
        {
            var book1 = new Book("Harry Potter", "JJ Rowling");
            book1.AddFootnote(1, "First FootNote");
            

            Assert.Throws<InvalidOperationException>(() =>
            {
                book1.AddFootnote(2, "Second FootNote");
                book1.AddFootnote(2, "Third FootNote");
            }, "Footnote already exists!");
            

        }
        [Test]
        public void TestFootNoteIsAddedAndItFindsIt()
        {
            var book1 = new Book("Harry Potter", "JJ Rowling");
            book1.AddFootnote(123, "First FootNote");
            var footNoteText = book1.FindFootnote(123);

            Assert.AreEqual(footNoteText, book1.FindFootnote(123),"The footNote is added.");

        }

        [Test]
        public void TestFootNoteMethodReturntExceptionWhenTheFootNoteDoesNotExists()
        {
            var book1 = new Book("Harry Potter", "JJ Rowling");
            book1.AddFootnote(123, "First FootNote");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book1.FindFootnote(12);
            }, "Footnote doesn't exists!");

        }
        [Test]
        public void TestAlterFootNoteMethodReturntExceptionWhenTheFootNoteDoesNotExists()
        {
            var book1 = new Book("Harry Potter", "JJ Rowling");
            book1.AddFootnote(123, "First FootNote");

            Assert.Throws<InvalidOperationException>(() =>
            {
                book1.AlterFootnote(12,"Test1");
            }, "Footnote doesn't exists!");

        }
        [Test]
        public void TestIfFootNoteIAltered()
        {
            var book1 = new Book("Harry Potter", "JJ Rowling");
            book1.AddFootnote(123, "First FootNote");
            book1.AlterFootnote(123, "Second FootNote");
            string actualNote = "Second FootNote";
            string expectedNote = "Second FootNote";

            Assert.AreEqual(expectedNote, actualNote, "The note was actually altered");

        }
    }
}