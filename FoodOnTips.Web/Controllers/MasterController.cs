using FoodOnTips.Entity;
using FoodOnTips.Model;
using FoodOnTips.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodOnTips.Web.Controllers
{
    public class MasterController : Controller
    {
        MasterService masterService = new MasterService();
        // GET: Master
        public ActionResult Item()
        {
            ItemMsaterModel model = new ItemMsaterModel();
            model.ItemMasterList = masterService.GetItemMasterList();
            return View(model);
        }
    }
}