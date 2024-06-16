using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.DTOs
{
    public class CreateCategoryDto
    {
        private string _name;

        public CreateCategoryDto(string name)
        {
            this.Name = name;
        }


        public string Name
        {
            get => _name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Category Name cannot be empty");

                _name = value;
            }
        }

    }
}
