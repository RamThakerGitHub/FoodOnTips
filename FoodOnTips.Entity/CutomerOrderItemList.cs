using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Entity
{
    public class CutomerOrderItemList
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public string ImagesPath { get; set; }

        public int ItemType { get; set; }

        public bool Active { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int OrderDeatilsId { get; set; }
        public int OrderID { get; set; }
        public int OrderQuentity { get; set; }

    }
}
