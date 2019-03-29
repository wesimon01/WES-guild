using BlogEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogEngine.UI.Viewmodels
{
    public class CreatePostVM
    {
        public Blogpost Post { get; set; }
        public string Tags { get; set; }

        public CreatePostVM()
        {
            Post = new Blogpost();
        }
    }
}