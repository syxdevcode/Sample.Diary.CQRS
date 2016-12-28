using Sample.Diary.CQRS.Commands;
using Sample.Diary.CQRS.Reporting;
using Sample.Diary.CQRS.Utils;
using System;
using System.Web.Mvc;

namespace Sample.Diary.CQRS.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Model = StructureMapIOC.ReportDatabase.GetItems();
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var item = StructureMapIOC.ReportDatabase.GetById(id);
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
            StructureMapIOC.CommandBus.Send(new ChangeItemCommand(item.Id, item.Title, item.Description, item.From, item.To, item.Version));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var item = StructureMapIOC.ReportDatabase.GetById(id);

            StructureMapIOC.CommandBus.Send(new DeleteItemCommand(item.Id, item.Version));

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DiaryItemDto item)
        {
            StructureMapIOC.CommandBus.Send(new CreateItemCommand(Guid.NewGuid(), item.Title, item.Description, item.Version, item.From, item.To));

            return RedirectToAction("Index");
        }
    }
}