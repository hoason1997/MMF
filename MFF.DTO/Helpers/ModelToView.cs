using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFF.DTO.Helpers
{
    public static class ModelToView
    {
        public static void To<TDest, TSource>(TDest destination, TSource source)
       where TSource : class
       where TDest : class
        {
            var destProperties = destination.GetType().GetProperties()
                .Where(x => x.CanRead && x.CanWrite && !x.GetGetMethod().IsVirtual);
            var sourceProperties = source.GetType().GetProperties()
                .Where(x => x.CanRead && x.CanWrite && !x.GetGetMethod().IsVirtual);
            var copyProperties = sourceProperties.Join(destProperties, x => x.Name, y => y.Name, (x, y) => x);
            foreach (var sourceProperty in copyProperties)
            {
                var prop = destProperties.FirstOrDefault(x => x.Name == sourceProperty.Name);
                prop.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }
    //public static async Task<IEnumerable<TEntity>> ModelToViewModelCollectionAsync(this Task<IEnumerable<Person>> persons)
    //{
    //    return await Mapper.Map<Task<IEnumerable<Person>>, Task<IEnumerable<PersonView>>>(persons);
    //}
}
