using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCorpHRportal.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }    
        public string Content { get; set; }    
        public Category Category { get; set; }
    }
}