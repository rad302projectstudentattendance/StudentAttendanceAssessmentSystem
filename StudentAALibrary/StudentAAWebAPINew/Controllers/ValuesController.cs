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
        /// Gets some very important data from the server.
        /// </summary>
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// Gets Value data
        /// </summary>
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }


        /// <summary>
        /// Post from the server.
        /// </summary>
        // POST api/values
        public void Post([FromBody]string value)
        {
        }
        /// <summary>
        /// Edit Value data from the server.
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
