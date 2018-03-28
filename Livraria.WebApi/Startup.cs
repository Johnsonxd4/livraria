using FluentValidation.AspNetCore;
using Livraria.DTO.Livro;
using Livraria.Interfaces;
using Livraria.Repositorio;
using Livraria.Servicos.nsLivro;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Livraria.WebApi
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
            services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase("livros"));
            services.AddTransient<ILivroServico, LivroServico>();
            services.AddTransient<IUnityOfWork, UnityOfWork>();
            
            services.AddMvc()
                .AddFluentValidation(fvc =>
                {
                    fvc.RegisterValidatorsFromAssemblyContaining<LivroDTO.Atualizar>();
                });
            services.AddCors();

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder =>
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin()
            );
            app.UseMvc();
        }
    }
}
