namespace ChinaExpress.Extensions
{
    public static class Extensions
    {
        public static T FirstOrDefault<T>(ICollection<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                    return item;
            }
            return default(T);
        }

        public static List<T> Where<T>(ICollection<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (var item in source)
            {
                if (predicate(item))
                    result.Add(item);
            }
            return result;
        }

        public static decimal Sum<T>(this ICollection<T> collection, Func<T, decimal> predicate)
        {
            if (collection == null) return 0;

            var sum = 0m;

            foreach (var item in collection)
            {
                sum += predicate(item);
            }

            return sum;
        }

        public static int Sum<T>(this ICollection<T> collection, Func<T, int> predicate)
        {
            var sum = 0;

            foreach (var item in collection)
            {
                sum += predicate(item);
            }

            return sum;
        }

        public static double Average<T>(this ICollection<T> collection, Func<T, double> selector)
        {
            if (collection.Count == 0) return 0;

            var sum = 0d;
            foreach (var item in collection)
            {
                sum += selector(item);
            }

            return sum / collection.Count;
        }
    }
}
