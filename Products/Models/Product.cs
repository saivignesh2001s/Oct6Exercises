using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    {
        [Required()]
        public int prodId
        {
            get;
            set;
        }
        [MaxLength(20,ErrorMessage ="Can't be more than 20 characters")]
        [MinLength(3,ErrorMessage ="Can't be more than 3 characters")]
        public string productname
        {
            get;
            set;
        }
        public int quantity
        {
            get;
            set;
        }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Mfgdate
        {
            get;
            set;
        }
    }
}