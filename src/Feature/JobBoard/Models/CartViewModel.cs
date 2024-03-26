using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Demo.Feature.JobBoard.Models
{
    public class CartViewModel
    {

        public string Title
        {
            get;
            set;
        }

        public List<CartItems> CartItems
        {
            get;
            set;
        }
    }

        public class CartItems
        {
            public string Title { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }

            public int Quantity { get; set; }
        } 
    }
