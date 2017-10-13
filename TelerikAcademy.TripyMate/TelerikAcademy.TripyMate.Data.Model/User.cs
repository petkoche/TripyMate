using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using TelerikAcademy.TripyMate.Data.Model.Contracts;

namespace TelerikAcademy.TripyMate.Data.Model
{
    public class User : IdentityUser, IAuditable, IDeletable
    {
        private ICollection<Post> posts;

        public User()
        {
            this.PhotoId = "http://data.whicdn.com/images/179018121/large.jpg";
            this.posts = new HashSet<Post>();
            this.CreatedOn = DateTime.Now;
        }

        [Index]
        public bool IsDeleted { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public string PhotoId { get; set; }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }
            set
            {
                this.posts = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
