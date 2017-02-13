using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WebShop.Model;
using WebShop.Repository;
using WebShop.Services.Interfaces;

namespace WebShop.Services.Implementations
{
    public abstract class BaseService : IBaseService
    {
        protected readonly IDbContext _dbContext;
        protected readonly UnitOfWork _unitOfWork;
        protected IMapper _mapper;

        protected BaseService(IDbContext dbContext, UnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
        protected void SetupAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerViewModel>()
                    .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                    .ForMember(d => d.CellPhone, opt => opt.MapFrom(s => s.CellPhone))
                    .ForMember(d => d.FName, opt => opt.MapFrom(s => s.FName))
                    .ForMember(d => d.LName, opt => opt.MapFrom(s => s.LName))
                    .ForMember(d => d.LandPhone, opt => opt.MapFrom(s => s.LandPhone))
                    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdCustomer)
                    ).ReverseMap();

                cfg.CreateMap<Order, OrderViewModel>()
                   .ForMember(d => d.Comments, opt => opt.MapFrom(s => s.Comments))
                   .ForMember(d => d.DeliveryDate, opt => opt.MapFrom(s => s.DeliveryDate))
                   .ForMember(d => d.FromTime, opt => opt.MapFrom(s => s.FromTime))
                   .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate))
                   .ForMember(d => d.ToTime, opt => opt.MapFrom(s => s.ToTime))
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdOrder)
                   ).ReverseMap();

            });

            _mapper = config.CreateMapper();
        }
    }
}
