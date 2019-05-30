﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myFirstAzureWebApp.Models
{
    public class ZomatoResponse
    {
        public class R
        {
            public int res_id { get; set; }
        }

        public class Location
        {
            public string address { get; set; }
            public string locality { get; set; }
            public string city { get; set; }
            public int city_id { get; set; }
            public string latitude { get; set; }
            public string longitude { get; set; }
            public string zipcode { get; set; }
            public int country_id { get; set; }
            public string locality_verbose { get; set; }
        }

        public class UserRating
        {
            public object aggregate_rating { get; set; }
            public string rating_text { get; set; }
            public string rating_color { get; set; }
            public object votes { get; set; }
        }

        public class Restaurant2
        {
            public R R { get; set; }
            public string apikey { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public Location location { get; set; }
            public int switch_to_order_menu { get; set; }
            public string cuisines { get; set; }
            public int average_cost_for_two { get; set; }
            public int price_range { get; set; }
            public string currency { get; set; }
            public List<object> offers { get; set; }
            public int opentable_support { get; set; }
            public int is_zomato_book_res { get; set; }
            public string mezzo_provider { get; set; }
            public int is_book_form_web_view { get; set; }
            public string book_form_web_view_url { get; set; }
            public string book_again_url { get; set; }
            public string thumb { get; set; }
            public UserRating user_rating { get; set; }
            public string photos_url { get; set; }
            public string menu_url { get; set; }
            public string featured_image { get; set; }
            public int has_online_delivery { get; set; }
            public int is_delivering_now { get; set; }
            public bool include_bogo_offers { get; set; }
            public string deeplink { get; set; }
            public int is_table_reservation_supported { get; set; }
            public int has_table_booking { get; set; }
            public string events_url { get; set; }
            public List<object> establishment_types { get; set; }
        }

        public class Restaurant
        {
            public Restaurant2 restaurant { get; set; }
        }

        public class RootObject
        {
            public int results_found { get; set; }
            public int results_start { get; set; }
            public int results_shown { get; set; }
            public List<Restaurant> restaurants { get; set; }
        }
    }

    public class ZomatoDOT
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}