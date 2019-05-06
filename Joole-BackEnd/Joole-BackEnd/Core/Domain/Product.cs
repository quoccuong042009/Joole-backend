using Joole_BackEnd.Core.Domain.ManyToMany;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Joole_BackEnd.Core.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int SeriesId { get; set; }
        public Series Series { get; set; }
        public int ProdDocId { get; set; }
        public ProdDoc ProdDoc { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public ICollection<ProjToProd> Projects { get; set; }
        public Product()
        {
            Projects = new Collection<ProjToProd>();
        }
    }
}