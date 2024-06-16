using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.DTOs
{
    public class ReviewInfoDto
    {
        public int OrderItemId { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public int Stars { get; set; }
    }
}
