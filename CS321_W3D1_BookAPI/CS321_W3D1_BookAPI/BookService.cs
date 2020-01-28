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
            _bookContext.SaveChanges();
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
            _bookContext.SaveChanges();

            return newBook;
        }

        public Book Update(Book updatedBook)
        {
            var currentBook = _bookContext.Books.FirstOrDefault(b => b.Id == updatedBook.Id);

            if (currentBook == null) return null;

            _bookContext.Entry(currentBook)
                .CurrentValues
                .SetValues(updatedBook);

            _bookContext.Books.Update(currentBook);
            _bookContext.SaveChanges();

            return currentBook;
        }
    }
}
