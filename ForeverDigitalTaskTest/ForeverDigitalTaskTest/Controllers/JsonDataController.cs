using ForeverDigitalTaskTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace ForeverDigitalTaskTest.Controllers
{
    public class JsonDataController : ApiController
    {
        /// <summary>
        /// Gets filtered posts from the placeholder Json
        /// </summary>
        /// <param name="searchKeyword">Search keyword used to filter the posts with ignoring case</param>
        /// <returns>Returns collection of filtered posts. If no search keyword is passed, then returns all posts.</returns>
        public IHttpActionResult Get(string searchKeyword = null)
        {
            List<PostContent> posts = new List<PostContent>();
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
                    //HTTP GET
                    var responseTask = client.GetAsync("posts");
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<List<PostContent>>();
                        readTask.Wait();

                        posts = readTask.Result;
                    }
                }
                catch (Exception)
                {
                    return Ok(new HttpError("Something went wrong"));
                }
            }
            if (!string.IsNullOrEmpty(searchKeyword))
                return Ok(posts.Where(x => x.body.ToLower().Contains(searchKeyword.ToLower())).OrderBy(x => x.id));
            else
                return Ok(posts.OrderBy(x => x.id));
        }
    }
}
