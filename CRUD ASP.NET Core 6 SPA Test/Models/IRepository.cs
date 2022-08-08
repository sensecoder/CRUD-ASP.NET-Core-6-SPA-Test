namespace CRUD_ASP.NET_Core_6_SPA_Test.Models
{
    public interface IRepository
    {
        IQueryable<EntityObject> EntityObjects { get; }
        IQueryable<Category> Categories { get; }
    }
}
