using System;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependecyInjectionAPI
    {
        //Método para adicionar as configurações de services 
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            //registrando o contexto com o ApplicationDbContext
            //Definindo provedor, definindo a string de conexao
            //Informando que a migração vai ficar na pasta do arquivo de contexto
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            //registrando o serviços de repositorios (para projeto web o sugerido é o AddScoped
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //registrando os serviços
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            //registrando o automapperAddMaps
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            //registrando o serviço do mediator
            var myHandlers = AppDomain.CurrentDomain.Load("CleanArchMvc.Application");

            services.AddMediatR(myHandlers);
          //  services.AddMediatR(myHandlers);
                   

            return services;
        }
    }
}
