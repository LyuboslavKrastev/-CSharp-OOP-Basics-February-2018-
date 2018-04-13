namespace Forum.App.UserInterface.ViewModels
{
    using Forum.App.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }

        public PostViewModel()
        {
            this.Content = new List<string>();
        }

        public PostViewModel(Post post)
        {
            this.Author = UserService.GetUser(post.AuthorId).Username;
            this.Content = GetLines(post.Content);
            this.Category = PostService.GetCategory(post.CategoryId).Name;
            this.Title = post.Title;
            this.PostId = post.Id;
            this.Replies = PostService.GetPostReplies(post.Id);
        }

        private IList<string> GetLines(string content)
        {
            var contentChars = content.ToCharArray();
            var contentLines = new List<string>();

            for (int i = 0; i < content.Length; i+= LINE_LENGHT)
            {
                var rowChars = contentChars.Skip(i).Take(i + LINE_LENGHT);
                var line = string.Join("", rowChars);
                contentLines.Add(line);
            }
            return contentLines;
        }
    }
}
