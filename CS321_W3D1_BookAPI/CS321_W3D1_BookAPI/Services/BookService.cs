using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W3D1_BookAPI.Data;
using CS321_W3D1_BookAPI.Models;

namespace CS321_W3D1_BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }


        public void Delete(Book deleteBook)
        {
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == deleteBook.Id);

            _bookContext.Remove(currentBook);
        }

        public Book Get(int bookId)
        {
            return _bookContext.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books;
        }

        public Book Post(Book newBook)
        {
            _bookContext.Add(newBook);

            return newBook;
        }

        public Book Update(Book updatedBook)
        {
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == updatedBook.Id);

            currentBook.Title = updatedBook.Title;
            currentBook.Author = updatedBook.Author;
            currentBook.Catagory = updatedBook.Catagory;

            return currentBook;
        }
    }
}
