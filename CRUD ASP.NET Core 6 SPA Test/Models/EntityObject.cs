namespace CRUD_ASP.NET_Core_6_SPA_Test.Models
{
    public class EntityObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        
        public ICollection<Category> InCategories { get; set; }
    }
}
