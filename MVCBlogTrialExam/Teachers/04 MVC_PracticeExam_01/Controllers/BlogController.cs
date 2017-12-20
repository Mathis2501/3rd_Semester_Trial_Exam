using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _04_MVC_PracticeExam_01.Models;

namespace _04_MVC_PracticeExam_01.Controllers
{
    
    public class BlogController : Controller
    {
        const string SessionKeyName = "_AuthorName";
        // GET: Blog
        [HttpGet]
        public ActionResult Index()
        {
            return View(BlogPostRepository.GetAllPosts());
        }

        // POST: Blog/Index
        [HttpPost]
        public ActionResult Index(string author)
        {
            HttpContext.Session.SetString(SessionKeyName, author);
            return View(BlogPostRepository.GetByAuthor(author));
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.AuthorName = HttpContext.Session.GetString(SessionKeyName);
            if (HttpContext.Session.GetString(SessionKeyName) == null)
                Response.Redirect("/blog");
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public IActionResult Create(BlogPost post)
        {
            var author = HttpContext.Session.GetString(SessionKeyName);
            if (!ModelState.IsValid)
                return View();


            post.Id = BlogPostRepository.GetLastId() +1;
            post.Author = author;
            post.CreateDate = DateTime.Now;
            BlogPostRepository.AddBlogPost(post);

            return View();
        }

    }
}