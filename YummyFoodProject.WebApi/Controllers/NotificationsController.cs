using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyFoodProject.WebApi.Context;
using YummyFoodProject.WebApi.Dtos.NotificationsDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly YummyFoodContext _context;
        private readonly IMapper _mapper;
        public NotificationsController(YummyFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            var results = _mapper.Map<List<ResultNotificationDto>>(values);
            return Ok(results);
        }
        [HttpGet("{id}")]
        public IActionResult NotificationDetail(int id)
        {
            var value = _context.Notifications.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<GetNotificationByIdDto>(value);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddNotification(CreateNotificationDto createNotificationDto)
        {
            var value = _mapper.Map<Notification>(createNotificationDto);
            _context.Notifications.Add(value);
            _context.SaveChanges();
            return Ok("Bildirim eklendi");
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            var value = _context.Notifications.Find(updateNotificationDto.NotificationId);
            if (value == null)
            {
                return NotFound();
            }
            var notification = _mapper.Map(updateNotificationDto, value);
            _context.Notifications.Update(notification);
            _context.SaveChanges();
            return Ok("Bildirim güncellendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
            var result = _context.Notifications.Find(id);
            if (result == null)
            {
                return NotFound();
            }
            _context.Notifications.Remove(result);
            _context.SaveChanges();
            return Ok("Bildirim silindi");
        }

    }
}
