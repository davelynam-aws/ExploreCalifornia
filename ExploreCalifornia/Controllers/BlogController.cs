﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post()
            {
                Title = "My blog post",
                Posted = DateTime.Now,
                Author = "Jess Chadwick",
                Body = "This is a great blog post, don't you think?",
            };

            return View(post);
        }

        
        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            return View();
        }



    }
}
 