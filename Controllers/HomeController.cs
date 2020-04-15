using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopSafe.EntityFramework;

namespace ShopSafe.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            try
            {
                var loggedInUserName = User.Identity.Name;
                string storeName = string.Empty;
                string locationName = string.Empty;
                string maxCapacity = string.Empty;
                string currentCapacity = string.Empty;

                using (var shopSafeEntity = new Entities())
                {
                    var userStoreLocationEntity = shopSafeEntity.Store_Location.Where(i => i.UserName == loggedInUserName).FirstOrDefault();
                    var storeEntity = shopSafeEntity.Stores.Where(s => s.Id == userStoreLocationEntity.Store_Id).FirstOrDefault();
                    var locationEntity = shopSafeEntity.Locations.Where(l => l.Id == userStoreLocationEntity.Location_Id).FirstOrDefault();
                    var capacityEntity = shopSafeEntity.Capacities.Where(c => c.Id == userStoreLocationEntity.Capacity_Id).FirstOrDefault();                    

                    storeName = storeEntity.Name;
                    locationName = locationEntity.Name;
                    maxCapacity = capacityEntity.Value;
                    currentCapacity = userStoreLocationEntity.Current_Capacity.ToString();
                }

                ViewBag.Store = storeName;
                ViewBag.Location = locationName;
                ViewBag.MaxCapacity = maxCapacity;
                ViewBag.CurrentCapacity = currentCapacity;

                return View();
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description page.";

            return View();
        }
    }
}