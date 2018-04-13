namespace Forum.App.UserInterface.ViewModels
{
    using Forum.App.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;


        public ReplyViewModel()
        {
            this.Content = new List<string>();
        }

        public ReplyViewModel(Reply reply)
        {
            this.Author = UserService.GetUser(reply.AuthorId).Username;
            this.Content = GetLines(reply.Content);
        }


        public string Author { get; set; }

        public IList<string> Content { get; set; }
        private IList<string> GetLines(string content)
        {
            var contentChars = content.ToCharArray();
            var contentLines = new List<string>();

            for (int i = 0; i < content.Length; i += LINE_LENGHT)
            {
                var rowChars = contentChars.Skip(i).Take(i + LINE_LENGHT);
                var line = string.Join("", rowChars);
                contentLines.Add(line);
            }
            return contentLines;
        }
    }
}