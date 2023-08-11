using AutoMapper;
using GtrWork.Common.Utilities;
using GtrWork.Training.BusinessObjects;
using GtrWork.Training.Exceptions;
using GtrWork.Training.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtrWork.Training.Services
{
    public class ProductService : IProductService
    {
        private readonly ITrainingUnitOfWork _trainingUnitOfWork;
        private readonly IDateTimeUtility _dateTimeUtility;
        private readonly IMapper _mapper;
        public ProductService(ITrainingUnitOfWork trainingUnitOfWork,
            IDateTimeUtility dateTimeUtility,
            IMapper mapper)
        {
            _trainingUnitOfWork = trainingUnitOfWork;
            _dateTimeUtility = dateTimeUtility;
            _mapper = mapper;

        }

    

        public void CreateProduct(Product prod)
        {
             if (prod == null)
                throw new invalidPerameterException("Product details was not provided");

            //_trainingUnitOfWork.Products.Add(
            //_mapper.Map<Entities.Product>(product)
            //);
            //
            if (IsAlreadyUsed(prod.ModelName))
                throw new invalidPerameterException("Model Name Already Used");
            if (!IsValidLastPurchaseDate(prod.LastPurchaseDate))
                throw new invalidPerameterException("30 days");
            
            _trainingUnitOfWork.Products.Add(new Entities.Product
            {
                Id=prod.Id,
                BrandName=prod.BrandName,
                ModelName=prod.ModelName,
                LastPurchaseDate=prod.LastPurchaseDate,
                Product_Id=prod.Product_Id,
                Status=prod.Status
                
            });
               
            _trainingUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            _trainingUnitOfWork.Products.Remove(id);
            _trainingUnitOfWork.Save();
        }

        //public void Count()
        //{
        //   var Count= _trainingUnitOfWork.Products.GetCount();

        //}
        public IList<Product> GetAllProducts()
        {
            var productEntities = _trainingUnitOfWork.Products.GetAll();
            var products = new List<Product>();

            foreach (var entity in productEntities)
            {
                var product = _mapper.Map<Product>(entity);
                products.Add(product);
            }

            return products;
        }

        public Product GetProduct(int id)
        {
            var product = _trainingUnitOfWork.Products.GetById(id);

            if (product == null) return null;

            return _mapper.Map<Product>(product);
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {

            var productData = _trainingUnitOfWork.Products.GetDynamic(string.IsNullOrWhiteSpace(searchText) ? null :
                 x => x.BrandName.Contains(searchText), sortText, string.Empty,
                  pageIndex, pageSize);

            var resultData = (from product in productData.data
                              select _mapper.Map<Product>(product)).ToList();

            return (resultData, productData.total, productData.totalDisplay);
        }

    

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product is missing");
            if (!IsValidLastPurchaseDate(product.LastPurchaseDate))
                throw new DuplicateTitleException("time 30 Days+");


            var productEntity = _trainingUnitOfWork.Products.GetById(product.Id);

            if (productEntity != null)
            {
                _mapper.Map(product, productEntity);

                _trainingUnitOfWork.Save();

            }
            else
                throw new InvalidOperationException("Couldn't find Product");
        }

        private bool IsAlreadyUsed(string modelName) =>
            _trainingUnitOfWork.Products.GetCount(x => x.ModelName == modelName) > 0;
        private bool IsValidLastPurchaseDate(DateTime lastPurchaseDate) =>
            lastPurchaseDate.Subtract(_dateTimeUtility.Now).TotalDays > 13;
    }
}
