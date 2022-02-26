using System;
using System.ComponentModel.DataAnnotations;

namespace MvcKeyboard.Models
{
    public class Keyboard
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Color { get; set; }
        public string Switch { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }
}