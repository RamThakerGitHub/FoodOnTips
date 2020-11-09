using FoodOnTips.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Data
{
    public class FoodOnTipsContext : DbContext
    {
        public FoodOnTipsContext() : base("name=FoodOnTipDB")
        {
        }
        public DbSet<ItemMaster> ItemMasters { get; set; }
    }
}
