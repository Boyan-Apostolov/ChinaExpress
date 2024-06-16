namespace ChinaExpress.SimpleEntityModels
{
    public interface IDiscountStrategy
    {
        public int Id { get; }
        public string Code { get; }
        public int RemainingUses { get; set; }
        public int Value { get; }
        decimal ApplyDiscount(decimal salePrice);
    }
}
