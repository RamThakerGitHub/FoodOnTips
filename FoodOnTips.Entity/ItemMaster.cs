using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Entity
{
    [Table("ItemMaster")]
    public class ItemMaster
    {
        [Key]
        public int ItemId { get; set; }

        public string Name { get; set; }

        public decimal Rate { get; set; }

        public string ImagesPath { get; set; }

        public int ItemType { get; set; }

        public bool Active { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

    }

}
