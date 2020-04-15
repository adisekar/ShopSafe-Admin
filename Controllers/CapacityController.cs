using ShopSafe.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopSafe.Controllers
{

    public class CapacityModel
    {
        public int currentCapacity { get; set; }
    }

    public class CapacityController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]CapacityModel value)
        {
            var loggedInUserName = User.Identity.Name;
            using (var shopSafeEntity = new Entities())
            {
                var result = shopSafeEntity.Store_Location.SingleOrDefault(i => i.UserName == loggedInUserName);

                if (result != null)
                {
                    result.Current_Capacity = value.currentCapacity;
                    shopSafeEntity.SaveChanges();
                }
            }
        }

        // PUT api/<controller>/5
        [HttpPost]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}