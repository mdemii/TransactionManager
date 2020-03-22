using AutoMapper;
using DataAccess.EFCore.Entities;
using DataAccess.Models;
using Service.DataTransferObjects;

namespace TransactionWebApi.Automapper.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionEntity, TransactionModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.TransactionStatus));

            CreateMap<TransactionModel, TransactionDto>()
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => $"{src.Amount} {src.Currency.Code}")) //Payment = Amount + CurrencyCode
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ShortName));        //Status in unified format
        }
    }
}
