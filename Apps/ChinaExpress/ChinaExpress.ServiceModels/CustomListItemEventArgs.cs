namespace ChinaExpress.DTOs
{
    public class CustomListItemEventArgs : EventArgs
    {
        public CustomListItemEventArgs(int itemId, int productId)
        {
            ItemId = itemId;
            ProductId = productId;
        }
        public int ItemId { get; }
        public int ProductId { get; }
    }
}
