namespace API.Dtos
{
    public class MenuToReturnDto
    {
        public int  Id { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public string DinnerTime { get; set; }
        public string FoodFirst { get; set; }
        public string FoodSecond { get; set; }
        public string FoodThird { get; set; }
        public string FoodFourth { get; set; }
        public string SchoolName { get; set; }
        public decimal Price { get; set; }
    }
}
