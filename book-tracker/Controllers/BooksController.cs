﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using book_tracker;
using book_tracker.Models;

namespace book_tracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ReadingContext _context;

        public BooksController(ReadingContext context)
        {
            _context = context;
        }

        // GET: Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.Include(b => b.Author).Include(b => b.BookRatings).ToListAsync();
        }

        // GET: Books/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var query = _context.Books.Where(b => b.BookID == id).Include(b => b.Author).Include(b => b.BookRatings);
            var book = await query.SingleAsync();

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            var bookToUpdate = await _context.Books.FindAsync(id);

            if (bookToUpdate == null)
            {
                return BadRequest();
            }

            book.BookID = bookToUpdate.BookID;
            _context.Entry(bookToUpdate).CurrentValues.SetValues(book);

            _context.Books.Update(bookToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            var author = await _context.Authors.FindAsync(book.AuthorID);
            book.Author = author;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.BookID }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookID == id);
        }
    }
}
