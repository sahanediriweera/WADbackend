namespace WADbackend.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public String DateTime { get; set; }

        public virtual Buyer Buyer { get; set; }

    }
}
