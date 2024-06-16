using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.DTOs
{
    public class OrderItemActionDto
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }

        public List<string> SelectedTags { get; set; }
    }
}
