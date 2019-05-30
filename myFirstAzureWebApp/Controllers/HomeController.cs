using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using myFirstAzureWebApp.Models;
using RestSharp;
using static myFirstAzureWebApp.Models.ZomatoResponse;

namespace myFirstAzureWebApp.Controllers
{
    public class HomeController : Controller
    {
        private String PIXABAY_ENDPOINT = "https://pixabay.com/api";
        private String PIXABAY_APIKEY = "12623552-47b72d49abdf1f45df05805a1";

        private String ZOMATO_ENDPOINT = "https://developers.zomato.com/api/v2.1/search";
        private String ZOMATO_APIKEY = "0547de01afb74918a2da9a17608b0b21";

  

        public ActionResult Index()
        {

            var model = getData();
            ViewBag.Title = "Find Food";
            
            return View(model);
        }


  
        public List<ViewDTO> getData()
        {
            List<ViewDTO> viewData = new List<ViewDTO>();
            var imageData = getImages();
            for (var i = 0; i < imageData.Count; i++)
            {
                var restaurtantData = getRestaurant(imageData[i].tags);
                ViewDTO viewDTO = new ViewDTO();
                viewDTO.imageURl = imageData[i].imageURl;
                if (restaurtantData.Count == 3)
                {
                    viewDTO.restaurant1 = restaurtantData[0];
                    viewDTO.restaurant2 = restaurtantData[1];
                    viewDTO.restaurant3 = restaurtantData[2];
                    viewData.Add(viewDTO);
                }

            }

            return viewData;
            
        }

        public List<PixabayDTO> getImages()
        {
            var client = new RestClient(PIXABAY_ENDPOINT);
            var request = new RestRequest(Method.GET);
            request.AddParameter("key", PIXABAY_APIKEY);
            request.AddParameter("q", "food");
            request.AddParameter("safesearch", true);
            var result = client.Execute(request);


            PixabayResponse pixabayResponse = new JavaScriptSerializer().Deserialize<PixabayResponse>(result.Content);
            List<PixabayDTO> dtoItems = new List<PixabayDTO>();
            foreach (var item in pixabayResponse.hits)
            {
                var pixabayDTOItem = new PixabayDTO();
                pixabayDTOItem.imageURl = item.largeImageURL;
                pixabayDTOItem.tags = item.tags;
                dtoItems.Add(pixabayDTOItem);
            }

            return dtoItems;
        }

        public List<ZomatoDOT> getRestaurant(String imageTags)
        {
            System.Diagnostics.Debug.WriteLine("Im here");
            var client = new RestClient(ZOMATO_ENDPOINT);
            var request = new RestRequest(Method.GET);
            request.AddHeader("user-key", ZOMATO_APIKEY);
            request.AddParameter("q", imageTags);
            var result = client.Execute(request);
            System.Diagnostics.Debug.WriteLine(result.Content);

            ZomatoResponse.RootObject jsonResult = new JavaScriptSerializer().Deserialize<ZomatoResponse.RootObject>(result.Content);

            List<Restaurant> results = jsonResult.restaurants;
            List<ZomatoDOT> zomatoDOTs = new List<ZomatoDOT>();

            var count = results.Count;
            // Filters out images that do not have more than three restuarants associated
            if (count > 3)
            {
                count = 3;
            }
            for (int i = 0; i < count; i++)
            {
                ZomatoDOT restaurant = new ZomatoDOT();
                restaurant.name = results[i].restaurant.name;
                restaurant.url = results[i].restaurant.url;
                zomatoDOTs.Add(restaurant);
            }
            return zomatoDOTs;
        }

        public ActionResult About()
        {
            ViewBag.Message = "This quick application pull food pictures from pixabay and uses the tags to search zomato for nearby restaurants. Hosted using azure cloud services.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact me through my email";

            return View();
        }
    }
}