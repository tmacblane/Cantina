using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PornCantina.Models;

namespace PornCantina.ViewModels
{
    public class ModelCreateEditViewModel
    {
        #region Fields

        private Model model = new Model();

        #endregion

        #region Type specific properties

        public Model Model
        { 
            get; 
            set; 
        }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a web site")]
        public Guid SelectedWebSite
        {
            get;
            set;
        }

        [Required]
        public List<SelectListItem> WebSites
        {
            get
            {
                return model.GetWebSiteList();
            }
        }

        #endregion
    }
}