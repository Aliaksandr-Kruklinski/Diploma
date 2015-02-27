using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialNetwork.Domain.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string UserID { get; set; }
        public string DialogID { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
