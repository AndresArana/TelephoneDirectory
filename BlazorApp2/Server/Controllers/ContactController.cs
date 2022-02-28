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
        public string GetContactById(string name)
        {
            var contact = _context.Contacts.SingleOrDefault(e => e.name == name);
            string message = "";
            if (contact == null)
            {
                message = " contact does exist";
                return message;
            }
            message = "Name: "+ contact.name + " - " + "Phone: "+ contact.phone + " - " + "Telephone: " + contact.telephone;
            return message;
        }

        [HttpDelete("DeleteContact/{name}")]
        public IActionResult Delete(string name)
        {
            var contact = _context.Contacts.SingleOrDefault(e => e.name == name);
            string message = "";
            if (contact == null)
            {
                message = " contact does exist";
            }
            message = "Contact with the name deteled";
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Created("api/contacts/" + contact.Id, contact);
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
        public IActionResult AddContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return Created("api/contacts/" + contact.Id, contact);
        }
    }
}