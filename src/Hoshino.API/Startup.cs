using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hoshino.API.Extentions;
using Pan.Code.Middleware;
using Swashbuckle.AspNetCore.Swagger;

namespace Hoshino.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var Connections = Configuration.GetConnectionString("Connections") ?? "";
            foreach (var con in Connections.Split(','))
            {
                DBHelper.SQLHelper.SQLHelperFactory.Instance.ConnectionStringsDic[con] = Configuration.GetConnectionString(con);
            }
            services.AddMvc(config =>{}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.RegisDependency();
            services.AddSwaggerGen(c =>{c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });});
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()){ app.UseDeveloperExceptionPage(); }
            else{ app.UseHsts(); }
            app.UseMiddleware<UserExceptionHandlerMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>{ c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseMvc();
        }
    }
}
