using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleBloggingSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CommentDate { get; set; }
        [Required(ErrorMessage ="Comment Body is a must")]
        public string CommentBody { get; set; }
        [Required]
        public Boolean IsApproved { get; set; }


        public string reasonForDisApproval { get; set; }
        //Navigation Properties
        [Required]
        public virtual User CommentOwner { get; set; }
        [Required]
        public virtual Article Article { get; set; }


    }
}