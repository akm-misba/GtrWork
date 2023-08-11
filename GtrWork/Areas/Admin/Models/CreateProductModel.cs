using Autofac;
using AutoMapper;
using GtrWork.Common.Utilities;
using GtrWork.Training.BusinessObjects;
using GtrWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtrWork.Areas.Admin.Models
{
    public class CreateProductModel
    {
        public int Id { get; set; }
        public string Product_Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public double Price { get; set; }
        public DateTime LastPurchaseDate { get; set; }
      
        public string Status { get; set; }

        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CreateProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();
        }

       

        public CreateProductModel(IProductService productService , IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        internal void CreateProduct()
        {
            var product = new Product()
            //product.Id = Id;
            //product.LastPurchaseDate = LastPurchaseDate;
            {
                Id = Id,
                LastPurchaseDate = LastPurchaseDate,
                BrandName = BrandName,
                ModelName = ModelName,
                Product_Id = Product_Id,
                Status = Status,
                Price = Price
            };
            //var product = _mapper.Map<Product>(this);

            _productService.CreateProduct(product);

        }


       
    }
}
