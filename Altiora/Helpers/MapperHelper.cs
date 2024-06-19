namespace Altiora.Helpers
{
    public static class MapperHelper
    {
        public static TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            var destinationObject = Activator.CreateInstance<TDestination>();
            if (sourceObject != null)
            {
                foreach (var sourceProperty in typeof(TSource).GetProperties())
                {
                    var destinationProperty =
                    typeof(TDestination).GetProperty
                    (sourceProperty.Name);
                    if (destinationProperty != null && !sourceProperty.PropertyType.Name.ToLower().Contains("icollection"))
                    {
                        destinationProperty.SetValue
                        (destinationObject,
                       sourceProperty.GetValue(sourceObject));
                    }
                }
            }
            return destinationObject;
        }

        public static List<TDestination> MapList<TSource, TDestination>(List<TSource> source)
        {
            var list = new List<TDestination>();

            source.ForEach(x => { list.Add(Map<TSource, TDestination>(x)); });

            return list;
        }
    }
}
