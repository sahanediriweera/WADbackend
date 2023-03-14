using System.ComponentModel.DataAnnotations;

namespace WADbackend.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        public String Title { get; set; }

        public Double Rating { get; set; }

        public String DateTime { get; set; }

        public int Cost { get; set; }

        public long AccountNumber { get; set; }

        public String Description { get; set; }

        public String Language { get; set; } 

        public virtual Seller Seller { get; set; }

        public Movie()
        {

        }
    }
}
