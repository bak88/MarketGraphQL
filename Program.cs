
using MarketGraphQL.Abstraction;
using MarketGraphQL.Data;
using MarketGraphQL.Graph.Mutation;
using MarketGraphQL.Graph.Query;
using MarketGraphQL.Mapper;
using MarketGraphQL.Repository;
using Microsoft.EntityFrameworkCore;

namespace MarketGraphQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            // builder.Services.AddSwaggerGen();            
            builder.Services.AddDbContext<StorageContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("db")));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            // builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddSingleton<ProductGroupRepository>().AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();
            builder.Services.AddMemoryCache();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            // app.UseAuthorization();

            app.MapGraphQL();


            // app.MapControllers();

            app.Run();
        }
    }
}
