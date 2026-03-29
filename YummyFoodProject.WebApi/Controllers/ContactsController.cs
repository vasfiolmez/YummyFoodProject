using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.ContactDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly YummyFoodContext _context;

        public ContactsController(YummyFoodContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpGet("GetByIdContact")]
        public IActionResult GetByIdContact(GetByIdContactDto getByIdContact)
        {
            var value = _context.Contacts.Find(getByIdContact.ContactId);
            if (value == null)
            {
                return NotFound("İletişim bilgisi bulunamadı");
            }
            return Ok(value);

        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContact)
        {
            var contact = new Contact
            {
                MapLocation = createContact.MapLocation,
                Adress = createContact.Adress,
                Phone = createContact.Phone,
                Email = createContact.Email,
                OpenHours = createContact.OpenHours
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi ekleme işlemi başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound("İletişim bilgisi bulunamadı");
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi silme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContact)
        {
            var contact = _context.Contacts.Find(updateContact.ContactId);
            if (contact == null)
            {
                return NotFound("İletişim bilgisi bulunamadı");
            }
            contact.MapLocation = updateContact.MapLocation;
            contact.Adress = updateContact.Adress;
            contact.Phone = updateContact.Phone;
            contact.Email = updateContact.Email;
            contact.OpenHours = updateContact.OpenHours;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("İletişim bilgisi güncelleme işlemi başarılı");
        }
    }
}
