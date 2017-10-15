namespace TelerikAcademy.TripyMate.Services.Model
{
    public class PostServiceModel
    {
        public PostServiceModel(string content, bool isDeleted)
        {
            this.Content = content;
            this.IsDeleted = isDeleted;
        }

        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
