using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.DTOs
{
    public class CreateDiscountDto
    {
		private int _value;
		private int _type;
		private int _remainingUses;
		private string _code;

        public CreateDiscountDto(int value, string code, int type, int remainingUses)
        {
            this.Value = value;
            this.Code  = code;
            this.Type = type;
            this.RemainingUses = remainingUses;
        }

		public int Value
        {
            get => _value;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Discount value must have a value > 0");

                _value = value;
            }
		}

        public int RemainingUses
        {
            get => _remainingUses;
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Discount Remainnig Uses must have a value > 0");

                _remainingUses = value;
            }
        }

        public string Code
        {
            get => _code;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Discount must have a valid code");

                _code = value;
            }
        }

        public int Type
        {
            get => _type;
            private set
            {
                if (value == -1)
                    throw new ArgumentException("Discount must have a selected type");

                _type = value;
            }
        }

    }
}
