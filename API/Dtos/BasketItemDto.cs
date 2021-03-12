using System.ComponentModel.DataAnnotations;


namespace API.Dtos
{
    public class BasketItemDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string SchoolName { get; set; }

        public string DinnerTime { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }


        [Required]
        public int Day { get; set; }
        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
