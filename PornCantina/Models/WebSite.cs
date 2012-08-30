using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PornCantina.Models
{
    public class WebSite
    {
        private PornCantinaContext db = new PornCantinaContext();

        #region Type specific properties

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReferralLink { get; set; }
        public string RSSFeed { get; set; }

        #endregion

        #region Type specific methods


        #endregion
    }
}