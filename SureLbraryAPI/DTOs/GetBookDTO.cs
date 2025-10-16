namespace SureLbraryAPI.DTOs
{
    public class GetBookDTO
    {
#nullable disable
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
        public int CopiesAvailable { get; set; } = 1;
    }
}
