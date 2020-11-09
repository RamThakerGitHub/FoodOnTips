using FoodOnTips.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Model
{
    public class ItemMsaterModel
    {
        public ItemMsaterModel()
        {
            Item = new ItemMaster();
            ItemMasterList = new List<ItemMaster>();
        }

        public ItemMaster Item { get; set; }

        public List<Entity.ItemMaster> ItemMasterList { get; set; }
    }
}
