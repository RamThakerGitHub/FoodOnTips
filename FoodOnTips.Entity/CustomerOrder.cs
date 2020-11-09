using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Entity
{
    public class CustomerOrder
    {
        public OrderMaster odr { get; set; }

        public List<CutomerOrderItemList> odrList { get; set; }
    }
}
