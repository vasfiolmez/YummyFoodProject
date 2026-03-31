using AutoMapper;
using YummyFoodProject.WebApi.Dtos.ChefDtos;
using YummyFoodProject.WebApi.Dtos.FeatureDtos;
using YummyFoodProject.WebApi.Dtos.FoodEventsDtos;
using YummyFoodProject.WebApi.Dtos.MessageDtos;
using YummyFoodProject.WebApi.Dtos.NotificationsDtos;
using YummyFoodProject.WebApi.Dtos.ProductDtos;
using YummyFoodProject.WebApi.Dtos.ServiceDtos;
using YummyFoodProject.WebApi.Dtos.TestimonialDtos;
using YummyFoodProject.WebApi.Entities;

namespace YummyFoodProject.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageByIsReadFalse>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x => x.CategoryName, y => y.MapFrom(z => z.Category.CategoryName)).ReverseMap();

            CreateMap<Service, ResultServiceDto>().ReverseMap();
            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

            CreateMap<FoodEvent, ResultFoodEventsDto>().ReverseMap();
            CreateMap<FoodEvent, UpdateFoodEventsDto>().ReverseMap();
            CreateMap<FoodEvent, GetFoodEventsById>().ReverseMap();
            CreateMap<FoodEvent, CreateFoodEventsDto>().ReverseMap();

            CreateMap<Chef, ResultChefDto>().ReverseMap();
            CreateMap<Chef, UpdateChefDto>().ReverseMap();
            CreateMap<Chef, GetChefByIdDto>().ReverseMap();
            CreateMap<Chef, CreateChefDto>().ReverseMap();

            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();
        }
    }
}
