using Autofac;
using AutoMapper;
using GtrWork.Training.BusinessObjects;
using GtrWork.Training.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GtrWork.Areas.Admin.Models
{
    public class EditProductModel
    {
       
        public int? Id { get; set; }
        public string Product_Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public double Price { get; set; }
        public DateTime LastPurchaseDate { get; set; }
       
        public string Status { get; set; }

        private readonly IProductService _productService;
        private readonly IMapper _mapper;



        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _mapper = Startup.AutofacContainer.Resolve<IMapper>();


        }
        public void LoadDataModel(int id)
        {


            var product = _productService.GetProduct(id);
            _mapper.Map(product, this);


        }

        internal void Update()
        {

            var product = _mapper.Map<Product>(this);
            _productService.UpdateProduct(product);
        }

        //public void LoadModelData(int id)
        //{
        //    var product = _productService.GetProduct(id);
        //    Id = (int)(product?.Id);
        //    Product_Id = product?.Product_Id;
        //    BrandName = product?.BrandName;
        //    ModelName = product?.ModelName;
        //    Price = (double)(product?.Price);
        //    LastPurchaseDate = (DateTime)(product?.LastPurchaseDate);
        //    Status = product?.Status;

        //}

        //internal void Update()
        //{
        //    var product = new Product
        //    {
        //        Id = Id.HasValue ? 0 : Id.Value,
        //        Product_Id = Product_Id,
        //        BrandName = BrandName,
        //        ModelName = ModelName,
        //        Price = Price,
        //        LastPurchaseDate = LastPurchaseDate,
        //        Status = Status


        //    };
        //    _productService.UpdateProduct(product);
        //}

        //internal void LoadDataModel(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void LoadDataModel(int id)
        //{
        //    var product = _productService.GetProduct(id);
        //    Id = (int)(product?.Id);
        //    Product_Id = product?.Product_Id;
        //    BrandName = product?.BrandName;
        //    ModelName = product?.ModelName;
        //    Price = (double)(product?.Price);
        //    LastPurchaseDate = (DateTime)(product?.LastPurchaseDate);
        //    Status = product?.Status;
        //}
    }
}
