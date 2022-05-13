using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectStore.Data;
using ProjectStore.Models;
using ProjectStore.Models.DTOs;
using AutoMapper;

namespace ProjectStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly DataBaseContext _dbcontext;
        private readonly IMapper _mapper;
        public ProductController(DataBaseContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public ActionResult CreateBook([FromBody] CreateBookDTO BookDTO)
        {
            var book = _mapper.Map<Book>(BookDTO);
            _dbcontext.BookDbSet.Add(book);
            _dbcontext.SaveChanges();
            return Created($"/api/Book/{book.Id}", null);
        }
        [HttpGet("Book/{id}")]
        public ActionResult<Book> GetBook([FromRoute] int id)
        {
            var Book = _dbcontext.BookDbSet.FirstOrDefault(b => b.Id == id);
            if(Book==null)
            {
                return NotFound();
            }
            var getbook = _mapper.Map<GetBookDTO>(Book);
            return Ok(getbook);
        }
        [HttpPut("Update/{id}")]
        public ActionResult UpdateBook([FromBody]EditBook Newbook, [FromRoute] int id)
        {
            var Book = _dbcontext.BookDbSet.FirstOrDefault(b => b.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            Book.Title = Newbook.Title;
            Book.Price = Newbook.Price;
            Book.Author = Newbook.Author;
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteBook([FromRoute]int id)
        {
            var Book = _dbcontext.BookDbSet.FirstOrDefault(b => b.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            _dbcontext.BookDbSet.Remove(Book);
            _dbcontext.SaveChanges();
            return Ok();
        }
    }
}
