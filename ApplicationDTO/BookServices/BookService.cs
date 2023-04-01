using Application.AuthorServices.Dtos;
using Application.Base;
using Application.BookRequestServices.Dtos;
using Application.BookServices.Dtos;
using Domain.Data;
using Domain.Operation;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookServices
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BookService(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<RequestResultDTO> AddBook(CreateBookDTO model)
        {
            try
            {
                Book book = new Book
                {
                    Title = model.Title,
                    Description = model.Description,
                    InternationalStandardBookNumber = model.InternationalStandardBookNumber,
                    Pages = model.Pages,
                    Inventory = model.Inventory,
                    Available = model.Available,
                    EditorialId = model.EditorialId,
                    EditionYear = model.EditionYear,
                    LanguageId = model.LanguageId,
                    GenreId = model.GenreId,
                    AuthorId = model.AuthorId,
                };
                _bookRepository.Create(book);
                await _bookRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Book added successfully",
                    Success = true,
                    Error = false
                };
            }
            catch (Exception exc)
            {
                return new RequestResultDTO
                {
                    Success = false,
                    Error = true,
                    ErrorMessage = exc.InnerException?.Message
                };
            }
        }

        public async Task<RequestResultDTO> DisableBook(int id)
        {
            try
            {
                await _bookRepository.Disable(id);
                await _bookRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Book disabled successfully",
                    Success = true,
                    Error = false
                };
            }
            catch (Exception exc)
            {

                return new RequestResultDTO
                {
                    Success = false,
                    Error = true,
                    ErrorMessage = exc.InnerException?.Message
                };
            }
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            return await _bookRepository.GetAll<Book>()
                .Select(
                book => new BookDTO
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    InternationalStandardBookNumber = book.InternationalStandardBookNumber,
                    Pages = book.Pages,
                    Inventory = book.Inventory,
                    Available = book.Available,
                    EditorialId = book.EditorialId,
                    EditionYear = book.EditionYear,
                    LanguageId = book.LanguageId,
                    GenreId = book.GenreId,
                    AuthorId = book.AuthorId,
                    Author = book.Author.Name,
                    BookRequests = book.BookRequests
                    .Select(b => new BookRequestDTO
                    {
                        Id = b.Id,
                        LectorId = b.LectorId,
                        DateRequestClosed = b.DateRequestClosed,
                        DateRequestOpen = b.DateRequestOpen,
                        RequestStatus = b.RequestStatus,
                    }).ToList(),
                }).ToListAsync();
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            var book = await _bookRepository.GetById(id);

            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                InternationalStandardBookNumber = book.InternationalStandardBookNumber,
                Pages = book.Pages,
                Inventory = book.Inventory,
                Available = book.Available,
                EditorialId = book.EditorialId,
                EditionYear = book.EditionYear,
                LanguageId = book.LanguageId,
                GenreId = book.GenreId,
                AuthorId = book.AuthorId,
                BookRequests = book.BookRequests
                .Select(b => new BookRequestDTO
                {
                    Id = b.Id,
                    LectorId = b.LectorId,
                    DateRequestClosed = b.DateRequestClosed,
                    DateRequestOpen = b.DateRequestOpen,
                    RequestStatus = b.RequestStatus,
                }).ToList()
            };
        }

        public async Task<RequestResultDTO> UpdateBook(BookDTO model)
        {
            try
            {
                var book = await _bookRepository.GetById(model.Id);
                book.Title = model.Title;
                book.Title = model.Title;
                book.Description = model.Description;
                book.InternationalStandardBookNumber = model.InternationalStandardBookNumber;
                book.Pages = model.Pages;
                book.Inventory = model.Inventory;
                book.Available = model.Available;
                book.EditionYear = model.EditionYear;
                book.EditorialId = model.EditorialId;
                book.LanguageId = model.LanguageId;
                book.GenreId = model.GenreId;
                book.AuthorId = model.AuthorId;


                _bookRepository.Update(model.Id, book);

                await _bookRepository.CommitAsync();

                return new RequestResultDTO
                {
                    SuccesMessage = "Book UPDATED successfully",
                    Success = true,
                    Error = false
                };
            }
            catch (Exception exc)
            {
                return new RequestResultDTO
                {
                    Success = false,
                    Error = true,
                    ErrorMessage = exc.InnerException?.Message
                };
            }
        }
    }
}
