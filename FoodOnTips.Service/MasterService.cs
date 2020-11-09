using FoodOnTips.Data;
using FoodOnTips.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Service
{
    public class MasterService
    {
        MasterRepository masterRepository = new MasterRepository();

        public List<Entity.ItemMaster> GetItemMasterList()
        {
            try
            {
                List<Entity.ItemMaster> objList = new List<Entity.ItemMaster>();
                foreach (var data in masterRepository.GetItemMasterList())
                {
                    Entity.ItemMaster obj = new Entity.ItemMaster();
                    obj.ItemId = data.ItemId;
                    obj.ImagesPath = data.ImagesPath;
                    obj.Active = data.Active;
                    obj.CreatedBy = data.CreatedBy;
                    obj.CreatedDate = data.CreatedDate;
                    obj.ItemType = data.ItemType;
                    obj.Name = data.Name;
                    obj.Rate = data.Rate;
                    objList.Add(obj);
                }
                return objList;
            }
            catch (Exception ex)
            {
                return new List<Entity.ItemMaster>();
            }
        }

        public List<CustomerOrder> ReviewOrder(string key,string Value = "")
        {
            try
            {
                return masterRepository.ReviewOrder(key, Value);
            }
            catch (Exception ex)
            {
                return new List<CustomerOrder>();
            }
        }

        public Entity.Report.FoodReport Report(string key = "")
        {
            try
            {
                return masterRepository.Report(key);
            }
            catch (Exception ex)
            {
                return new Entity.Report.FoodReport();
            }
        }

        public string SaveFinalOrder(Entity.OrderMaster odr, List<Entity.TransactionOrderDetails> oderList)
        {
            try
            {
                return masterRepository.SaveOrder(odr, oderList);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
