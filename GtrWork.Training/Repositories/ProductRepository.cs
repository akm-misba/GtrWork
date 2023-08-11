﻿using GtrWork.Data;
using GtrWork.Training.Context;
using GtrWork.Training.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtrWork.Training.Repositories
{
    public class ProductRepository : Repository<Product, int>,
        IProductRepository
    {
        public ProductRepository(ITrainingContext context)
             : base((DbContext)context)
        {

        }
    }
}
