using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SahaBT.Core.EntityFramework.DatabaseContext;
using SahaBT.Service.AutoMapper.Profiles;
using SahaBT.Service.Extensions;
using SahaBT.Service.Utilities.Filter;
using SahaBT.Service.Utilities.Logger;
using SahaBT.Service.Utilities.Validator;
using SahaBT.Shared.Validator;

namespace SahaBT.API
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
            services.LoadMyServices();
            services.AddControllers(o =>
            {
                o.Filters.Add(typeof(ValidationFilter));
                o.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            })
            .AddFluentValidation(opt => {
                opt.RegisterValidatorsFromAssemblyContaining<StudentValidator>();
                opt.RegisterValidatorsFromAssemblyContaining<StudentLessonValidator>();
                opt.RegisterValidatorsFromAssemblyContaining<PagingValidator>();
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SahaBT.API", Version = "v1" });
            });
            services.AddDbContext<SahaBTContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SahaBTDbContext")));
            services.AddAutoMapper(typeof(LessonProfile), typeof(StudentProfile), typeof(StudentLessonProfile));
            services.AddDistributedRedisCache(option => {
                option.Configuration = "127.0.0.1:6379";
                option.InstanceName = "master";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SahaBT.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseExceptionMiddleware();
        }
    }
}
