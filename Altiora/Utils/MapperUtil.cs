using Altiora.Extensions;
using Newtonsoft.Json;

namespace Altiora.Utils
{
    public static class MapperUtil
    {
        public static List<TDestination> MapList<TSource, TDestination>(List<TSource> source)
        {
            var sourceJson = source.ToJson();
            List<TDestination> destination = JsonConvert.DeserializeObject<List<TDestination>>(sourceJson);

            return destination;
        }

        public static TDestination Map<TSource,TDestination>(TSource source)
        {
            var sourceJson = source.ToJson();
            TDestination destination = JsonConvert.DeserializeObject<TDestination>(sourceJson);

            return destination;
        }
    }
}
