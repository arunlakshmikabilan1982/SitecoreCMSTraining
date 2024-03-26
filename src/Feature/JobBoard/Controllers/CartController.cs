using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Demo.Feature.JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Demo.Feature.JobBoard.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cart()
        {

            CartViewModel model = new CartViewModel();

            var item = RenderingContext.Current.Rendering.Item;

            if(item != null && item.Fields != null)
            {
                model.Title = item.Fields["Title"].Value;
                var cartList = new MultilistField(item.Fields["CartItems"]).GetItems();
                var cartItemList = new List<CartItems>();
                foreach(var cart in cartList)
                {
                    var cartItem = new CartItems();

                    cartItem.Title = cart.Fields["Title"]?.Value;
                    cartItem.Description = cart.Fields["Description"]?.Value;

                    ImageField imgField = ((ImageField)cart.Fields["Image"]);
                    cartItem.Image = Sitecore.Resources.Media.MediaManager.GetMediaUrl(imgField.MediaItem);


                    cartItem.Price = System.Convert.ToInt32(cart.Fields["Price"].Value);
                    cartItem.Quantity = System.Convert.ToInt32(cart.Fields["Quantity"].Value);

                    cartItemList.Add(cartItem);

                }

                model.CartItems = cartItemList;

            }

            return View(model);
        }
    }
}