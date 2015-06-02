﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.Entities
{
    public class WallMessage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public string UserId { get; set; }

        public Lazy<IEnumerable<WallComment>> Comments { get; set; }
    }
}