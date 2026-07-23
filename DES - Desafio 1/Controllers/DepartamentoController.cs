
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DES___Desafio_1.Models;

public class DepartamentoController : Controller
{
    private readonly EmpleadosDbContext _context;

    public DepartamentoController(EmpleadosDbContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> Index()    
    {
        return View(await _context.Departamentos.ToListAsync());
    }


    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var departamento = await _context.Departamentos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (departamento == null)
        {
            return NotFound();
        }

        return View(departamento);
    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion")] Departamento departamento)
    {
        if (ModelState.IsValid)
        {
            _context.Add(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(departamento);
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var departamento = await _context.Departamentos.FindAsync(id);
        if (departamento == null)
        {
            return NotFound();
        }
        return View(departamento);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre,Descripcion")] Departamento departamento)
    {
        if (id != departamento.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(departamento);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(departamento.Id))
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
        return View(departamento);
    }


    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var departamento = await _context.Departamentos
            .FirstOrDefaultAsync(m => m.Id == id);
        if (departamento == null)
        {
            return NotFound();
        }

        return View(departamento);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var departamento = await _context.Departamentos.FindAsync(id);
        if (departamento != null)
        {
            _context.Departamentos.Remove(departamento);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DepartamentoExists(int? id)
    {
        return _context.Departamentos.Any(e => e.Id == id);
    }
}
