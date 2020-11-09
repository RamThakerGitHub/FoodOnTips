using FoodOnTips.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Model
{
    public class OrderSave
    {
        public OrderMaster UserInfo { get; set; }

        public List<TransactionOrderDetails> ItemData { get; set; }
    }
}
