using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WebUI.Models
{
    public class MessagePagingModel
    {
        public IEnumerable<Message> Messages { get; set; }
        public Paginglnfo Paginglnfo { get; set; }
        public string CurrentDialog { get; set; }
    }

    public class Paginglnfo
    {
        public string ControllerName { get; set; }
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            }
        }
    }
}