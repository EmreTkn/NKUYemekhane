namespace Core.Entities
{
   public class BasketItem
    {
        public int  Id { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int  Year { get; set; }
        public decimal MenuPrice { get; set; }
        public string SchoolName { get; set; }
        public string DinnerTime { get; set; }
        public decimal Price { get; set; }
    }
}
