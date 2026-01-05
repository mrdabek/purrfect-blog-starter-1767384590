using PurrfectBlog.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PurrfectBlog.Controllers
{
    public class PostsController : Controller
    {
        private readonly BlogDbContext _db = new BlogDbContext();

        // GET: /Posts
        public ActionResult Index()
        {
            var posts = _db.BlogPosts
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(posts);
        }

        // GET: /Posts/Details/5
        public ActionResult Details(int id)
        {
            var post = _db.BlogPosts.Find(id);
            if (post == null) return HttpNotFound();
            return View(post);
        }

        // GET: /CreatePost  (explicit route)
        [Route("CreatePost")]
        public ActionResult CreatePost()
        {
            return View();
        }

        // POST: /CreatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CreatePost")]
        public ActionResult CreatePost(BlogPost model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CreatedAt = DateTime.UtcNow;
            _db.BlogPosts.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Details", new { id = model.Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}
