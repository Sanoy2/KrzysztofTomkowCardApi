using AutoMapper;
using Common;
using Dapper;
using Quotations.Models;
using Quotations.Models.DbModels;
using Quotations.Models.Domain;
using Quotations.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Quotations.Persistence.Implementation
{
    public class DapperAuthorsRepository : IAuthorsRepository
    {
        private readonly ILanguageTransformer languageTransformer;
        private readonly IMapper mapper;
        string connectionString = "Server=DESKTOP-LIMAIIE\\SQLEXPRESS;Database=ktSite;Trusted_Connection=True;";

        public DapperAuthorsRepository(ILanguageTransformer languageTransformer, IMapper mapper)
        {
            this.languageTransformer = languageTransformer;
            this.mapper = mapper;
        }

        public IEnumerable<Author> Get()
        {
            List<Author> authors = new List<Author>();

            var sqlAuthor = @"
            SELECT 
            Id,
            Name
            FROM Authors WITH(NOLOCK);";

            var sqlQuotations = @"
            SELECT 
            Id,
            AuthorId,
            Content,
            LanguageId AS Language
            FROM Quotations WITH(NOLOCK);";

            using(var connection = new SqlConnection(this.connectionString))
            {
                using (var multiQuery = connection.QueryMultiple(sqlAuthor + sqlQuotations))
                {
                    var authorsDbModel = multiQuery.Read<AuthorDbModel>().ToList();

                    var quotationsDbModel = multiQuery.Read<QuotationsDbModel>().ToList();


                    foreach(AuthorDbModel authorDbModel in authorsDbModel)
                    {
                        authorDbModel.Quotations = quotationsDbModel.Where(n => n.AuthorId == authorDbModel.Id).ToList();
                    }

                    authors = this.mapper.Map<List<Author>>(authorsDbModel);

                    //var parent = multiQuery.Read<AuthorDbModel>().First();
                    //parent.Quotations = multiQuery.Read<QuotationsDbModel>().ToList();

                    //var author = new Author(parent.Name);
                    //author.AddQuotation(parent.Quotations.First().Content, this.languageTransformer.Transform(parent.Quotations.First().Language));
                    //authors.Add(author);
                }
            }

            return authors;
        }

        public Author Get(string name)
        {
            return this.Get().First(n => n.Name.ToLowerInvariant().Trim() == name.ToLowerInvariant().Trim());
        }

        public Author Get(Guid authorId)
        {
            return this.Get().Single(n => n.Id == authorId);
        }

        public Author Save(Author author)
        {
            throw new NotImplementedException();
        }   
    }
}
