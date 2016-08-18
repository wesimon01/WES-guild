using BlogEngine.BLL;
using BlogEngine.Models;
using BlogEngine.UI.Models;
using BlogEngine.UI.Viewmodels;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace BlogEngine.UI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogEngineService _blogEngineSvc;

        public HomeController(IBlogEngineService blogEnginerSvc)
        {
            _blogEngineSvc = blogEnginerSvc;
        }

        public ActionResult StaticPage(int id)
        {
            var model = _blogEngineSvc.GetPage(id);
            return View(model);
        }

        public ActionResult SidePanel(List<Hashtag> hashtags)
        {
            hashtags = _blogEngineSvc.GetAllHashTags();
            
            return PartialView("_SidePanel", hashtags);
        }

        public ActionResult StaticPageList(List<Page> pages)
        {
            pages = _blogEngineSvc.GetAllPages();
            return PartialView("_StaticPageNav", pages);
        }
        
        [Authorize]
        public ActionResult DeletePage(int id)
        {
            _blogEngineSvc.RemovePage(id);
            return RedirectToAction("PageAdmin");
        }

        [Authorize]
        public ActionResult EditPage(int id)
        {
            var model = _blogEngineSvc.GetPage(id);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPage(Page page)
        {
            if (ModelState.IsValid)
            {
                _blogEngineSvc.UpdatePage(page);
                return RedirectToAction("PageAdmin");
            }
            else
            {
                return View(page);
            }
        }

        [Authorize]
        public ActionResult CreatePage()
        {
            var model = new Page();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePage(Page page)
        {
            if (ModelState.IsValid)
            {
                _blogEngineSvc.AddPage(page);
                return RedirectToAction("PageAdmin");
            }
            else
            {
                return View(page);
            }
        }

        [Authorize]
        public ActionResult DeletePost(int id)
        {
            _blogEngineSvc.RemoveBlogPost(id);
            return RedirectToAction("PostAdmin");
        }

        [Authorize]
        public ActionResult PageAdmin()
        {
            var pages = _blogEngineSvc.GetAllPages();
            return View(pages);
        }

        [Authorize]
        public ActionResult PostAdmin()
        {
            var posts = _blogEngineSvc.GetAllBlogPosts();
            return View(posts);
        }

        [Authorize]
        public ActionResult EditPost(int id)
        {
            ApplicationUser currentUser = GetCurrentUserInfo();
            var viewModel = new CreatePostVM();
            viewModel.Post = _blogEngineSvc.GetBlogPost(id);
            viewModel.Post.Author.AuthorName = currentUser.FirstName;
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPost(CreatePostVM viewModel)
        {
            if (ModelState.IsValid)
            {
                string[] tags;
                if(!string.IsNullOrEmpty(viewModel.Tags))
                { 
                    tags = viewModel.Tags.Split(',');
                    foreach (var tag in tags)
                    {
                        viewModel.Post.Hashtags.Add(new Hashtag { HashtagName = tag.Trim() });
                    }
                }
                _blogEngineSvc.UpdateBlogPost(viewModel.Post);
                return RedirectToAction("PostAdmin");
            }
            else
            {
                return View(viewModel);
            }
        }

        [Authorize]
        public ActionResult CreatePost()
        {
            var currentUser = GetCurrentUserInfo();
            var viewModel = new CreatePostVM();
            viewModel.Post.Author.AuthorName = currentUser.FirstName;
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePost(CreatePostVM viewModel)
        {
            if (ModelState.IsValid)
            {
                string[] tags;
                if (!string.IsNullOrEmpty(viewModel.Tags))
                {
                    tags = viewModel.Tags.Split(',');
                    foreach (var tag in tags)
                    {
                        viewModel.Post.Hashtags.Add(new Hashtag { HashtagName = tag.Trim() });
                    }
                }
                _blogEngineSvc.AddBlogPost(viewModel.Post);
                return RedirectToAction("PostAdmin");
            }
            else
            {
                return View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult IndividualPost(int? id)
        {
            if (id != null && id.Value != 0)
            {
                return View(_blogEngineSvc.GetBlogPost(id.Value));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileWrapper file)
        {        
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Content/"), pic);
                // file is uploaded

                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                //using (MemoryStream ms = new MemoryStream())
                //{
                //    file.InputStream.CopyTo(ms);
                //    byte[] array = ms.GetBuffer();
                    
                //}
                
            }
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Index(string hashtagName)
        {
            if (string.IsNullOrEmpty(hashtagName))
            {
                var viewmodel = new IndexVM();
                viewmodel._hashtags = _blogEngineSvc.GetAllHashTags();
                viewmodel._hashtags = viewmodel._hashtags.OrderBy(t => t.HashtagId).ToList();
                viewmodel._blogposts = _blogEngineSvc.GetAllBlogPosts()
                    .Where(p => p.IsApproved)
                    .Where(p => p.dateExpires == null || p.dateExpires > DateTime.Today && p.datePublished.Date <= DateTime.Today)
                    .ToList();
                viewmodel._blogposts = viewmodel._blogposts.OrderByDescending(p => p.datePublished).ToList();
                return View(viewmodel);
            }
            else
            {
                var viewmodel = new IndexVM();
                viewmodel._hashtags = _blogEngineSvc.GetAllHashTags();
                viewmodel._hashtags = viewmodel._hashtags.OrderBy(t => t.HashtagId).ToList();
                viewmodel._blogposts = _blogEngineSvc.GetPostsbyHashTagName(hashtagName)
                    .Where(p => p.IsApproved)
                    .Where(p => p.dateExpires == null || p.dateExpires > DateTime.Today && p.datePublished.Date <= DateTime.Today)
                    .ToList(); 
                viewmodel._blogposts = viewmodel._blogposts.OrderByDescending(p => p.datePublished).ToList();
                return View(viewmodel);
            }
        }

        public ActionResult About()
        {
            List<Blogpost> posts = _blogEngineSvc.GetAllBlogPosts();

            return View(posts);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.IsAdmin = User.IsInRole("Admin");

            return View();
        }

        public ApplicationUser GetCurrentUserInfo()
        {
            string currentUserId = User.Identity.GetUserId();  // method to get current user properties
            ApplicationUser currentUser = new ApplicationUser();//
            ApplicationDbContext context = new ApplicationDbContext();//
            List<ApplicationUser> allUsers = context.Users.ToList();//
            currentUser = allUsers.FirstOrDefault(u => u.Id == currentUserId);//

            return currentUser;
        }


    }
}