using System;
using AutoMapper;
using WebShop.Model;
using WebShop.Repository;


namespace WebShop.Services.Mapping
{
    public class RegisterMapping : Profile
    {
        public RegisterMapping()
        {
            CreateMap<Customer, CustomerViewModel>()
                   .ForMember(d => d.Address, opt => opt.MapFrom(s => s.Address))
                   .ForMember(d => d.CellPhone, opt => opt.MapFrom(s => s.CellPhone))
                   .ForMember(d => d.FName, opt => opt.MapFrom(s => s.FName))
                   .ForMember(d => d.LName, opt => opt.MapFrom(s => s.LName))
                   .ForMember(d => d.LandPhone, opt => opt.MapFrom(s => s.LandPhone))
                   .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdCustomer)
                   ).ReverseMap();

            CreateMap<Order, OrderViewModel>()
                  .ForMember(d => d.Comments, opt => opt.MapFrom(s => s.Comments))
                  .ForMember(d => d.DeliveryDate, opt => opt.MapFrom(s => s.DeliveryDate))
                  .ForMember(d => d.FromTime, opt => opt.MapFrom(s => s.FromTime))
                  .ForMember(d => d.OrderDate, opt => opt.MapFrom(s => s.OrderDate))
                  .ForMember(d => d.ToTime, opt => opt.MapFrom(s => s.ToTime))
                  .ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdOrder)
                  ).ReverseMap();


            CreateMap<ItemViewModel, TrOrder>()
                  .ForMember(d => d.IdItem, opt => opt.MapFrom(s => s.IdItem))
                  .ForMember(d => d.ItemKg, opt => opt.MapFrom(s => s.ItemKg)
                  ).ReverseMap();

        }
    }
}
