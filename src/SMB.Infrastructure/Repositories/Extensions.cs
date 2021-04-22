
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SMB.Core.Domain;
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

			BsonClassMap.RegisterClassMap<Product>(cm =>
			{
				cm.AutoMap();
			});

			services.AddScoped<IProductRepository, ProductRepository>();
		}

	}
}