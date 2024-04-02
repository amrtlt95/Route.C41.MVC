using AutoMapper;
using Route.C41.MVC.DAL.Models;
using Route.C41.MVC.PL.ViewModels.Employee;
using System.Collections.Generic;

namespace Route.C41.MVC.PL.Helpers.AutoMappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();/*.ForMember(d => d.Name ,o=> o.MapFrom( s => s.Name))*/
            //.ForMember(d => d.Age, o => o.MapFrom(s => s.Age));

           
        }
    }
}
