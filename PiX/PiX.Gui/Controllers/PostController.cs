using PiX.Domain.Entities;
using PiX.Gui.Models.Post;
using PiX.Services.Posts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiX.Gui.Controllers
{
    public class PostController : Controller
    {
        //Service
        PostService ps = null;
        public PostController()
        {
            ps = new PostService();

        }

        // GET: Post
        public ActionResult Index()
        {
            var posts = ps.GetMany();
            List<PostModels> postModelList = new List<PostModels>();
            foreach (var item in posts)
            {
                postModelList.Add(
                    new PostModels
                    {
                        Id=item.PostId,
                        Title=item.Title,
                        Description=item.Description,
                        Image=item.Image,
                        PostDateTime=item.PostDateTime
                    });
            }
            if (postModelList == null || !postModelList.Any())
            {
                ViewBag.empty = true;
                ViewBag.msg = "There are no photos yet, Go upload some !";
                postModelList = new List<PostModels>();
            }
            return View(postModelList.OrderByDescending(p=>p.PostDateTime));
        }

        // Post: Post
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var posts = ps.GetMany(p=>p.Title.Contains(searchString));
            List<PostModels> postModelList = new List<PostModels>();
            foreach (var item in posts)
            {
                postModelList.Add(
                    new PostModels
                    {
                        Id = item.PostId,
                        Title = item.Title,
                        Description = item.Description,
                        Image = item.Image,
                        PostDateTime = item.PostDateTime
                    });
            }

            if (postModelList == null || !postModelList.Any())
            {
                return RedirectToAction("Create");
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                return View(postModelList);
            }
            return View(postModelList);


        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            Post post = ps.GetById(id);
            PostModels p = new PostModels
            {
                 Id=post.PostId,
                 Title=post.Title,
                 Description=post.Description,
                 Image=post.Image,
                 Privacy=post.Privacy,
                PostDateTime = post.PostDateTime
            };

            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult Create(PostModels p, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid || Image == null || Image.ContentLength == 0)
            {
                RedirectToAction("Create");
            }
            p.Image = Image.FileName;
            try
            {
                Post post = new Post
                {
                    PostId = p.Id,
                    Title = p.Title,
                    Description = p.Description,
                    Privacy = p.Privacy,
                    Image = p.Image,
                    PostDateTime = DateTime.Now
                };
                ps.Add(post);
                ps.Commit();
                //ps.Dispose();
                var path = Path.Combine(Server.MapPath("~/Content/images/"), Image.FileName);
                Image.SaveAs(path);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            Post post = ps.GetById(id);
            PostModels p = new PostModels
            {
                Id = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Image = post.Image,
                Privacy = post.Privacy,
                PostDateTime = post.PostDateTime
            };

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PostModels p, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid || Image == null || Image.ContentLength == 0)
            {
                RedirectToAction("Edit");
            }
            //if (Image.FileName==null)
            //{
            //    Image.FileName = "default.png";
            //}
            p.Image = Image.FileName;

            Post post = ps.GetById(id);
            post.Title = p.Title;
            post.Description = p.Description;
            post.Privacy = p.Privacy;
            post.Image = p.Image;
            post.PostDateTime = DateTime.Now;
            ps.Update(post);
            ps.Commit();
            var path = Path.Combine(Server.MapPath("~/Content/images/"), Image.FileName);
            Image.SaveAs(path);
            return RedirectToAction("Index");

        }


        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            Post post = ps.GetById(id);
            PostModels p = new PostModels
            {
                Id = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Image = post.Image,
                Privacy = post.Privacy,
                PostDateTime = post.PostDateTime
            };

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = ps.GetById(id);
            ps.Delete(post);
            ps.Commit();
            return RedirectToAction("Index");
        }
    }
}
