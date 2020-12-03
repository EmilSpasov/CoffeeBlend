namespace CoffeeBlend.Web.ViewModels.BlogViewModel
{
    using System;

    using CoffeeBlend.Data.Models;
    using CoffeeBlend.Services.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        // I HAVE CUSTOM MAPPING
        // public void CreateMappings(IProfileExpression configuration)
        // {
        //    configuration.CreateMap<Comment, CommentViewModel>()
        //        .ForMember(u => u.UserUserName, opt =>
        //            opt.MapFrom(x => x.User.Email));
        // }
    }
}
