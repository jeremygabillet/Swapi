using System;
using System.Collections.Generic;
using System.Linq;

namespace Swapi
{
    static class ServiceCollection
    {
        private static Dictionary<Type, Type> services = new Dictionary<Type, Type>();

        public static void AddService<T,U>()
        {
            if (services.Keys.Contains(typeof(T)))
                services[typeof(T)] = typeof(U);
            else
                services.Add(typeof(T), typeof(U));
        }

        public static T GetService<T>()
        {
            if (!services.ContainsKey(typeof(T)))
                throw new Exception("Service inconnu");
            return (T)Activator.CreateInstance(services[typeof(T)]);
        }
    }
}
