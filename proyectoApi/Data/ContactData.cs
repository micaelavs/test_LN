using proyectoApi.Interfaces;
using proyectoApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace proyectoApi.Data
{
    public class RepositoryContact : IRepository<Contact>
    {
        public void Delete(int id)
        {
            var db = new ApiDbContext();
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();

        }

        public Contact GetById(int id)
        {
            var db = new ApiDbContext();
            return db.Contacts.Find(id);

        }

        public void Insert(Contact entity)
        {
            var db = new ApiDbContext();
            db.Contacts.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Contact> List()
        {

            var db = new ApiDbContext();
            var clients = db.Contacts.ToList();
            return clients;
        }

        public void Update(Contact entity)
        {
            var db = new ApiDbContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}