using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectricalAppliancesStore.Models
{
    public class BrandView
    {
        [Display(Name = "Favorite Flavor")]
        public int SelectedBrandId { get; set; }

        public IEnumerable<SelectListItem> BrandItems
        {
            get { return new SelectList(Enum.GetNames(typeof(Brand)), "Id", "Name"); }
        }
    }
}