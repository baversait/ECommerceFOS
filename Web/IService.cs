using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web
{
    public interface IService<T> where T : class
    {
        ActionResult Index();
        [HttpPost]
        ActionResult Add(T entity);
        [HttpPost]
        ActionResult Delete(T entity);
        [HttpPost]
        ActionResult Edit(T entity);
        ActionResult GetByID(int id);
    }
}
