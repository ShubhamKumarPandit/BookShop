namespace BookShop.Model
{
    public class APIResponse
    {
        public int? statusCode {  get; set; }
        public String? message { get; set; }
        public dynamic? data { get; set; }
    }
}
