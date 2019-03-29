using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Models
{
    public class Blogpost
    {
        public int PostId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime datePublished { get; set; }
        public DateTime dateExpires { get; set; }
        [Required]
        [AllowHtml]
        public string Content { get; set; }
        public bool IsApproved { get; set; }
        public Author Author { get; set; }
        public List<Hashtag> Hashtags { get; set;}
     
        public Blogpost()
        {
            Hashtags = new List<Hashtag>();
            Author = new Author();
            datePublished = DateTime.Now;
            dateExpires = DateTime.Now.AddDays(30);
            Author.AuthorName = "JSON";         
        }
    }
}
