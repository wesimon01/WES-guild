using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogEngine.Models;

namespace BlogEngine.UI.Viewmodels
{
    public class IndexVM
    {
        public List<Blogpost> _blogposts { get; set; }
        public List<Hashtag> _hashtags { get; set;}
    }
}