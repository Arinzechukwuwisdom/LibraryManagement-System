namespace SureLbraryAPI.DTOs
{
    public class CreateBookDTO
    {
#nullable disable
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required int CopiesAvailable { get; set; }
        public required string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public required decimal Price { get; set; }
        //public required int Quantity { get; set; }
    }
}
