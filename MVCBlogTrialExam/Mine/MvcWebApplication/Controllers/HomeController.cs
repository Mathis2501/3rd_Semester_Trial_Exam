using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWebApplication.Models;

namespace MvcWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Blogs");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Blogs(string searchString)
        {
            var foundBlogPosts = BlogPostRepository.blogPostList.Where(x => x.Author.Contains(searchString));
            if (!string.IsNullOrEmpty(searchString))
            {
                HttpContext.Session.SetString("Author", searchString);
                return View(foundBlogPosts.ToList());
            }
            
            return View(BlogPostRepository.blogPostList);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Author") == null)
            {
                return RedirectToAction("Blogs");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(BlogPost newPost)
        {
            
            BlogPostRepository.AddPost(newPost, HttpContext.Session.GetString("Author"));
            return RedirectToAction("Blogs");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
