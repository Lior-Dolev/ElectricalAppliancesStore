using ElectricalAppliancesStore.Managers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Models
{
    public class EditProductView
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public int SoldCounter { get; set; }
        public HttpPostedFileBase UploadImages { get; set; }
        public String Description { get; set; }
        public double SalePrice { get; set; }
        public double BuyPrice { get; set; }

        [Display(Name = "Brand")]
        public int SelectedBrandId { get; set; }
        public IEnumerable<SelectListItem> BrandItems { get; set; }

        [Display(Name = "Category")]
        public int SelectedCategoryId { get; set; }
        public IEnumerable<SelectListItem> CategoryItems { get; set; }

        [Display(Name = "Provider")]
        public int SelectedProviderId { get; set; }
        public IEnumerable<SelectListItem> ProviderItems { get; set; }

        public string SelectedPicturePath { get; set; }
        public List<string> PicturesPaths { get; set; }
    }
}