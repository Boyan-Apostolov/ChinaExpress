using System.Text.Json;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.ComplexModelsWithHelperReferences
{
    public class OrderItem
    {
        private string _serializedSelectedTags;

        public OrderItem(int id, int orderId, Product product, int quantity, string serializedSelectedTags, Review review)
        {
            Id = id;
            OrderId = orderId;
            Product = product;
            Quantity = quantity;
            Review = review;

            _serializedSelectedTags = serializedSelectedTags;
        }

        public int Id { get; }
        public int OrderId { get; }

        public Product Product { get; }

        public int Quantity { get; }
        public Review Review { get; }

        public List<string> SelectedTags => string.IsNullOrWhiteSpace(_serializedSelectedTags) 
            ? new List<string>() 
            : JsonSerializer.Deserialize<List<string>>(this._serializedSelectedTags);
    }
}
