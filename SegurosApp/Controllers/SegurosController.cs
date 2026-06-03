
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosApp.Models;
using SegurosApp.Data;

public class SegurosController : Controller
{
    private readonly ApplicationDbContext _context;

    public SegurosController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SEGUROS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Seguros.ToListAsync());
    }

    // GET: SEGUROS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seguro = await _context.Seguros
            .FirstOrDefaultAsync(m => m.Id == id);
        if (seguro == null)
        {
            return NotFound();
        }

        return View(seguro);
    }

    // GET: SEGUROS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SEGUROS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,NumeroApolice,Tipo,Status,PremioMensal,ValorSegurado,DataInicio,DataVencimento,Observacoes,SeguradoraId,Seguradora,ClienteId,Cliente")] Seguro seguro)
    {
        if (ModelState.IsValid)
        {
            _context.Add(seguro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(seguro);
    }

    // GET: SEGUROS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seguro = await _context.Seguros.FindAsync(id);
        if (seguro == null)
        {
            return NotFound();
        }
        return View(seguro);
    }

    // POST: SEGUROS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,NumeroApolice,Tipo,Status,PremioMensal,ValorSegurado,DataInicio,DataVencimento,Observacoes,SeguradoraId,Seguradora,ClienteId,Cliente")] Seguro seguro)
    {
        if (id != seguro.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(seguro);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguroExists(seguro.Id))
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
        return View(seguro);
    }

    // GET: SEGUROS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seguro = await _context.Seguros
            .FirstOrDefaultAsync(m => m.Id == id);
        if (seguro == null)
        {
            return NotFound();
        }

        return View(seguro);
    }

    // POST: SEGUROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var seguro = await _context.Seguros.FindAsync(id);
        if (seguro != null)
        {
            _context.Seguros.Remove(seguro);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SeguroExists(int? id)
    {
        return _context.Seguros.Any(e => e.Id == id);
    }
}
