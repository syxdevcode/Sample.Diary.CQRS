using Sample.Diary.CQRS.Commands;
using Sample.Diary.CQRS.Configuration;
using Sample.Diary.CQRS.Reporting;
using System;
using System.Web.Mvc;

namespace Sample.Diary.CQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Model = ServiceLocator.ReportDatabase.GetItems();
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var item = ServiceLocator.ReportDatabase.GetById(id);
            var model = new DiaryItemDto()
            {
                Description = item.Description,
                From = item.From,
                Id = item.Id,
                Title = item.Title,
                To = item.To,
                Version = item.Version
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(DiaryItemDto item)
        {
            ServiceLocator.CommandBus.Send(new ChangeItemCommand(item.Id, item.Title, item.Description, item.From, item.To, item.Version));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var item = ServiceLocator.ReportDatabase.GetById(id);

            ServiceLocator.CommandBus.Send(new DeleteItemCommand(item.Id, item.Version));

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DiaryItemDto item)
        {
            ServiceLocator.CommandBus.Send(new CreateItemCommand(Guid.NewGuid(), item.Title, item.Description, item.Version, item.From, item.To));

            return RedirectToAction("Index");
        }
    }
}