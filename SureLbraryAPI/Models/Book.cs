using System.ComponentModel.DataAnnotations.Schema;

namespace SureLbraryAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Column(TypeName = "Nvarchar(30)")]
        public required string Title { get; set; }
        [Column(TypeName = "Nvarchar(30)")]
        public required string Author { get; set; }
        [Column(TypeName = "Nvarchar(30)")]
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
        public int CopiesAvailable { get; set; } = 1;
        public int Quantity { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
