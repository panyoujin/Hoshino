using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hoshino.API.Extentions;
using Pan.Code.Middleware;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json.Serialization;

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
            services.AddMvc(config => { }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();//设置时间格式
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.RegisDependency();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }
            else { app.UseHsts(); }
            app.UseMiddleware<UserExceptionHandlerMiddleware>();
            app.UseHttpsRedirection();

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Add("index.html");    //将index.html改为需要默认起始页的文件名.
            app.UseDefaultFiles(options);

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseMvc();
        }
    }
}
