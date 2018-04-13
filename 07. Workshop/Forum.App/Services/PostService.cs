using Forum.App.UserInterface.ViewModels;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    public class PostService
    {
       public static Category GetCategory(int id)
        {
            var forumData = new ForumData();
            var category = forumData.Categories.Find(c => c.Id == id);
            return category;
        }

        public static IList<ReplyViewModel> GetPostReplies(int id)
        {
            var forumData = new ForumData();
            var post = forumData.Posts.Find(p => p.Id == id);

            var replies = new List<ReplyViewModel>();

            foreach (var replyId in post.ReplyIds)
            {
                var reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();

            Post post = forumData.Posts.Find(p => p.Id == postId);

            PostViewModel pvm = new PostViewModel(post);

            return pvm;
        }
        internal static string[] GetAllCategoryNames()
        {
            var forumData = new ForumData();
            return forumData.Categories.Select(c => c.Name).ToArray();
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            var forumData = new ForumData();
            var category = forumData.Categories.Find(c => c.Id == categoryId);
            return forumData.Posts.Where(p => category.PostIds.Contains(p.Id)).ToArray();
        }

        private static Category EnsureCategory(PostViewModel postView, ForumData forumData)
        {
            var categoryName = postView.Category;
            Category category = forumData.Categories.FirstOrDefault(x => x.Name == categoryName);

            if (category == null)
            {
                var categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.LastOrDefault().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }

            return category;
        }
        public static bool TrySavePost(PostViewModel postViewModel)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postViewModel.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(postViewModel.Title);
            bool emptyContent = !postViewModel.Content.Any();

            if (emptyCategory || emptyContent || emptyTitle)
            {
                return false;
            }

            var forumData = new ForumData();
            var category = EnsureCategory(postViewModel, forumData);
     
            var postId = forumData.Posts.Any() ? forumData.Posts.LastOrDefault().Id + 1 : 1;
            var author=  UserService.GetUser(postViewModel.Author, forumData);
            var content = string.Join("", postViewModel.Content);

            var post = new Post(postId, postViewModel.Title, content, category.Id, author.Id, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostIds.Add(post.Id);
            forumData.SaveChanges();

            postViewModel.PostId = postId;

            return true;
        }

        public static bool TrySaveReply(ReplyViewModel replyViewModel,int postId)
        {
            if (!replyViewModel.Content.Any())
            {
                return false;
            }
            var forumData = new ForumData();
            var author=  UserService.GetUser(replyViewModel.Author, forumData);
            var replyId = forumData.Replies.Any() ? forumData.Replies.LastOrDefault().Id + 1 : 1;
            var content = string.Join("", replyViewModel.Content);
            var post = forumData.Posts.Find(p => p.Id == postId);
            var reply = new Reply(replyId, content, author.Id, postId);

            forumData.Replies.Add(reply);
            post.ReplyIds.Add(replyId);
            forumData.SaveChanges();

            return true;
        }
    }
}
