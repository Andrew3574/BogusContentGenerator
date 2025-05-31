namespace ContentGeneratorAPI.Models
{
    public class Review
    {
        private string _name = null!;
        private string _text = null!;

        public Review() { }

        public Review(string name, string text)
        {
            _name = name; 
            _text = text;
        }

        public string Name {  get { return _name; } }
        public string Text {  get { return _text; } }
    }
}
