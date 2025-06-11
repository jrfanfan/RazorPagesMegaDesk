using System.ComponentModel.DataAnnotations;

namespace RazorPagesMegaDesk.Models
{
    public class Desk
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        public int DeskWide { get; set; }

        public int DeskDepth { get; set; }

        public string? Materials { get; set; }

        public int Rush {  get; set; }
        public int Price { get; set; }
    }
}
