using SureLbraryAPI.DTOs;
using SureLbraryAPI.Interfaces;

namespace SureLbraryAPI.Repository
{
    public class TransactionRepository : ITransactionService
    {
        public Task <GetTransactionDTO> CreateTransactionAsync(CreateTransactionDTO transaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTransactionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetTransactionDTO>> GetAllTransactionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetTransactionDTO>> GetOverdueTransactionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetTransactionDTO>> GetTransactionByBookIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetTransactionDTO> GetTransactionByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetTransactionDTO>> GetTransactionByStatusAsync(int status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetTransactionDTO>> GetTransactionByUserIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetTransactionDTO> UpdateTransactionAsync(CreateTransactionDTO transaction, int id)
        {
            throw new NotImplementedException();
        }
    }
}
