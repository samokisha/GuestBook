using AutoMapper;
using MessageContracts.Comments;
using StorageService.Data.Entities;

namespace StorageService.MapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentTypeModel, CommentType>();
            CreateMap<GuestModel, Guest>();
            CreateMap<NewCommentModel, Comment>();
            
            CreateMap<CommentType, CommentTypeModel>();
            CreateMap<Guest, GuestModel>();
            CreateMap<Comment, SavedCommentIdModel>();
        }
    }
}