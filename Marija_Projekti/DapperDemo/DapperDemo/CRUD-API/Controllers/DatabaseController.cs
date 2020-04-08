using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabaseRepository databaseRepository;

        public DatabaseController()
        {
            databaseRepository = new DatabaseRepository();

        }

        [HttpGet]
        public IEnumerable<Menu> Get()
        {
            return databaseRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Menu GetById(int id)
        {
            return databaseRepository.GetById(id);
        }
        [HttpPost]
        public void Post([FromBody]Menu menu)
        {
            if (ModelState.IsValid)
            {
                databaseRepository.Add(menu);
            }
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Menu menu)
        {
            menu.IDMenu = id;
            if (ModelState.IsValid)
            {
                databaseRepository.Update(menu);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            databaseRepository.Delete(id);
        }
    }
}