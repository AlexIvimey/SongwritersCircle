namespace SCapi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Lyrics { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
