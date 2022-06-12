using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace _10IyunTask.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descripiton { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
