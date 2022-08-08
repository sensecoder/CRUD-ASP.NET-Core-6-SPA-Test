using System.Diagnostics.CodeAnalysis;

namespace CRUD_ASP.NET_Core_6_SPA_Test.Models
{
    public class Category : IEqualityComparer<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EntityObject> HasEntityObjects { get; set; }

        public bool Equals(Category x, Category y) => x.Id == y.Id;

        public int GetHashCode([DisallowNull] Category obj) => this.GetHashCode(obj);
       
    }
}
