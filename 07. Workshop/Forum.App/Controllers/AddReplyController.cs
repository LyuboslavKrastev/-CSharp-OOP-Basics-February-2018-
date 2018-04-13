namespace Forum.App.Controllers
{
    using System;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Services;
    using System.Linq;
    using Forum.App.Views;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;
        private const int TOP_OFFSET = 7;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;


        public AddReplyController()
        {
            ResetReply();
        }

        public ReplyViewModel Reply { get; private set; }
        private PostViewModel postViewModel;

        public void SetPostId(int postId)
        {
            this.postViewModel = PostService.GetPostViewModel(postId);
            ResetReply();
        }


        private TextArea TextArea { get; set; }

        public bool Error { get; private set; }


        private enum Command {Write, Post, Back}

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    TextArea.Write();
                    Reply.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddReply;
                case Command.Post:
                    var replyAdded = PostService.TrySaveReply(this.Reply, postViewModel.PostId);
                    if (!replyAdded)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
                case Command.Back:
                    return MenuState.Back;
            }
            throw new InvalidOperationException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
          
            return new AddReplyView(postViewModel, Reply, TextArea, Error);
        }


        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();
            var contentLength = postViewModel?.Content.Count ?? 0;
            this.TextArea = new TextArea(centerLeft - 18, centerTop
                + contentLength - 5,
                TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

    }
}
