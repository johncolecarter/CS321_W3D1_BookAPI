using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W3D1_BookAPI.Models;
using CS321_W3D1_BookAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W3D1_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int bookId)
        {
            var book = _bookService.Get(bookId);

            if (book == null) return NotFound();

            return Ok(book);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Book newBook)
        {
            try
            {
                _bookService.Post(newBook);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddBook", ex.Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { newBook.Id }, newBook);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book updadedBook)
        {
            var book = _bookService.Update(updadedBook);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var book = _bookService.Get(id);

            _bookService.Delete(book);
        }
    }
}
