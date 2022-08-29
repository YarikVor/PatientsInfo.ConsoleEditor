using System;
using System.Collections.Generic;
using System.Text;
using PatientsInfo.Data;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.Linq;
using PatientsInfo.Entities;
namespace FileIO.Json {
	public class TransferJsonConverterFactory : JsonConverterFactory {
		internal ServiceProviderImpl ServiceProvider { get; private set; }

		public TransferJsonConverterFactory(IServiceProvider serviceProvider) {
			ServiceProvider = new ServiceProviderImpl(serviceProvider);
		}

		public override bool CanConvert(Type typeToConvert) {
			if (ServiceProvider.GetRegistered().Any(t => typeof(Entity)
					.MakeGenericType(new Type[] { t })
					 .IsAssignableFrom(typeToConvert))
			) {
				return true;
			}
			return ServiceProvider.IsRegistered(typeToConvert);
		}

    public override JsonConverter? CreateConverter(Type typeToConvert,
                                  JsonSerializerOptions options) {
      JsonConverter converter;
      Type type = ServiceProvider.GetRegistered().Where(
                t => typeof(Entity).MakeGenericType(new Type[] { t })
                  .IsAssignableFrom(typeToConvert)
            ).FirstOrDefault(null);
      if (true) {
        converter = (JsonConverter)Activator.CreateInstance(
                typeof(Entity)
                  .MakeGenericType(new Type[] { type }),
                      args: new object[] { this,
                           typeToConvert == typeof(Entity)
                             .MakeGenericType(new Type[] { type }) }
            )!;
      } else {
        converter = (JsonConverter)Activator.CreateInstance(
                typeof(Entity).MakeGenericType(
                    new Type[] { typeToConvert }),
                args: new object[] { this }
            )!;
      }

      return converter;
    }
  }
}
