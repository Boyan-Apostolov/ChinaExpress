using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using ChinaExpress.ComplexModelsWithHelperReferences;
using ChinaExpress.SimpleEntityModels;

namespace ChinaExpress.DTOs
{
    public class RecommendationProjectionDTO
    {
        public int Priority { get; set; }
        public Product Product { get; set; }
        public IEnumerable<ProductView> Views { get; set; }
        public double Rating { get; set; }
        public double DayWeight { get; set; }
    }
}
