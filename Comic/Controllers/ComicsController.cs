using Comic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Comic.Models.DataModels;

namespace Comic.Controllers
{
    public class ComicsController : Controller
    {
        // GET: Comics
        private string apiUrl = "https://comicvine.gamespot.com/api";

        private string apiKey = "5c0f4f1d59a980ce636548b03f80868367f46a9c";

        ComicModelEntities context = new ComicModelEntities();
        static string _name;
        List<ComicModel> _comics;

        public ActionResult Index()
        {
            _comics = new List<ComicModel> { } ;
            _name = String.Empty;
            return View(_comics);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection Form,string submitButton,List<ComicModel> comics)
        {         

            switch (submitButton)
            {
                case "SUBMIT":
                    _name = Form["name"];
                    _comics = Details(_name).Result;
                    return View(_comics);
                case "SAVE":
                    if(ModelState.IsValid)
                    {
                        foreach (var c in comics)
                        {
                            var model = new Comics { Key = _name, Title = c.name };
                            context.Entry(model).State = System.Data.Entity.EntityState.Added;
                            context.SaveChanges();
                        }                       
                        
                    }
                    return RedirectToAction("Index");
                default:
                    // If they've submitted the form without a submitButton, 
                    // just return the view again.
                    return (View());
            }



        }

        // GET: Comics/Details/5
        private async Task<List<ComicModel>> Details(string name = null)
        {
            string url = apiUrl + "/volumes/?api_key=" + apiKey + "&format=json&sort=name:asc&field_list=name&limit=1&filter=name:" + name;
            //url = "https://comicvine.gamespot.com/api/volumes/?api_key=5c0f4f1d59a980ce636548b03f80868367f46a9c&format=json&sort=name:asc&field_list=name&filter=name:Batman";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //HttpResponseMessage response = await client.GetAsync(url);
                //Sample data...json is being converted by right serializer in ReadAsStringAsync
                var data = "{'error':'OK','limit':10,'offset':0,'number_of_page_results':10,'number_of_total_results':1692,'status_code':1,'results':[{'name':'\u00a1Batman y Robin deben Morir!'},{'name':'2000 AD Digest: Batman/ Dredd'},{'name':'3 - D Batman'},{'name':'3 - D Batman'},{'name':'A Legenda de Batman'},{'name':'A Sombra do Batman '},{'name':'A Sombra do Batman '},{'name':'A Sombra do Batman Apresenta: Capuz Vermelho &Arsenal'},{'name':'A Sombra do Batman Apresenta: Grayson '},{'name':'A Sombra do Batman Especial: A Guerra dos Robins'}],'version':'1.0'}";
                int startIndex = data.IndexOf('[');
                int endIndex = data.IndexOf(']');
                data = data.Substring(startIndex, endIndex+1 - startIndex);
                var model = JsonConvert.DeserializeObject<List<ComicModel>>(data);
                return model;
                //if (response.IsSuccessStatusCode)
                //{
                //    var data = await response.Content.ReadAsStringAsync();
                //    int startIndex = data.IndexOf('[');
                //    int endIndex = data.IndexOf(']');
                //    data = data.Substring(startIndex, endIndex + 1 - startIndex);
                //    var values = JsonConvert.DeserializeObject<List<ComicModel>>(data);
                //    return data;

                //}
                //return response.StatusCode.ToString();
            }
        }

        // GET: Comics/Create
        [HttpPost]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comics/Create
        [HttpPost]
        public ActionResult Create(FormCollection Form)
        {
            return View();
        }

        // GET: Comics/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comics/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comics/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comics/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
