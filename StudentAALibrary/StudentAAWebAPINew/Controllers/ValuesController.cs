using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentAAWebAPINew.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {

        /// <summary>
        /// Gets all Value data
        /// </summary>
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Get individual Value data
        /// </summary>
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        /// <summary>
        /// Create Values
        /// </summary>
        // POST api/values
        public void Post([FromBody]string value)
        {
        }
        /// <summary>
        /// Edit Value data
        /// </summary>
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }
        /// <summary>
        /// Delete Values
        /// </summary>
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
