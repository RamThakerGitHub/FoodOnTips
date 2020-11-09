using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Entity
{
    [Table("OrderMaster")]
    public class OrderMaster
    {
        [Key]
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public string EmailId { get; set; }
        public bool? IsFullFilled { get; set; }
        public bool? IsCancalled { get; set; }
        public DateTime? FullFillDate { get; set; }
        public DateTime? CancleDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? OrderDate { get; set; }
        
    }
}
