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

        [HttpGet("{id}")]
        public Contact GetContactById(int id)
        {
            return _context.Contacts.SingleOrDefault(e => e.Id == id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.Contacts.SingleOrDefault(x => x.Id == id);
            if (emp == null)
            {
                return NotFound("Contact with the Id " + id + "Does no exist");
            }
            _context.Contacts.Remove(emp);
            _context.SaveChanges();
            return Ok("Contact with the Id " + id + "deteled");
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Created("api/contacts/" + contact.Id, contact);
        }
    }
}