using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkManage.Models;

namespace WorkManage.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var dt = Data.GetWorks();
            return View(dt);
        }

        public ActionResult CreateWork(Works work)
        {
            var result = Data.InsertWork(work);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return Json("添加失败");
        }

        public ActionResult UpdateWork(Works work)
        {
            var result = Data.Update(work);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return Json("更新失败");
        }

        public ActionResult FinishWork(int workId)
        {
            var result = Data.FinishWork(workId);
            if (result)
            {
                return Json(1);
            }
            return Json(0);
        }

        public ActionResult DeleteWork(int workId)
        {
            var result = Data.DeleteWork(workId);
            if (result)
            {
                return Json(1);
            }
            return Json(0);
        }

    }
}
