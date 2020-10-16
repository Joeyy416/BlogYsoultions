using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleBloggingSystem.Models
{
    public class Article
    {
        public int Id { get; set; }
        public DateTime PublishingDate { get; set; }
        [Required(ErrorMessage ="The article is mandatory")]
        public string ArticleBody { get; set; }

        //Navigation Properties
        [Required]
        public virtual User ArticleOwner { get; set; }
        public virtual IList<Comment> Comments { get; set; }
        [Required(ErrorMessage = "The category is mandatory")]
        public virtual Category Category { get; set; }

    }
}