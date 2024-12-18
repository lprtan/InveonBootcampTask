﻿using InveonBootcamp.LibaryApi.Caching.Interfaces;
using InveonBootcamp.LibaryApi.Models.Entities;
using InveonBootcamp.LibaryApi.Models.ErrorOrSuccessMessage;
using InveonBootcamp.LibaryApi.Models.Pagination;
using InveonBootcamp.LibaryApi.Models.Repositories.Context;
using InveonBootcamp.LibaryApi.Models.Services.Abstract;
using InveonBootcamp.LibaryApi.Models.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InveonBootcamp.LibaryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IRedisCacheService _redisCacheService;
        public BookController(IBookService bookService, IRedisCacheService redisCacheService)
        {
            _bookService = bookService;
            _redisCacheService = redisCacheService;
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedBooks(int pageNumber, int pageSize)
        {
            var cacheKey = $"books_page_{pageNumber}_size_{pageSize}";

            var cacheBooksData = await _redisCacheService.GetValueAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheBooksData))
            {
                var books = JsonConvert.DeserializeObject<List<Book>>(cacheBooksData);
                return Ok(ServiceResult<object>.Success(books, 200));
            }


            var query = await _bookService.GetQueryableBookPagination(pageNumber, pageSize);

            var result = await PaginationHelper<Book>.GetPagedResultAsync(query, pageNumber, pageSize);
            var data = result.Items;

            if (data == null)
            {
                return BadRequest(ServiceResult<IEnumerable<Book>>.Fail("Kitap listesi boş.", 404));
            }

            var serializedResult = JsonConvert.SerializeObject(result.Items);
            await _redisCacheService.SetValueAsync(cacheKey, serializedResult);

            return Ok(ServiceResult<object>.Success(result, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var cacheKey = "books_all";

            var cacheBooksData = await _redisCacheService.GetValueAsync(cacheKey);

            if (!string.IsNullOrEmpty(cacheBooksData))
            {
                var booksData = JsonConvert.DeserializeObject<IEnumerable<Book>>(cacheBooksData);
                return Ok(ServiceResult<object>.Success(booksData, 200));
            }

            var books = _bookService.GetAllList();

            if (books == null)
            {
                return BadRequest(ServiceResult<IEnumerable<Book>>.Fail("Kitap listesi boş.", 404));
            }

            var serializedResult = JsonConvert.SerializeObject(books);
            await _redisCacheService.SetValueAsync(cacheKey, serializedResult);

            return Ok(ServiceResult<IEnumerable<Book>>.Success(books, 200));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = _bookService.GetByID(id);

            if (book == null)
            {
                return NotFound(ServiceResult<Book>.Fail("Kitap bulunamadı.", 404));
            }

            return Ok(ServiceResult<Book>.Success(book, 200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest(ServiceResult<Book>.Fail("Geçersiz kitap verisi.", 400));
            }

            _bookService.AddBook(book);

            return CreatedAtAction(
                nameof(GetBook),
                new { id = book.BookId },
                ServiceResult<Book>.Success(book, 201)
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book book)
        {
            var bookId = _bookService.GetByID(id).BookId;

            if (bookId != id)
            {
                return NotFound(ServiceResult<Book>.Fail("Kitap bulunamadı.", 404));
            }

            book.BookId = id;
            _bookService.UpdateBook(book);

            return Ok(ServiceResult<Book>.Success(book, 200));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = _bookService.GetByID(id);

            if (book == null)
            {
                return NotFound(ServiceResult<Book>.Fail("Kitap bulunamadı.", 404));
            }

            _bookService.DeleteBook(book);

            return Ok(ServiceResult<string>.Success("Kitap başarıyla silindi.", 200));
        }
    }

}
