using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebService.Configuration;
using WebService.PhysicalFilesAccess;
using WebService.PhysicalFilesAccess.Cv;


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

            services.AddTransient<IFileProvider>(n => new PhysicalFileProvider(generalSettings.FileStorageMainDirectory));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
