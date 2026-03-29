using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.MessageDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly YummyFoodContext _context;
        public MessagesController(IMapper mapper, YummyFoodContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            var messagesDto = _mapper.Map<List<ResultMessageDto>>(values);
            return Ok(messagesDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Mesaj bulunamadı.");
            }
            var messageDto = _mapper.Map<GetByIdMessageDto>(value);
            return Ok(messageDto);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj başarılı bir şekilde eklendi.");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _context.Messages.FirstOrDefault(m => m.MessageId == updateMessageDto.MessageId);
            if (value == null)
            {
                return NotFound("Mesaj bulunamadı.");
            }
            
            var message =_mapper.Map(updateMessageDto,value);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Mesaj başarılı bir şekilde güncellendi.");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.FirstOrDefault(m => m.MessageId == id);
            if (value == null)
            {
                return NotFound("Mesaj bulunamadı.");
            }
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj başarılı bir şekilde silindi.");
        }

    }

}
