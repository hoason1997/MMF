using System;
using System.Collections.Generic;
using System.Linq;

namespace  MFF.Infrastructure.Paging
{
    public class Pagination<T> : IPagination<T>
    {
        public Pagination()
        {
            Items = new T[0];
        }

        public Pagination(IEnumerable<T> source, int index, int size, int from)
        {
            var enumerable = source as T[] ?? source.ToArray();

            if (from > index)
                throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

            if (source is IQueryable<T> querable)
            {
                Index = index;
                Size = size;
                From = from;
                Count = querable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Index.HasValue && Size.HasValue)
                    querable = querable.Skip((Index.Value - From) * Size.Value).Take(Size.Value);

                Items = querable.ToList();
            }
            else
            {
                Index = index;
                Size = size;
                From = from;

                Count = enumerable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Index.HasValue && Size.HasValue)
                    Items = enumerable.Skip((Index.Value - From) * Size.Value).Take(Size.Value).ToList();
                else
                    Items = enumerable.ToList();
            }
        }

        public int From { get; set; }
        public int? Index { get; set; }
        public int? Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public IList<T> Items { get; set; }
        public bool HasPrevious => Index - From > 0;
        public bool HasNext => Index - From + 1 < Pages;
    }

    internal class Pagination<TSource, TResult> : IPagination<TResult>
    {
        public Pagination(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
            int index, int size, int from)
        {
            var enumerable = source as TSource[] ?? source.ToArray();

            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

            if (source is IQueryable<TSource> queryable)
            {
                Index = index;
                Size = size;
                From = from;
                Count = queryable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Index.HasValue && Size.HasValue)
                    queryable = queryable.Skip((Index.Value - From) * Size.Value).Take(Size.Value);

                var items = queryable.ToArray();

                Items = new List<TResult>(converter(items));
            }
            else
            {
                Index = index;
                Size = size;
                From = from;
                Count = enumerable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Index.HasValue && Size.HasValue)
                {
                    var items = enumerable.Skip((Index.Value - From) * Size.Value).Take(Size.Value).ToArray();
                    Items = new List<TResult>(converter(items));
                }
                else
                {
                    var items = enumerable.ToArray();
                    Items = new List<TResult>(converter(items));
                }
            }
        }

        public Pagination(IPagination<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            Index = source.Index;
            Size = source.Size;
            From = source.From;
            Count = source.Count;
            Pages = source.Pages;

            Items = new List<TResult>(converter(source.Items));
        }

        public int? Index { get; }
        public int? Size { get; }
        public int Count { get; }
        public int Pages { get; }
        public int From { get; }
        public IList<TResult> Items { get; }
        public bool HasPrevious => Index - From > 0;
        public bool HasNext => Index - From + 1 < Pages;
    }

    public static class Pagination
    {
        public static IPagination<T> Empty<T>()
        {
            return new Pagination<T>();
        }

        public static IPagination<TResult> From<TResult, TSource>(IPagination<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            return new Pagination<TSource, TResult>(source, converter);
        }
    }
}
