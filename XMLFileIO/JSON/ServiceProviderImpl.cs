using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.Linq;

namespace FileIO.Json {
	public class ServiceProviderImpl : IServiceProvider {
		private readonly IServiceProvider? _parentServiceProvider;
		private readonly Dictionary<Type, Func<IServiceProvider, object>> _services = new Dictionary<Type, Func<IServiceProvider, object>>();

    public ServiceProviderImpl(IServiceProvider parentServiceProvider = null) {
      _parentServiceProvider = parentServiceProvider;
    }

    public void AddTransient(Type key, Func<IServiceProvider, object>? func) {
      _services[key] = func;
    }

    public bool IsRegistered<T>() {
      return IsRegistered(typeof(T));
    }

    public bool IsRegistered(Type serviceType) {
      return _services.ContainsKey(serviceType);
    }

    public List<Type> GetRegistered() {
      return _services.Keys.ToList();
    }

    #region Реализация IServiceProvider
    public object GetService(Type serviceType) {
      if (_services.ContainsKey(serviceType)) {
        if (_services[serviceType] is { } service) {
          return service.Invoke(this);
        }
        if (serviceType.IsClass
          && serviceType.GetConstructor(new Type[] { }) is { }) {
          object result = _parentServiceProvider?
                  .GetService(serviceType);
          if (result is { }) {
            return result;
          }
          return Activator.CreateInstance(serviceType);
        }
      }
      return _parentServiceProvider?.GetService(serviceType);
    }
    #endregion

	}
}
