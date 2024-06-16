using System.Text.Json;

namespace ChinaExpress.SimpleEntityModels
{
    public class Feature
    {
        private string _serializedTags;
        public Feature(int id, string name, string serializedTags)
        {
            Id = id;
            Name = name;
            _serializedTags = serializedTags;
        }

        public int Id { get; set; }

        public string Name { get; set; }


        public List<string> Tags =>
            string.IsNullOrWhiteSpace(_serializedTags)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(_serializedTags);

        public override string ToString()
        {
            return this.Name;
        }
    }
}
