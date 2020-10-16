using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBloggingSystem.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation Properties
        public virtual IList<Article> Articles { get; set; }

    }
}