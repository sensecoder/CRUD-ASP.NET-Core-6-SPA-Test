using CRUD_ASP.NET_Core_6_SPA_Test.Models;

namespace CRUD_ASP.NET_Core_6_SPA_Test.Data
{
    public class DbInitializer
    {
        public void Initialize(DataContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var categories = CreateRandomCategories();
            context.Categories.AddRange(categories);
            context.SaveChanges();

            int portion = 50001;
            int max = 1000001; // Количество объектов в БД - от 1-го миллиона.
            int total = 0;
            while (total < max)
            {
                var entities = CreateRandomEntities(context, portion);
                context.EntityObjects.AddRange(entities);
                context.SaveChanges();
                total += portion;
            }

        }

        private ICollection<EntityObject> CreateRandomEntities(DataContext context, int portion)
        {
            var categories = context.Categories.ToArray();
            Console.WriteLine($"Categories length = {categories.Length}");
            var rand = new Random();
            EntityObject[] entities = new EntityObject[portion];
            for (int i = 0; i < entities.Length; i++)
            {
                entities[i] = new EntityObject
                {
                    Title = "Title" + i,
                    Text = "text text text",
                    Date = DateTime.Now
                };
                // Как минимум 90% объектов должны входить в одну из категорий.
                var entityCategories = new Category[rand.Next((i < 0.9 * entities.Length) ? 1 : 0, 5)];
                var categoriesIndexes = new int[entityCategories.Length]; // to prevent categories doubles
                for (int j = 0; j < entityCategories.Length; j++)
                {
                    int categoryIndex;
                    do
                    {
                        categoryIndex = rand.Next(categories.Length);
                    }
                    while (categoriesIndexes.Contains<int>(categoryIndex));
                    var cat = categories[categoryIndex];
                    entityCategories[j] = cat;
                }
                entities[i].InCategories = entityCategories;
            }
            return entities;
        }
        private Category[] CreateRandomCategories()
        {
            var rand = new Random();
            int count = rand.Next(10, 101); // Количество категорий в БД - от 10 до 100.
            Category[] categories = new Category[count];
            for (int i = 0; i < count; i++)
            {
                categories[i] = new Category { Name = "CatName" + i};
            }
            return categories;
        }
    }
}
