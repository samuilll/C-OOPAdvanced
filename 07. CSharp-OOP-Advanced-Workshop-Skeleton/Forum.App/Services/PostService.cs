﻿using Forum.App.Contracts;
using Forum.App.ViewModels;
using Forum.Data;
using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.Services
{
    public class PostService : IPostService
    {


        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(postCategory);
            bool emptyTitle = string.IsNullOrWhiteSpace(postTitle);
            bool emptyContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyCategory||emptyContent||emptyTitle)
            {
                throw new ArgumentException("All fields must be filed");
            }

            Category category = this.EnsureCategory(postCategory);

            int postId = this.forumData.Posts.Any() ? this.forumData.Posts.Last().Id + 1 : 1;

            User author = this.userService.GetUserById(userId);

            Post post = new Post(postId,postTitle,postContent,category.Id,userId,new List<int>());

            forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            return post.Id;

        }

        private Category EnsureCategory(string postCategory)
        {
            Category category = this.forumData.Categories
                .FirstOrDefault(c => c.Name == postCategory);

            if (category==null)
            {
                int categoryId = this.forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;
                category = new Category(categoryId,postCategory,new List<int>());
                this.forumData.Categories.Add(category);
                forumData.SaveChanges();
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            Post post = this.forumData.Posts.Find(p => p.Id == postId);
            User author = this.userService.GetUserById(userId);

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            Reply reply = new Reply(replyId,replyContents,userId,postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);

            this.forumData.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories =
                this.forumData.Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories.First(c => c.Id == categoryId)?.Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            var category =  this.forumData.Categories.FirstOrDefault(c=>c.Id==categoryId);


            return this.forumData.Posts
                .Where(p => category.Posts.Contains(p.Id))
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);

            IPostViewModel postView = new PostViewModel(post.Title,
                this.userService.GetUserName(post.AuthorId),
                 this.GetPostReplies(postId), post.Content);

            return postView;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData.Replies
                .Where(r => r.PostId == postId).Select(r=> new ReplyViewModel(this.userService.GetUserName(r.AuthorId),r.Content));

           return replies;
        }
    }
}
