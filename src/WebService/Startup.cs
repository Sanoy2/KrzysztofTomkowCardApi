using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using FileAccess;
using FileAccess.PhysicalFilesAccess;

using WebService.Configuration;
using WebService.PhysicalFilesAccess;
using WebService.PhysicalFilesAccess.Cv;
using Quotations.Persistence.Interfaces;
using Quotations.Persistence.Fakes;
using Quotations.ApplicationServices;
using Quotations.DomainServices;
using Quotations.Factories;
using Common;
using Common.TextTransformations;
using Quotations.Persistence.Implementation;
using AutoMapper;
using Quotations.Infrastructure;

namespace WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IFilesInfoProvider, FilesInfoProvider>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<ICvFileInfoProvider, CvFileInfoProvider>();

            var generalSettings = this.Configuration.GetSettings<GeneralSettings>();
            services.AddSingleton<GeneralSettings>(generalSettings);
            services.AddSingleton<IAuthorsRepository, DapperAuthorsRepository>();

            services.AddTransient<IQuotationsService, QuotationService>();
            services.AddTransient<IQuotationDomainService, QuotationDomainService>();
            services.AddTransient<IAuthorsService, AuthorsService>();
            services.AddTransient<IAuthorFactory, AuthorFactory>();

            services.AddTransient<ILanguageTransformer, LanguageTransformer>();
            services.AddTransient<ITitleCaseTextTransformer, TitleCaseTextTransformer>();
            services.AddTransient<IStatementTransformer, StatementTransformer>();

            services.AddTransient<IFileProvider>(n => new PhysicalFileProvider(generalSettings.FileStorageMainDirectory));

            var serviceProvider = services.BuildServiceProvider();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new QuotationsMapperProfile(serviceProvider.GetService<ILanguageTransformer>()));
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Card API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Card API V1");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}