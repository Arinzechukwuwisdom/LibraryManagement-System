using SureLbraryAPI.DTOs;
using SureLbraryAPI.Models;
using SureLbraryAPI.Utilities;

namespace SureLbraryAPI.Interfaces
{
    public interface IBookService
    {
        Task <ResponseDetails<GetBookDTO>>AddBookAsync (CreateBookDTO bookDetail);
        //Task<ResponseDetails<GetBookDTO>> GetBookByNameAsync(string authorName);
        Task<ResponseDetails<List<GetBookDTO>>> GetAllBooksAsync();
        Task<ResponseDetails<GetBookDTO>> GetBookByIdAsync(int id);     
        //Task<ResponseDetails<IEnumerable<GetBookDTO>>> UpdateBookAsync (int id,Book book);
        Task <ResponseDetails<GetBookDTO>>DeleteBookAsync (int id);
        Task<ResponseDetails<IEnumerable<GetBookDTO>>> SearchBooksAsync(string searchTerm);
        Task <ResponseDetails<IEnumerable<GetBookDTO>>> GetAvailableBooksAsync();
        Task<ResponseDetails<IEnumerable<GetBookDTO>>>GetBookBySpecificFilterAsync(string filter);
    }
}
