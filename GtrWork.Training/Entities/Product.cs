
using GtrWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtrWork.Training.Entities
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public string Product_Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public double Price { get; set; }
        public DateTime LastPurchaseDate { get; set; }
       // public string ImagePath { get; set; }
        public string Status { get; set; }
    }
}
