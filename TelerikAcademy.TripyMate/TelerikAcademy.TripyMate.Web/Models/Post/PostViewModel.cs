namespace TelerikAcademy.TripyMate.Web.Models.Post
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
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

        [Required]
        [MaxLength(60)]
        public string PhotoId { get; set; }

        [Required]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(10)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        public string StartTown { get; set; }

        public string EndTown { get; set; }

        [Required]
        [MaxLength(60)]
        public string Content { get; set; }

        [Required]
        [MaxLength(60)]
        [EmailAddress]
        public string AuthorEmail { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PostedOn { get; set; }
    }
}