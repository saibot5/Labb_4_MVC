﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb_4_MVC.Models;

namespace Labb_4_MVC.Controllers
{
    public class BorrowedBooksController : Controller
    {
        private readonly AppDbContext _context;

        public BorrowedBooksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BorrowedBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.BorrowedBook.ToListAsync());
        }

        // GET: BorrowedBooks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowedBook == null)
            {
                return NotFound();
            }

            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Create
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customer, "Id", "FullName");
            return View();
        }

        // POST: BorrowedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BorrowedDate,ReturnDate,IsReturned")] BorrowedBook borrowedBook)
        {
            if (ModelState.IsValid)
            {
                borrowedBook.Id = Guid.NewGuid();
                _context.Add(borrowedBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook.FindAsync(id);
            if (borrowedBook == null)
            {
                return NotFound();
            }
            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BorrowedDate,ReturnDate,IsReturned")] BorrowedBook borrowedBook)
        {
            if (id != borrowedBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowedBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowedBookExists(borrowedBook.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(borrowedBook);
        }

        // GET: BorrowedBooks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrowedBook = await _context.BorrowedBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (borrowedBook == null)
            {
                return NotFound();
            }

            return View(borrowedBook);
        }

        // POST: BorrowedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var borrowedBook = await _context.BorrowedBook.FindAsync(id);
            if (borrowedBook != null)
            {
                _context.BorrowedBook.Remove(borrowedBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowedBookExists(Guid id)
        {
            return _context.BorrowedBook.Any(e => e.Id == id);
        }
    }
}
