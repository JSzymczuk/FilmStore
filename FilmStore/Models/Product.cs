using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Desription { get; set; }
        
        public int Quantity { get; set; }
        
        public double? Price { get; set; }

        public double? DiscountPrice { get; set; }

        public string ThumbPath { get; set; }

        public DateTime ActiveFrom { get; set; }

        public bool IsDeleted { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Studio { get; set; }

        [Required]
        public string Director { get; set; }
        
        public string Starring { get; set; }
        
        public int Duration { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public string CoverPath { get; set; }

        public int ProductTypeId { get; set; }

        public Product()
        {
            Positions = new List<OrderPosition>();
            Genres = new List<MovieGenre>();
        }

        [ForeignKey("ProductTypeId")]
        public virtual ProductType ProductType { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }

        public virtual ICollection<OrderPosition> Positions { get; set; }
    }

    public class ProductType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ProductType() { Products = new List<Product>(); }

        public virtual ICollection<Product> Products { get; set; }
    }

    public class MovieGenre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public MovieGenre() { Products = new List<Product>(); }

        public virtual ICollection<Product> Products { get; set; }
    }
}