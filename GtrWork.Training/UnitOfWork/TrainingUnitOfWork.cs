
using GtrWork.Data;
using GtrWork.Training.Context;
using GtrWork.Training.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtrWork.Training.UnitOfWorks
{
    public class TrainingUnitOfWork : UnitOfWork, ITrainingUnitOfWork
    {
        public IProductRepository Products { get; private set; }
       
        public TrainingUnitOfWork(ITrainingContext context,
            IProductRepository products
          
            ) : base((DbContext)context)
        {
            Products = products;
           
        }
    }
}
