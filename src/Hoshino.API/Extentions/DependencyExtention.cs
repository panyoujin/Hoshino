using System;
using Microsoft.Extensions.DependencyInjection;
using Hoshino.Repository;
using Hoshino.IRepository;
namespace Hoshino.API.Extentions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DependencyExtention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void RegisDependency(this IServiceCollection services)
        {
            services.AddScoped<Ib_appointment_consultation_Repository, b_appointment_consultation_Repository>();
            services.AddScoped<Ib_banner_resources_Repository, b_banner_resources_Repository>();
            services.AddScoped<Ib_category_Repository, b_category_Repository>();
            services.AddScoped<Ib_contact_Repository, b_contact_Repository>();
            services.AddScoped<Ib_product_Repository, b_product_Repository>();
            services.AddScoped<Ib_product_attribute_Repository, b_product_attribute_Repository>();
            services.AddScoped<Ib_product_resources_Repository, b_product_resources_Repository>();
            services.AddScoped<Ib_rel_product_Repository, b_rel_product_Repository>();
            services.AddScoped<Ib_video_resources_Repository, b_video_resources_Repository>();
            services.AddScoped<Ilog_info_Repository, log_info_Repository>();
            services.AddScoped<Isys_user_Repository, sys_user_Repository>();
            services.AddScoped<Ib_logo_resources_Repository, b_logo_resources_Repository>();
        }
    }
}

