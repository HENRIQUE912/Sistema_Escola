using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaEscola.Data;
using SistemaEscola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaEscola.Controllers
{   
    [Authorize]
    public class InstituicaoController : Controller
    {

        private readonly IESContext _context;

        public InstituicaoController(IESContext context)
        {
            this._context = context;
        }
        // GET: InstituicaoController
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.OrderBy(c => c.Nome).ToListAsync());

        }

        // GET: InstituicaoController/Details/5
        public async Task<IActionResult> Details(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Departamentos.SingleOrDefaultAsync(m => m.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
           
            return View(instituicao);
        }

        // GET: InstituicaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstituicaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync([Bind("Nome", "Endereco")] Instituicao instituicao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(instituicao);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }
            return View(instituicao);
        }

        // GET: InstituicaoController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(m => m.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }

        // POST: InstituicaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Nome,Turno ,InstituicaoID")] Instituicao instituicao)
        {
            if (id != instituicao.InstituicaoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)

                try
                {
                    _context.Update(instituicao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicaoExists(instituicao.InstituicaoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    
                    return RedirectToAction(nameof(Index));
                }
         
            return View(instituicao);
      
        }


        private bool InstituicaoExists(long? id)
        {
            return _context.Instituicoes.Any(e => e.InstituicaoID == id);
        }

        // GET: InstituicaoController/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instituicao = await _context.Instituicoes.SingleOrDefaultAsync(m => m.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: InstituicaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(long? id, IFormCollection collection)
        {
            if (id == null)
            {
                return NotFound();
            }
            var instituicao = _context.Instituicoes.SingleOrDefaultAsync(m => m.InstituicaoID == id);
            if (instituicao == null)
            {
                return NotFound();
            }
            return View(instituicao);
        }
    }
}
