using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Entity
{
    [Table("TransactionOrderDetails")]
    public class TransactionOrderDetails
    {
        [Key]
        public int OrderDeatilsId { get; set; }
        public int OrderID { get; set; }
        public int  ItemId { get; set; }
        public int OrderQuentity { get; set; }

    }
}
