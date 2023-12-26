using Model.Entities;

namespace NetWebApi.Utils
{
    public static class ExtensionMethods
    {
        public static bool IsFromBuenosAiresExtensions(this Club club, string? name = null)
        {
            return club.City == "BsAs"
                && (name != null && club.Name == name);
        }

        public static List<T> WhereExtension<T>(this List<T> clubs, Func<T, bool> filter)
        {
            List<T> result = new List<T>();

            foreach (T club in clubs)
            {
                if (filter(club))
                {
                    result.Add(club);
                }
            }

            return result;
        }

        public static TSource Second<TSource>(this IEnumerable<TSource> source)
        {
            return source.Skip(1).First();
        }

        public static TSource Third<TSource>(this IEnumerable<TSource> source)
        {
            return source.Skip(2).First();
        }

        public static TSource Fourth<TSource>(this IEnumerable<TSource> source)
        {
            return source.Skip(3).First();
        }
    }
}