using FoodOnTips.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOnTips.Data
{
    public class MasterRepository
    {
        UnitOfWork uow = new UnitOfWork();
        FoodOnTipsDataContext dbContext = new FoodOnTipsDataContext();
        public List<ItemMaster> GetItemMasterList()
        {
            return dbContext.ItemMasters.Where(x => x.Active == true).ToList();
        }

        public string SaveOrder(Entity.OrderMaster odr, List<Entity.TransactionOrderDetails> oderList)
        {
            string message = string.Empty;
            try
            {
                Data.OrderMaster dataobj = new OrderMaster();
                dataobj.CustomerName = odr.CustomerName;
                dataobj.Contact = Convert.ToDecimal(odr.Contact);
                dataobj.OrderDate = DateTime.Now;
                dataobj.EmailId = odr.EmailId;
                dbContext.OrderMasters.InsertOnSubmit(dataobj);
                dbContext.SubmitChanges();
                int OrderID = dataobj.OrderID;
                List<TransactionOrderDetail> dataoderList = new List<TransactionOrderDetail>();
                foreach (var data in oderList)
                {
                    TransactionOrderDetail objode = new TransactionOrderDetail();
                    objode.OrderID = OrderID;
                    objode.ItemId = data.ItemId;
                    objode.OrderQuentity = data.OrderQuentity;
                    dataoderList.Add(objode);
                }
                dbContext.TransactionOrderDetails.InsertAllOnSubmit(dataoderList);
                dbContext.SubmitChanges();
                message = OrderID.ToString();
            }
            catch (Exception ex)
            {
                message = "Error";
            }

            return message;
        }

        public List<CustomerOrder> ReviewOrder(string key, string Value = "")
        {
            List<CustomerOrder> objreview = new List<CustomerOrder>();
            if (key == "FullFill")
            {
                dbContext.OrderMasters.Where(x => x.OrderID == Convert.ToInt32(Value)).FirstOrDefault().IsFullFilled = true;
                dbContext.OrderMasters.Where(x => x.OrderID == Convert.ToInt32(Value)).FirstOrDefault().FullFillDate = DateTime.Now;
                dbContext.SubmitChanges();

                objreview = (from order in dbContext.OrderMasters
                             where order.FullFillDate == null && order.CancleDate == null
                             select new CustomerOrder
                             {
                                 odr = new Entity.OrderMaster()
                                 {
                                     OrderID = order.OrderID,
                                     CustomerName = order.CustomerName,
                                     Contact = Convert.ToString(order.Contact),
                                     FullFillDate = order.FullFillDate,
                                     CancleDate = order.CancleDate,
                                     IsCancalled = order.IsCancalled,
                                     IsFullFilled = order.IsFullFilled,
                                     UpdatedBy = order.UpdatedBy,
                                     OrderDate = order.OrderDate,
                                     EmailId = order.EmailId
                                 },
                                 odrList = (from itemDetils in dbContext.TransactionOrderDetails
                                            join item in dbContext.ItemMasters on itemDetils.ItemId equals item.ItemId
                                            where itemDetils.OrderID == order.OrderID
                                            select new CutomerOrderItemList
                                            {
                                                ItemId = itemDetils.ItemId,
                                                Active = item.Active,
                                                Name = item.Name,
                                                ImagesPath = item.ImagesPath,
                                                ItemType = item.ItemType,
                                                OrderQuentity = itemDetils.OrderQuentity,
                                                OrderDeatilsId = itemDetils.OrderDeatilsId,
                                                CreatedDate = item.CreatedDate,
                                                OrderID = itemDetils.OrderID,
                                                Rate = item.Rate
                                            }).ToList()
                             }).ToList();
            }
            else if (key == "Cancel")
            {
                dbContext.OrderMasters.Where(x => x.OrderID == Convert.ToInt32(Value)).FirstOrDefault().IsCancalled = true;
                dbContext.OrderMasters.Where(x => x.OrderID == Convert.ToInt32(Value)).FirstOrDefault().CancleDate = DateTime.Now;
                dbContext.SubmitChanges();
                objreview = (from order in dbContext.OrderMasters
                             where order.FullFillDate == null && order.CancleDate == null
                             select new CustomerOrder
                             {
                                 odr = new Entity.OrderMaster()
                                 {
                                     OrderID = order.OrderID,
                                     CustomerName = order.CustomerName,
                                     Contact = Convert.ToString(order.Contact),
                                     FullFillDate = order.FullFillDate,
                                     CancleDate = order.CancleDate,
                                     IsCancalled = order.IsCancalled,
                                     IsFullFilled = order.IsFullFilled,
                                     UpdatedBy = order.UpdatedBy,
                                     OrderDate = order.OrderDate,
                                     EmailId = order.EmailId
                                 },
                                 odrList = (from itemDetils in dbContext.TransactionOrderDetails
                                            join item in dbContext.ItemMasters on itemDetils.ItemId equals item.ItemId
                                            where itemDetils.OrderID == order.OrderID
                                            select new CutomerOrderItemList
                                            {
                                                ItemId = itemDetils.ItemId,
                                                Active = item.Active,
                                                Name = item.Name,
                                                ImagesPath = item.ImagesPath,
                                                ItemType = item.ItemType,
                                                OrderQuentity = itemDetils.OrderQuentity,
                                                OrderDeatilsId = itemDetils.OrderDeatilsId,
                                                CreatedDate = item.CreatedDate,
                                                OrderID = itemDetils.OrderID,
                                                Rate = item.Rate
                                            }).ToList()
                             }).ToList();
            }
            else if (key == "2")
            {
                objreview = (from order in dbContext.OrderMasters
                             where order.FullFillDate != null
                             select new CustomerOrder
                             {
                                 odr = new Entity.OrderMaster()
                                 {
                                     OrderID = order.OrderID,
                                     CustomerName = order.CustomerName,
                                     Contact = Convert.ToString(order.Contact),
                                     FullFillDate = order.FullFillDate,
                                     CancleDate = order.CancleDate,
                                     IsCancalled = order.IsCancalled,
                                     IsFullFilled = order.IsFullFilled,
                                     UpdatedBy = order.UpdatedBy,
                                     OrderDate = order.OrderDate,
                                     EmailId = order.EmailId
                                 },
                                 odrList = (from itemDetils in dbContext.TransactionOrderDetails
                                            join item in dbContext.ItemMasters on itemDetils.ItemId equals item.ItemId
                                            where itemDetils.OrderID == order.OrderID
                                            select new CutomerOrderItemList
                                            {
                                                ItemId = itemDetils.ItemId,
                                                Active = item.Active,
                                                Name = item.Name,
                                                ImagesPath = item.ImagesPath,
                                                ItemType = item.ItemType,
                                                OrderQuentity = itemDetils.OrderQuentity,
                                                OrderDeatilsId = itemDetils.OrderDeatilsId,
                                                CreatedDate = item.CreatedDate,
                                                OrderID = itemDetils.OrderID,
                                                Rate = item.Rate
                                            }).ToList()
                             }).ToList();
            }
            else if (key == "3")
            {
                objreview = (from order in dbContext.OrderMasters
                             where order.CancleDate != null
                             select new CustomerOrder
                             {
                                 odr = new Entity.OrderMaster()
                                 {
                                     OrderID = order.OrderID,
                                     CustomerName = order.CustomerName,
                                     Contact = Convert.ToString(order.Contact),
                                     FullFillDate = order.FullFillDate,
                                     CancleDate = order.CancleDate,
                                     IsCancalled = order.IsCancalled,
                                     IsFullFilled = order.IsFullFilled,
                                     UpdatedBy = order.UpdatedBy,
                                     OrderDate = order.OrderDate,
                                     EmailId = order.EmailId,
                                 },
                                 odrList = (from itemDetils in dbContext.TransactionOrderDetails
                                            join item in dbContext.ItemMasters on itemDetils.ItemId equals item.ItemId
                                            where itemDetils.OrderID == order.OrderID
                                            select new CutomerOrderItemList
                                            {
                                                ItemId = itemDetils.ItemId,
                                                Active = item.Active,
                                                Name = item.Name,
                                                ImagesPath = item.ImagesPath,
                                                ItemType = item.ItemType,
                                                OrderQuentity = itemDetils.OrderQuentity,
                                                OrderDeatilsId = itemDetils.OrderDeatilsId,
                                                CreatedDate = item.CreatedDate,
                                                OrderID = itemDetils.OrderID,
                                                Rate = item.Rate
                                            }).ToList()
                             }).ToList();
            }
            else {
                objreview = (from order in dbContext.OrderMasters
                             where order.CancleDate == null &&  order.FullFillDate == null
                             select new CustomerOrder
                             {
                                 odr = new Entity.OrderMaster()
                                 {
                                     OrderID = order.OrderID,
                                     CustomerName = order.CustomerName,
                                     Contact = Convert.ToString(order.Contact),
                                     FullFillDate = order.FullFillDate,
                                     CancleDate = order.CancleDate,
                                     IsCancalled = order.IsCancalled,
                                     IsFullFilled = order.IsFullFilled,
                                     UpdatedBy = order.UpdatedBy,
                                     OrderDate = order.OrderDate,
                                     EmailId = order.EmailId
                                 },
                                 odrList = (from itemDetils in dbContext.TransactionOrderDetails
                                            join item in dbContext.ItemMasters on itemDetils.ItemId equals item.ItemId
                                            where itemDetils.OrderID == order.OrderID
                                            select new CutomerOrderItemList
                                            {
                                                ItemId = itemDetils.ItemId,
                                                Active = item.Active,
                                                Name = item.Name,
                                                ImagesPath = item.ImagesPath,
                                                ItemType = item.ItemType,
                                                OrderQuentity = itemDetils.OrderQuentity,
                                                OrderDeatilsId = itemDetils.OrderDeatilsId,
                                                CreatedDate = item.CreatedDate,
                                                OrderID = itemDetils.OrderID,
                                                Rate = item.Rate
                                            }).ToList()
                             }).ToList();
            }

            return objreview.OrderBy(x => x.odr.OrderDate).ToList();
        }

        public Entity.Report.FoodReport Report(string key, string Value = "")
        {
            Entity.Report.FoodReport obj = new Entity.Report.FoodReport();
            obj.lstOrderDetailReport = (from order in dbContext.OrderMasters
                                        select new Entity.Report.OrderDetailReport
                                        {
                                            OrderId = order.OrderID,
                                            StatusNewDate = order.OrderDate,
                                            StatusFullFillDate = order.FullFillDate,
                                            StatusCancelledDate = order.CancleDate,
                                        }).ToList();

            obj.lstOrderItemDetailReport = (from order in dbContext.OrderMasters
                                            join item in dbContext.TransactionOrderDetails on order.OrderID equals item.OrderID
                                            select new Entity.Report.OrderItemDetailReport
                                            {
                                                OrderId = order.OrderID,
                                                ItemId = item.ItemId,
                                                ItemQty = item.OrderQuentity,
                                                StatusNewDate = order.OrderDate,
                                                StatusFullFillDate = order.FullFillDate,
                                                StatusCancelledDate = order.CancleDate,
                                            }).ToList();

            obj.lstItemDetailReport = dbContext.TransactionOrderDetails.GroupBy(x => x.ItemId).
                                        Select(g => new Entity.Report.ItemDetailReport
                                        { ItemId = g.Key, ItemQty = g.Sum(y => y.OrderQuentity) }).ToList();

            return obj;
        }
    }
}
