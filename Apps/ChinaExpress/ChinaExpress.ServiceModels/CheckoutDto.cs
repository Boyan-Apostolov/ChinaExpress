using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;
using System.Threading.Tasks;

namespace ChinaExpress.DTOs
{
    public class CheckoutDto
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public int TotalItems { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        public string? ProgramMessage { get; set; }
    }
}
