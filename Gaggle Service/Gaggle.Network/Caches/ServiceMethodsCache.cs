using GaggleService.Network;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace GaggleService.Gaggle.Network.Caches
{
    public class ServiceMethodsCache
    {
        private static Dictionary<string, MethodInfo> _serviceMethodsCache;

        public static void Create(IServiceMethods serviceMethods)
        {
            _serviceMethodsCache = new Dictionary<string, MethodInfo>();

            foreach (MemberInfo memberInfo in serviceMethods.GetType().GetMembers(BindingFlags.Public | BindingFlags.Instance))
            {
                if (memberInfo.MemberType.Equals(MemberTypes.Method))
                {
                    var methodInfo = serviceMethods.GetType().GetMethod(memberInfo.Name, BindingFlags.Public | BindingFlags.Instance);
                    _serviceMethodsCache.Add(memberInfo.Name, methodInfo);
                }
            }
        }

        public static bool TryGetValue(string methodName, out MethodInfo methodInfo)
        {
            return _serviceMethodsCache.TryGetValue(methodName, out methodInfo);
        }
    }
}
