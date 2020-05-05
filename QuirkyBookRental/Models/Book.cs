using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuirkyBookRental.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("ISBN")]
        public string ISBN { get; set; }

        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required]
        [DisplayName("Description")]
        public string Description { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [DisplayName("Pages")]
        public int Pages { get; set; }

        [Required]
        [DisplayName("Date Added")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAdded { get; set; }

        [Required]
        [DisplayName("Publisher")]
        public string Publisher { get; set; }

        [Required]
        [DisplayName("Publication Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublicationDate { get; set; }

        [Required]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; }

        [Required]
        [DisplayName("Product Dimensions")]
        public string ProductDimensions { get; set; }

        [Required]
        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [Required]
        [DisplayName("Avaibility")]
        [Range(0, 1000)]
        public int Avaibility { get; set; }
    }
}