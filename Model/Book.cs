namespace BookShop.Model
{
    public class Book
    {
       public int Id { get; set; }
        public String? BookTitle { get; set; }
        public String? BookAuthor { get; set; } 
        public int BookPrice { get; set; }
        public int BookSize { get; set; }
        public int PageCount { get; set; }
        public String? Publisher { get; set; }
    }
}
