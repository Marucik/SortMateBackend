
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using SMB.Core.Domain;
using SMB.Core.Domain.ProductRequest;
using SMB.Core.Domain.User;
using SMB.Infrastructure.Mongo;

namespace SMB.Infrastructure.Repositories
{
    public static class Extensions
    {
        private static string _sectionName = "MongoDbSettings";

        public static void AddMongoDb(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            var mongoSettings = new MongoDbSettings();
            configuration.GetSection(_sectionName).Bind(mongoSettings);

            services.AddSingleton(mongoSettings);

            services.AddScoped<IMongoClient>(x =>
            {
                return new MongoClient(mongoSettings.ConnectionString);
            });

            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<SegregationType>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<ProductRequest>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISegregationTypeRepository, SegregationTypeRepository>();
            services.AddScoped<IProductRequestRepository, ProductRequestRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}