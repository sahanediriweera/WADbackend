namespace WADbackend.Models
{
    public class Seller
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public virtual ICollection<Movie> movies { get; set; }

    }
}
