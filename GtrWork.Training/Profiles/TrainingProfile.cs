using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EO = GtrWork.Training.Entities;
using BO = GtrWork.Training.BusinessObjects;

namespace GtrWork.Training.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<EO.Product, BO.Product>().ReverseMap();
            
        }
        
    }
}
