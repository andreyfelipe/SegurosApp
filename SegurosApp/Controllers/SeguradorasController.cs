using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegurosApp.Models;
using SegurosApp.Data;

public class SeguradorasController : Controller
{
    private readonly ApplicationDbContext _context;

    public SeguradorasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SEGURADORAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Seguradoras.ToListAsync());
    }

    // GET: SEGURADORAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seguradora = await _context.Seguradoras
            .FirstOrDefaultAsync(m => m.Id == id);
        if (seguradora == null)
        {
            return NotFound();
        }

        return View(seguradora);
    }

    // GET: SEGURADORAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SEGURADORAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nome,Cnpj,Telefone,Email,Ativa,Seguros")] Seguradora seguradora)
    {
        if (ModelState.IsValid)
        {
            _context.Add(seguradora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(seguradora);
    }

    // GET: SEGURADORAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seguradora = await _context.Seguradoras.FindAsync(id);
        if (seguradora == null)
        {
            return NotFound();
        }
        return View(seguradora);
    }

    // POST: SEGURADORAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nome,Cnpj,Telefone,Email,Ativa,Seguros")] Seguradora seguradora)
    {
        if (id != seguradora.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(seguradora);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeguradoraExists(seguradora.Id))
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
        return View(seguradora);
    }

    // GET: SEGURADORAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seguradora = await _context.Seguradoras
            .FirstOrDefaultAsync(m => m.Id == id);
        if (seguradora == null)
        {
            return NotFound();
        }

        return View(seguradora);
    }

    // POST: SEGURADORAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var seguradora = await _context.Seguradoras.FindAsync(id);
        if (seguradora != null)
        {
            _context.Seguradoras.Remove(seguradora);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SeguradoraExists(int? id)
    {
        return _context.Seguradoras.Any(e => e.Id == id);
    }
}
