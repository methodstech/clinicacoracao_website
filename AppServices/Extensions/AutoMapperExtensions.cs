using System.Collections.Generic;

namespace AppServices.Extensions
{
    internal static class AutoMapperExtensions
    {
        public static T MapTo<T>(this object value)
        {
            return AutoMapper.Mapper.Map<T>(value);
        }

        public static IEnumerable<T> Enumerable<T>(this object value)
        {
            return AutoMapper.Mapper.Map<IEnumerable<T>>(value);
        }
    }
}
