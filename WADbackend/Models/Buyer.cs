using System.ComponentModel.DataAnnotations;

namespace WADbackend.Models
{
    public class Buyer
    {
        [Key]
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public Buyer()
        {

        }
    }
}
