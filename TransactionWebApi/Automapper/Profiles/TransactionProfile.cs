using AutoMapper;
using DataAccess.Models;
using Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionWebApi.Automapper.Profiles
{
    public class TransactionProfile : Profile
    {

        public TransactionProfile()
        {
            CreateMap<TransactionModel, TransactionDto>()
                .ForMember(dest => dest.Payment, opt => opt.MapFrom(src => $"{src.Amount} {src.Currency.Code}")) //Payment = Amount + CurrencyCode
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ShortName));        //Status in unified format
        }
    }
}
