namespace TelerikAcademy.TripyMate.Web.Areas.Admin.Models
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using TelerikAcademy.TripyMate.Data.Model;
    using TelerikAcademy.TripyMate.Web.Infreastructure;

    public class GridPostViewModel : IMapFrom<Post>
    {
        public Guid ID { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string Title { get; set; }

        public string StartTown { get; set; }

        public string EndTown { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Post, GridPostViewModel>()
                 .ForMember(c => c.Author, cfg => cfg.MapFrom(x => x.Author.FirstName));

            configuration.CreateMap<Post, GridPostViewModel>()
                  .ForMember(c => c.StartTown, cfg => cfg.MapFrom(x => x.StartTown.Name));

            configuration.CreateMap<Post, GridPostViewModel>()
                    .ForMember(c => c.EndTown, cfg => cfg.MapFrom(x => x.EndTown.Name));
        }
    }
}