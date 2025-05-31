namespace ContentGeneratorApp.Models
{
    public class Book
    {
        private int _id;
        private string _title;
        private string[] _authors;
        private string publisher;
        private Review[]? reviews;
    }
}
