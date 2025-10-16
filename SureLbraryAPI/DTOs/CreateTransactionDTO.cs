namespace SureLbraryAPI.DTOs
{
    public class CreateTransactionDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public required string TransactionStatus { get; set; } 
    }
}
