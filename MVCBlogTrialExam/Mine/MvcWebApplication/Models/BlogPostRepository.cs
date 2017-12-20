using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MvcWebApplication.Models
{
    public static class BlogPostRepository
    {
        public static List<BlogPost> blogPostList;

        static BlogPostRepository()
        {
            blogPostList = new List<BlogPost>();
            blogPostList.Add(new BlogPost() { Author = "John", Content = "Some Genius Thoghts", CreationDate = DateTime.Today.ToString("dd/MM/yyyy"), ID = 1, Title = "My Great Thoughts"});
            blogPostList.Add(new BlogPost() { Author = "Jonas", Content = "Some Humble. Thoghts", CreationDate = DateTime.Today.ToString("dd/MM/yyyy"), ID = 2, Title = "My Humble. Thoughts" });
            blogPostList.Add(new BlogPost() { Author = "Casper", Content = "Some Dubious Thoghts", CreationDate = DateTime.Today.ToString("dd/MM/yyyy"), ID = 3, Title = "My Dubious Thoughts" });
            blogPostList.Add(new BlogPost() { Author = "Mathias", Content = "Some Stupid Thoghts", CreationDate = DateTime.Today.ToString("dd/MM/yyyy"), ID = 4, Title = "My Stupid Thoughts" });
        }

        public static void AddPost(BlogPost newPost, string Author)
        {
            newPost.ID = blogPostList.Max(x => x.ID) + 1;
            newPost.Author = Author;
            newPost.CreationDate = DateTime.Today.ToString("dd/MM/yyyy");
            blogPostList.Add(newPost);
        }
    }
}
