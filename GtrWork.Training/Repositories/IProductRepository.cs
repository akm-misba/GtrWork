
using GtrWork.Data;
using GtrWork.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtrWork.Training.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}
