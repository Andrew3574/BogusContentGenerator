using Bogus.DataSets;
using System.Collections.Generic;

namespace ContentGeneratorAPI.Models
{
    public class Book
    {
        private int _id;
        private string _title = null!;
        private string? _images;
        private List<Author> _authors = null!;
        private Publisher _publisher = null!;
        private List<Review>? _reviews;
        private int _likes;
        private string _isbn = null!;

        public Book() { }
        public Book(int id, string title, string image, List<Author> authors, Publisher publisher,
            int likes, string isbn)
        {
            _id = id;
            _title = title;
            _images = image;
            _authors = authors;
            _publisher = publisher;
            _likes = likes;
            _isbn = isbn;
        }

        public int Id { get { return _id; } }
        public string Title { get { return _title; } }
        public string Image { get { return _images; } }
        public Publisher Publisher { get { return _publisher; } set { _publisher = value; } }
        public List<Author> Author { get { return _authors; } }
        public List<Review>? Reviews { get { return _reviews; } set { _reviews = value; } }
        public int Likes {  get { return _likes; } }
        public string Isbn { get { return _isbn; } }
    }
}
