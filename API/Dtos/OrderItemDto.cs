
namespace API.Dtos
{
    public class OrderItemDto
    {
        public int MenuId { get; set; }
        public string SchoolName { get; set; }
        public decimal Price { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string DinnerTime { get; set; }
    }
}
