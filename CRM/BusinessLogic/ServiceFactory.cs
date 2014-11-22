using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Crm
{
    public static class ServiceFactory
    {
        private static readonly Dictionary<Type, Func<object>> _typeMap = new Dictionary<Type, Func<object>>();

        public static void Register<T>(Func<T> instanceFactory)
        {
            lock (_typeMap) _typeMap.Add(typeof(T), () => instanceFactory());
        }

        public static void Register<T>(IFactory factory)
        {
            lock (_typeMap) _typeMap.Add(typeof(T), factory.GetInstance);
        }

        public static void Override<T>(Func<T> instanceFactory)
        {
            lock (_typeMap) _typeMap[typeof(T)] = () => instanceFactory();
        }

        public static void Override<T>(IFactory factory)
        {
            lock (_typeMap) _typeMap[typeof(T)] = factory.GetInstance;
        }

        public static T Resolve<T>()
        {
            lock (_typeMap) return (T)(_typeMap[typeof(T)]());
        }

        static ServiceFactory()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsClass && !t.IsNested && !t.IsAbstract))
            {
                var attr = type.GetCustomAttribute<ServiceAttribute>();
                if (attr == null) continue;

                var interfaces = type.GetInterfaces().Where(ifc => ifc.IsPublic).ToList();
                if (interfaces.Count <= 0) continue;

                Func<object> factory;
                switch (attr.Option)
                {
                    case ServiceOption.Singleton:
                        factory = new Singleton(type).GetInstance;
                        break;
                    case ServiceOption.PerResolve:
                        factory = new PerResolve(type).GetInstance;
                        break;
                    default:
                        throw new Exception("Invalid instantiation mode");
                }
                foreach (var i in interfaces) _typeMap.Add(i, factory);
            }
        }

        public interface IFactory
        {
            object GetInstance();
        }

        public class Singleton : IFactory
        {
            private readonly object _lock = new object();
            private readonly Type _type;
            private object _instance;

            public object GetInstance()
            {
                lock (_lock)
                    return _instance ?? (_instance = Activator.CreateInstance(_type));
            }

            public Singleton(Type type)
            {
                if (type == null) throw new ArgumentNullException("type");
                _type = type;
            }
        }

        public class Singleton<T> : Singleton
        {
            public Singleton() : base(typeof(T)) { }
        }

        public class PerResolve : IFactory
        {
            private readonly Type _type;

            public object GetInstance()
            {
                return Activator.CreateInstance(_type);
            }

            public PerResolve(Type type)
            {
                if (type == null) throw new ArgumentNullException("type");
                _type = type;
            }
        }

        public class PerResolve<T> : PerResolve
        {
            public PerResolve() : base(typeof(T)) { }
        }
    }
}