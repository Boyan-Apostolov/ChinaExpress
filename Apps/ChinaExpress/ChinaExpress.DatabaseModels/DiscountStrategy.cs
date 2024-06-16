namespace ChinaExpress.SimpleEntityModels
{
    //TODO: Maybe move classes to seperate files?
    public abstract class DiscountStrategy : IDiscountStrategy
    {
        protected DiscountStrategy(int id, int value, int remainingUses, string code)
        {
            Id = id;
            Value = value;
            RemainingUses = remainingUses;
            Code = code;
        }

        public int Id { get; }
        public int RemainingUses { get; set; }
        public int Value { get; }

        public string Code { get; set; }
        public virtual decimal ApplyDiscount(decimal salePrice)
        {
            return 0;
        }

        public override string ToString()
        {
            return $"{this.Code} - ({this.RemainingUses} qty)";
        }
    }

    public class PercentageDiscountStrategy : DiscountStrategy
    {

        public PercentageDiscountStrategy(int id, int percentage, int remainingUses, string code) : base(id, percentage, remainingUses, code)
        {
        }

        public override decimal ApplyDiscount(decimal salePrice)
        {
            return salePrice * (1 - (decimal)this.Value / 100);
        }
    }

    public class FixedDiscountStrategy : DiscountStrategy
    {
        public FixedDiscountStrategy(int id, int discountAmount, int remainingUses, string code) : base(id, discountAmount, remainingUses, code)
        {
        }

        public override decimal ApplyDiscount(decimal salePrice)
        {
            return Math.Max(0, salePrice - Value);
        }
    }
}
