﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Mvc;
//using ToDoList.Models;
//using Microsoft.Data.Entity;
//using Microsoft.AspNet.Mvc.Rendering;

//namespace ToDoList.Controllers
//{
//    public class ItemsController : Controller
//    {
//        private ToDoListContext db = new ToDoListContext();

//        public IActionResult Index()
//        {
//            return View(db.Items.Include(x => x.Category).ToList());
//        }

//        public IActionResult Details(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
//            return View(thisItem);
//        }

//        public IActionResult Create()
//        {
//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Create(Item item)
//        {

//            db.Items.Add(item);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Edit(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);

//            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");

//            return View(thisItem);
//        }

//        [HttpPost]
//        public IActionResult Edit(Item item)
//        {
//            db.Entry(item).State = EntityState.Modified;
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult Delete(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
//            return View(thisItem);
//        }

//        [HttpPost, ActionName("Delete")]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
//            db.Items.Remove(thisItem);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        [HttpPost]
//        public IActionResult Done(int id)
//        {
//            var thisItem = db.Items.FirstOrDefault(x => x.ItemId == id);
//            thisItem.Done = !thisItem.Done;
//            db.SaveChanges();
//            return RedirectToAction("Index");


//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToDoList.Models;
using Microsoft.Data.Entity;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {
        private IItemRepository itemRepo;

        public ItemsController(IItemRepository thisRepo = null)
        {
            if (thisRepo == null)
            {
                this.itemRepo = new EFItemRepository();
            }
            else
            {
                this.itemRepo = thisRepo;
            }
        }


        public ViewResult Index()
        {
            return View(itemRepo.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            itemRepo.Save(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            itemRepo.Edit(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Item thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);
            itemRepo.Remove(thisItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Done(int id)
        {
            var thisItem = itemRepo.Items.FirstOrDefault(x => x.ItemId == id);

            thisItem.Done = !thisItem.Done;

            //itemRepo.Save();

            return RedirectToAction("Index");
        }
    }
}