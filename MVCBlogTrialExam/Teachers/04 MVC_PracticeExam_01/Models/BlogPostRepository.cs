using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _04_MVC_PracticeExam_01.Models
{
    public sealed class BlogPostRepository
    {
        private static volatile BlogPostRepository instance = null;
        private static readonly object padlock = new object();

        List<BlogPost> items;

        public static BlogPostRepository Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BlogPostRepository();
                    }
                    return instance;
                }
            }
        }
        BlogPostRepository()
        {
            items = new List<BlogPost>
            {
                new BlogPost
                {
                    Id=1,
                    Title = "My blog post",
                    CreateDate = DateTime.Now,
                    Author = "Jess Chadwick",
                    Content = "This is a great blog post, don't you think?",
                },
                new BlogPost
                {
                    Id=2,
                    Title = "My second blog post",
                    CreateDate = DateTime.Now,
                    Author = "Jess Chadwick",
                    Content = "This is ANOTHER great blog post, don't you think?",
                },
                 new BlogPost
                 {
                     Id=3,
                     Title = "My First blog post by new author",
                     CreateDate = DateTime.Now,
                     Author = "Simon Stochholm",
                     Content = "This is THE GREATEST blog post",
                 },
            };

        }



        public static List<BlogPost> GetAllPosts()
        {
            lock (padlock)
            {
                return Instance.items.ToList(); //returns a copy of the list, but the elements references the old objects
                                                //this is fine as long as you update the list by adding new objects
                                                //to the list, but otherwise changes will be refelcted even in the copy
            }
        }
        public static IEnumerable<BlogPost> GetByAuthor(string author)
        {
            lock (padlock)
            {
                return GetAllPosts().Where(x => x.Author == author);
            }
        }
        public static void AddBlogPost(BlogPost post)
        {
            lock (padlock)
            {
                Instance.items.Add(post);
            }
        }
        public static int GetLastId()
        {
            lock (padlock)
            {
                return GetAllPosts().Last().Id;
            }
        }

    }
}

