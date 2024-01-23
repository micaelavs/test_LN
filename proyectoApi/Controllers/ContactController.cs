using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace proyectoApi.Controllers
{
    using proyectoApi.Data;
    using proyectoApi.Interfaces;
    using proyectoApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    [RoutePrefix("contact")]
    public class ContactController : ApiController
    {
        ApiDbContext dbContext = new ApiDbContext();
       
        public ContactController()
        {
           
        }
        private readonly IRepository<Contact> _contactRepository;

        public ContactController(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }
       
        [HttpPost]
        [Route("create")]
        public IHttpActionResult Create([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {

                dbContext.Contacts.Add(contact);
                dbContext.SaveChanges();
                
                return Ok();
            }
            else
            {
                //errores de validación
                return BadRequest(ModelState);
            }
        }


        //Aqui uso injeccion de dependencias para las pruebas unitarias, este metodo es el que pruebo en el test unitrias
        [HttpGet]
        [Route("getById")]
        public IHttpActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
                var repo = new RepositoryContact();
                var contact = repo.GetById(id);
                
                //para probar la prueba unitaria descomentar esto!!! y comentar el repo de arriba!
                //utilizo de esta forma: para usar inyeccion de dependencias
                //var contact = _contactRepository.GetById(id);

                if (contact != null)
                {
                    return Ok(contact);
                }
                else
                {
                    return NotFound(); // Asegúrate de devolver NotFound cuando el contacto no se encuentra
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var repo = new RepositoryContact();
                var existingContact = repo.GetById(id);

                if (existingContact != null)
                {
                    repo.Delete(id);
                    return Ok();
                }
                else
                {
                    return NotFound(); 
                }
            }
            catch (Exception ex)
            {
                
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("getByCityId")]
        public IHttpActionResult GetByCityId(int cityId)
        {
            if (ModelState.IsValid)
            {   
                     //Obtener los contactos de la misma ciudad
                     var contactsInCity = dbContext.Contacts
                        .Where(c => c.IdCity == cityId)
                        .ToList();

                    return Ok(contactsInCity);
                
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        [Route("update")]
        public void Update(Contact entity)
        {
            

            var existingEntity = dbContext.Contacts.Find(entity.Id);

            //Verificar concurrencia optimista
            if (existingEntity != null && existingEntity.Id == entity.Id)
            {
                dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                dbContext.SaveChanges();
            }
            else
            {
                // Manejar la concurrencia a la db
                throw new DbUpdateConcurrencyException("Concurrencia optimista fallida. Los datos han cambiado desde que se cargaron.");
            }
        }

        [HttpGet]
        [Route("getByContactInfo")]
        public IHttpActionResult GetByContactInfo(string contactInfo)
        {
            if (ModelState.IsValid)
            {
                
                var contact = dbContext.Contacts.FirstOrDefault(c => c.Email == contactInfo || c.PhoneNumber.Personal == contactInfo || c.PhoneNumber.Work == contactInfo);

                if (contact != null)
                {
                    return Ok(contact);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                
                return BadRequest(ModelState);
            }
        }



    }
}
