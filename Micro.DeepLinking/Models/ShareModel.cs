using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Micro.DeepLinking.Models
{
    public class ShareModel
    {
        public ShareModel()
        {
            Locale = "en_GB";
            Type = "article";
        }

        public string Description { get; set; }
        public string Title { get; set; }
        public string ShareLink { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Locale { get; set; }
    }
}