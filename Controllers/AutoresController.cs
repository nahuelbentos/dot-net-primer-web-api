using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApi_M3.Contexts;
using MiPrimerWebApi_M3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MiPrimerWebApi_M3.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autores.Include(autor => autor.Libros).ToList();
        }


        [HttpGet("{id}", Name = "obtenerAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autores.Include(autor => autor.Libros).FirstOrDefault(a => a.Id == id);
            if( autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {

            context.Autores.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("obtenerAutor", new { id = autor.Id }, autor);
        }



        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor autor)
        {
            // Esto no es necesario en asp.net core 2.1
            // if (ModelState.IsValid){

            // }

            if (id != autor.Id)
            {
                return BadRequest();
            }

            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();
            return new OkObjectResult(autor); //Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            context.Autores.Remove(autor);
            context.SaveChanges();
            return autor;
        }
    }
}
