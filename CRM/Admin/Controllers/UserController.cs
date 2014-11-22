namespace Crm.Admin.Controllers
{
    using System;
    using System.Web.Mvc;
    using Models;

    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            return View(new UserListModel());
        }

        [HttpPost]
        public ViewResult List(UserListModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.DeleteId.HasValue)
                    UserModel.Delete(model.DeleteId.Value);
            }
            return View(model);
        }

        [HttpPost]
        public PartialViewResult ListAjax(UserListModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.DeleteId.HasValue)
                    UserModel.Delete(model.DeleteId.Value);
            }
            return PartialView("UserList", model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.Save();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new UserModel(id));
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Save();
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex);
                }
            }
            return View(model);
        }
    }
}