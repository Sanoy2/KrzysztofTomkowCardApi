using AutoMapper;
using Common;
using Quotations.Models.DbModels;
using Quotations.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quotations.Infrastructure
{
    public class QuotationsMapperProfile : Profile
    {
        private readonly ILanguageTransformer languageTransformer;

        public QuotationsMapperProfile(ILanguageTransformer languageTransformer)
        {
            this.languageTransformer = languageTransformer;

            this.CreateMap<QuotationsDbModel, Quotation>()
                .ForMember(dest => dest.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, cfg => cfg.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Content, cfg => cfg.MapFrom(src => src.Content))
                .ForMember(dest => dest.Language, cfg => cfg.MapFrom(src => this.languageTransformer.Transform(src.Language)));

            this.CreateMap<Quotation, QuotationsDbModel>()
                .ForMember(dest => dest.Id, cfg => cfg.MapFrom(src => src.Id))
                .ForMember(dest => dest.AuthorId, cfg => cfg.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.Content, cfg => cfg.MapFrom(src => src.Content))
                .ForMember(dest => dest.Language, cfg => cfg.MapFrom(src => src.Language.ToString()));

            this.CreateMap<AuthorDbModel, Author>()
                .ForMember(dest => dest.Quotations, cfg => cfg.MapFrom(src => src.Quotations));
        }
    }
}
