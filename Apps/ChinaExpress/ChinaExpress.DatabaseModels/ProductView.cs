namespace ChinaExpress.SimpleEntityModels
{
    public class ProductView
    {
        public ProductView(int id, int userId, int productId, DateTime viewDateTime)
        {
            Id = id;
            UserId = userId;
            ProductId = productId;
            ViewDateTime = viewDateTime;
        }

        public int Id { get; }
        public int UserId { get; }
        public int ProductId { get; }
        public DateTime ViewDateTime { get; }
    }
}
