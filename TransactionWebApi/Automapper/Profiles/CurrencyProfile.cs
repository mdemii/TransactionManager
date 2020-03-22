using AutoMapper;
using DataAccess.EFCore.Entities;
using DataAccess.Models;

namespace TransactionWebApi.Automapper.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<CurrencyEntity, CurrencyModel>();
        }
    }
}
