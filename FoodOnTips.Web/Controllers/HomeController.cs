using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodOnTips.Model;
using FoodOnTips.Service;
using System.Web.Mvc;
using FoodOnTips.Entity;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace FoodOnTips.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ItemMsaterModel model = new ItemMsaterModel();
            try
            {

                MasterService masterService = new MasterService();
                model.ItemMasterList = masterService.GetItemMasterList();
            }
            catch
            {
            }
            return View(model);
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckOut(string jsonData)
        {
            string message = string.Empty;
            try {
                OrderSave objsave = JsonConvert.DeserializeObject<OrderSave>(jsonData);
                MasterService masterService = new MasterService();
                message =  masterService.SaveFinalOrder(objsave.UserInfo, objsave.ItemData);
                if (message != "ERROR")
                {
                    SandEmial(objsave.UserInfo.CustomerName, message, objsave.UserInfo.EmailId);
                    //return RedirectToAction("OrderConfomataionPage", new { odernumer = message });
                }
            }
            catch (Exception ex)

            {
                message = "ERROR";
            }
            return Content(message);
        }

        public void SandEmial(string customerName, string message,string EmailId)
        {
            try {
                using (MailMessage mm = new MailMessage("ramthaker123@gmail.com", EmailId))
                {
                    mm.Subject = "order confirmation Order Id :" + message;
                    mm.Body = @"<Html>
<head></head>
<Title> order confirmation </Title>
  <Body>
  <table border = '1' align = 'left' style = 'margin-top:10%'>
       <tr>
                   <td>
                   <P> <b> Thank you " + customerName + @" </b></P>
                       Your Order has been successfully placed.
                       <br/><br/><br/>
           
                         your Order Number.  " + message + @"

                         </td>
                         </tr>
                        </table>
                        </Body>
                        </html>";
                    mm.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient())
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential("ramthaker123@gmail.com", "Ram@12345");
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                        ViewBag.Message = "Email sent.";
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public ActionResult ReviewOrder(string key,string orderid = "")
        {
            List<CustomerOrder> objCustomer = new List<CustomerOrder>(); 
            if (key == "1")
            {
                MasterService masterService = new MasterService();
                objCustomer = masterService.ReviewOrder(string.Empty);
            }
            else if (key == "2")
            {
                MasterService masterService = new MasterService();
                objCustomer = masterService.ReviewOrder(key);

            }
            else if (key == "3")
            {
                MasterService masterService = new MasterService();
                objCustomer = masterService.ReviewOrder(key);
            }
            else if (key == "4")
            {
                MasterService masterService = new MasterService();
                objCustomer = masterService.ReviewOrder("FullFill", orderid);
            }
            else if (key == "5")
            {
                MasterService masterService = new MasterService();
                objCustomer = masterService.ReviewOrder("Cancel", orderid);
            }
            return View(objCustomer);
        }

        public ActionResult OrderConfomataionPage(string odernumer)
        {
            ViewBag.Message = odernumer;
            return View();
        }

        public ActionResult Login()
        {
            UserLogin login = new UserLogin();
            return View(login);
        }

        [HttpPost]
        public ActionResult Login(UserLogin login)
        {
            if (login.UserName == "Admin" && login.Password == "Admin@123")
            {
                return RedirectToAction("ReviewOrder", new { Key = 1});
            }
            ViewBag.Error = "UserName or Password is not matched";
            return View();
        }

        public ActionResult Report()
        {
            Entity.Report.FoodReport objreport = new Entity.Report.FoodReport();
            MasterService masterService = new MasterService();
            objreport = masterService.Report(string.Empty);
            return View(objreport);
        }

        public ActionResult LogOut()
        {
            return RedirectToAction("Login");
        }
    }
}