namespace ChinaExpress.SimpleEntityModels
{
    public class Category
    {
        private List<Feature> _features;

        public Category(int id, string name, int itemsCount)
        {
            Id = id;
            Name = name;
            ItemsCount = itemsCount;

            _features = new List<Feature>();
        }

        public int Id { get; }
        public string Name { get; }

        public int ItemsCount { get; private set; }

        public List<Feature> Features => _features;

        public void SetFeatures(List<Feature> features) => this._features = features;

        public override string ToString() => this.Name;
    }
}
