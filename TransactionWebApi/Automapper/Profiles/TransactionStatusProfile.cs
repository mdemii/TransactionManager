using AutoMapper;
using DataAccess.EFCore.Entities;
using DataAccess.Models;

namespace TransactionWebApi.Automapper.Profiles
{
    public class TransactionStatusProfile : Profile
    {
        public TransactionStatusProfile()
        {
            CreateMap<TransactionStatusEntity, TransactionStatusModel>();
        }
    }
}
