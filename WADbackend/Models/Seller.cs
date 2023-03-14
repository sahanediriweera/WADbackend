using System.ComponentModel.DataAnnotations;

namespace WADbackend.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public virtual ICollection<Movie> movies { get; set; }

        public Seller()
        {

        }

    }
}
