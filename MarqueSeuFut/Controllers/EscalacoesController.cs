using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarqueSeuFut.Models;

namespace MarqueSeuFut.Controllers
{
    public class EscalacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EscalacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Escalacoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Escalacoes.Include(e => e.Jogador).Include(e => e.Time);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Escalacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalacao = await _context.Escalacoes
                .Include(e => e.Jogador)
                .Include(e => e.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escalacao == null)
            {
                return NotFound();
            }

            return View(escalacao);
        }

        // GET: Escalacoes/Create
        public IActionResult Create()
        {
            ViewData["JogadorId"] = new SelectList(_context.Jogadores, "Id", "Nome");
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Localizacao");
            return View();
        }

        // POST: Escalacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeId,JogadorId")] Escalacao escalacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escalacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogadores, "Id", "Nome", escalacao.JogadorId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Localizacao", escalacao.TimeId);
            return View(escalacao);
        }

        // GET: Escalacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalacao = await _context.Escalacoes.FindAsync(id);
            if (escalacao == null)
            {
                return NotFound();
            }
            ViewData["JogadorId"] = new SelectList(_context.Jogadores, "Id", "Nome", escalacao.JogadorId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Localizacao", escalacao.TimeId);
            return View(escalacao);
        }

        // POST: Escalacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeId,JogadorId")] Escalacao escalacao)
        {
            if (id != escalacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escalacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscalacaoExists(escalacao.Id))
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
            ViewData["JogadorId"] = new SelectList(_context.Jogadores, "Id", "Nome", escalacao.JogadorId);
            ViewData["TimeId"] = new SelectList(_context.Times, "Id", "Localizacao", escalacao.TimeId);
            return View(escalacao);
        }

        // GET: Escalacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escalacao = await _context.Escalacoes
                .Include(e => e.Jogador)
                .Include(e => e.Time)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (escalacao == null)
            {
                return NotFound();
            }

            return View(escalacao);
        }

        // POST: Escalacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escalacao = await _context.Escalacoes.FindAsync(id);
            _context.Escalacoes.Remove(escalacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscalacaoExists(int id)
        {
            return _context.Escalacoes.Any(e => e.Id == id);
        }
    }
}
