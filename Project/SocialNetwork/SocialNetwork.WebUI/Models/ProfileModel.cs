using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.WebUI.Models
{
    [Serializable]
    public class UserInfo
    {
        [DataType(DataType.Text)]
        [Display(Name = "Surname: ")]
        public string Surname { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Birthday: ")]
        public DateTime Birthday { get; set; }

        [Display(Name = "PageSize: ")]
        public int PageSize { get; set; }
    }
}