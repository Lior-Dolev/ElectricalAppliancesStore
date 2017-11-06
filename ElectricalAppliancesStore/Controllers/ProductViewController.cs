using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricalAppliancesStore.Models;
using ElectricalAppliancesStore.Models.Stubs;

namespace ElectricalAppliancesStore.Controllers
{
    public class ProductViewController : Controller
    {
        private ProductView pv;
        private List<Product> products;
        // GET: ProductView
        public ActionResult Products()
        {
            this.products = ProductsStub.GetProducts();
            this.pv = new ProductView()
            {
                products = products,
                currOrder = OrderStub.GetOrder()
                //currOrder = new Order()
            };
            return View(pv);
        }

        public bool UpdateOrder(int itemID, int Quantity)
        {

            try
            {
                // check if such item exist
                Product prod = this.products.First<Product>(p => (p.ID == itemID));

                // if so- check if this id is allready in the order's item-list
                if (prod != null)
                {
                    OrderItem oit = this.pv.currOrder.Items.First<OrderItem>(o => o.Product.ID == itemID);

                    if (oit == null)
                    {
                        // if not - add the item with the given amount (if amount is not 0)
                        if (Quantity != 0)
                        {
                            this.pv.currOrder.Items.Add(new OrderItem() { ID = itemID, Quantity = Quantity, Product = prod });
                        }
                    }
                    //if item is allready in the order 
                    else
                    {
                        // check if given amount is 0 - and if so - remove the item from the order
                        if (Quantity == 0)
                        {
                            this.pv.currOrder.Items.Remove(oit);
                        }
                        // otherwise - update the item's amount in the order
                        else
                        {
                            oit.Quantity = Quantity;
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}