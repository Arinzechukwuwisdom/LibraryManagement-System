namespace SureLbraryAPI.DTOs
{
    public class GetTransactionDTO
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string BookName { get; set; }
        public required string TransactionDate { get; set; }
        public required string DueDate { get; set; }
        public required string TransactionStatus { get; set; }
        public string ReturnDate { get; set; }= string.Empty;
    }
}
