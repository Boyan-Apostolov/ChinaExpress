namespace ChinaExpress.SimpleEntityModels
{
    public class Review
    {
        public Review(int id, string description, int stars, string user, int orderItemId)
        {
            Id = id;
            Description = description;
            Stars = stars;
            User = user;
            OrderItemId = orderItemId;
        }

        public int Id { get; }
        public string Description { get; }
        public int Stars { get; }
        public string User { get; }
        public int OrderItemId { get; }
    }
}
