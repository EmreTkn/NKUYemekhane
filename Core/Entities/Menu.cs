using System;


namespace Core.Entities
{
   public class Menu:BaseEntity
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public DinnerTime DinnerTime { get; set; }
        public int DinnerTimeId { get; set; }
        public string FoodFirst { get; set; }
        public string FoodSecond { get; set; }
        public string FoodThird { get; set; }
        public string FoodFourth { get; set; }
        public SchoolName SchoolName { get; set; }
        public int SchoolNameId { get; set; }
        public decimal Price { get; set; }
        public bool Holiday { get; set; } = false;

    }
}
