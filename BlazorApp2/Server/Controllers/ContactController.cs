using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactDbContext _context;
        public ContactController(ContactDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Contact> GetAllContacts()
        {
            try
            {
                return _context.Contacts.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("SearchContact/{name}")]
        public string SearchContact(string name)
        {
            var contact = _context.Contacts.SingleOrDefault(e => e.name == name);
            if (contact == null)
            {
                return "Contact does exist";
            }
            return "Name: " + contact.name + " - " + "Phone: " + contact.phone + " - " + "Telephone: " + contact.telephone;

        }
        [HttpGet("ExistinContact/{name}")]
        public bool ExistinContact(string name)
        {
            try{
            var contact = _context.Contacts.SingleOrDefault(e => e.name == name);
            if (contact == null)
            {
                return false;
            }
            } catch (Exception error)
        {
            Console.WriteLine("{0}", error.Message);
        }

            return true;
        }

        [HttpDelete("DeleteContact/{name}")]
        public bool DeleteContact(string name)
        {
            try
            {
                var contact = _context.Contacts.SingleOrDefault(e => e.name == name);
                if (contact == null)
                {
                    return false;
                }
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            catch (Exception error)
            {
                Console.WriteLine("{0}", error.Message);
            }
            return true;
        }


        // [HttpDelete]
        // public IActionResult Delete(Contact c)
        // {
        //     var emp = _context.Contacts.SingleOrDefault(x => x.name == c.name);
        //     if (emp == null)
        //     {
        //         return NotFound("Contact with the name Does no exist");
        //     }
        //     _context.Contacts.Remove(c);
        //     _context.SaveChanges();
        //     return Ok("Contact with the name deteled");
        // }

        [HttpPost]
        public void AddContact(Contact contact)
        {
            if (ExistinContact(contact.name) == true) return;
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}