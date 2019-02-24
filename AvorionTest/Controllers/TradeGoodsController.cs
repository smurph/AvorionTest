using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoFixture;
using AvorionTest.Models;
using AvorionTest.Models.Database;

namespace AvorionTest.Controllers
{
    public class TradeGoodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TradeGoods
        public ActionResult Index()
        {
            return View(db.TradeGoods.ToList());
        }

        // GET: TradeGoods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var fixture = new Fixture();
            TradeGood tradeGood = db.TradeGoods.Find(id);
            if (tradeGood == null)
            {
                return HttpNotFound();
            }

            var tradeRecords = db.Database.SqlQuery<TradeRecord>($"SELECT * FROM RecentTradeRecords WHERE TradeGood_Id = {id}");
            
            var stationIds = tradeRecords.Select(r => r.Station_Id);
            var tradeGoodIds = tradeRecords.Select(r => r.TradeGood_Id);

            ViewBag.Buyable = tradeRecords.Where(r => r.IsBuyable == true).ToList();
            ViewBag.Sellable = tradeRecords.Where(r => r.IsBuyable == false).ToList();
            ViewBag.Stations = db.Stations.Where(s => stationIds.Contains(s.Id)).ToList();
            ViewBag.TradeGoods = db.TradeGoods.Where(tg => tradeGoodIds.Contains(tg.Id)).ToList();

            return View(tradeGood);
        }

        // GET: TradeGoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradeGoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Volume,IsIllegal,IsDangerous")] TradeGood tradeGood)
        {
            if (ModelState.IsValid)
            {
                db.TradeGoods.Add(tradeGood);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tradeGood);
        }

        // GET: TradeGoods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeGood tradeGood = db.TradeGoods.Find(id);
            if (tradeGood == null)
            {
                return HttpNotFound();
            }
            return View(tradeGood);
        }

        // POST: TradeGoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Volume,IsIllegal,IsDangerous")] TradeGood tradeGood)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tradeGood).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tradeGood);
        }

        // GET: TradeGoods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TradeGood tradeGood = db.TradeGoods.Find(id);
            if (tradeGood == null)
            {
                return HttpNotFound();
            }
            return View(tradeGood);
        }

        // POST: TradeGoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TradeGood tradeGood = db.TradeGoods.Find(id);
            db.TradeGoods.Remove(tradeGood);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
