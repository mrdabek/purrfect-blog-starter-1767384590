using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PurrfectBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}