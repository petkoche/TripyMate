namespace TelerikAcademy.TripyMate.Web.Models.Post
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;
    using TelerikAcademy.TripyMate.Data.Model;

    public class PostViewModel
    {
        public static Expression<Func<Post, PostViewModel>> FromPost
        {
            get
            {
                return post => new PostViewModel
                {
                    ID = post.ID,
                    PhotoId = post.Author.PhotoId,
                    FirstName = post.Author.FirstName,
                    LastName = post.Author.LastName,
                    PhoneNumber = post.Author.PhoneNumber,
                    AuthorEmail = post.Author.Email,
                    PostedOn = post.CreatedOn.Value,
                    StartTown = post.StartTown.Name,
                    EndTown = post.EndTown.Name,
                    Title = post.Title,
                    Content = post.Content
                };
            }
        }

        public Guid ID { get; set; }

        public string PhotoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Title { get; set; }

        public string StartTown { get; set; }

        public string EndTown { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PostedOn { get; set; }
    }
}