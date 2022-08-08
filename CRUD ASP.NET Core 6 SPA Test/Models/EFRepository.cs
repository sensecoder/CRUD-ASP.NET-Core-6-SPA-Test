namespace CRUD_ASP.NET_Core_6_SPA_Test.Models
{
    public class EFRepository : IRepository
    {
        private Data.DataContext _context;
        public EFRepository(Data.DataContext context) 
        { 
            _context = context; 
        }
        public IQueryable<EntityObject> EntityObjects => _context.EntityObjects;

        public IQueryable<Category> Categories => _context.Categories;
    }
}
