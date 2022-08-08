using CRUD_ASP.NET_Core_6_SPA_Test.Data;
using CRUD_ASP.NET_Core_6_SPA_Test.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_ASP.NET_Core_6_SPA_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitiesController : Controller
    {
        private IRepository _repository;
        public EntitiesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("HasCategoryId/{id}")]
        [Produces("application/json")]
        public IEnumerable<EntityObject> Get(int id, int skip = 0, int take = 0)
        {
            var result = from entity in _repository.EntityObjects
                         where entity.InCategories.Contains(new Category { Id = id })
                         select entity;
            return take<=0 ? result : result.Skip(skip).Take(take);
        }
    }
}
