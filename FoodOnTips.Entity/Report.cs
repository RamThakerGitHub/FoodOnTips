using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Entity
{
    public class Report
    {
        public class FoodReport
        {
            public List<OrderDetailReport> lstOrderDetailReport { get; set; }
            public List<OrderItemDetailReport> lstOrderItemDetailReport { get; set; }
            public List<ItemDetailReport> lstItemDetailReport { get; set; }
        }

        public class OrderDetailReport
        {
            public int OrderId { get; set; }
            public DateTime? StatusNewDate { get; set; }
            public DateTime? StatusFullFillDate { get; set; }
            public DateTime? StatusCancelledDate { get; set; }

        }
        public class OrderItemDetailReport
        {

            public int OrderId { get; set; }
            public int ItemId { get; set; }
            public int? ItemQty { get; set; }
            public DateTime? StatusNewDate { get; set; }
            public DateTime? StatusFullFillDate { get; set; }
            public DateTime? StatusCancelledDate { get; set; }
        }

        public class ItemDetailReport
        {

            public int ItemId { get; set; }
            public int? ItemQty { get; set; }

        }
    }
}
