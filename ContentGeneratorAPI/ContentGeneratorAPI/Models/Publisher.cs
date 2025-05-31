using Microsoft.VisualBasic;

namespace ContentGeneratorAPI.Models
{
    public class Publisher
    {
        private string _name { get; set; } = null!;
        private uint _year { get; set; }

        public Publisher() { }

        public Publisher(string name, uint year)
        {
            _name = name;
            _year = year;
        }

        public string Name { get { return _name; } }
        public uint Year { get { return _year; } }
    }
}
