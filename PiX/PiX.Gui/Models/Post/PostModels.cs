using PiX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiX.Gui.Models.Post
{
    public class PostModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is mandatory"), StringLength(60, MinimumLength = 3,ErrorMessage ="Title needs to be longer !"), RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage = "This field must begin with a capital letter, and should contain only alphabetic characters")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [HiddenInput(DisplayValue = false)]
        public DateTime PostDateTime { get; set; }

        [Required, DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string Image { get; set; }
        public Privacy Privacy { get; set; }
        //public SelectList Privacy { get; set; }
        public User User { get; set; }
    }
}