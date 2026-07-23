
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DES___Desafio_1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class EmpleadoesController : Controller
{
    private readonly EmpleadosDbContext _context;

    public EmpleadoesController(EmpleadosDbContext context)
    {
        _context = context;
    }

    // GET: EMPLEADOS
    public async Task<IActionResult> Index()
    {
        return View(
            await _context.Empleados
                .Include(e => e.Departamento)
                .ToListAsync()
        );
    }

    // GET: EMPLEADOS/Details/5
    public async Task<IActionResult> Details(int? empleadoid)
    {
        if (empleadoid == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleados
            .FirstOrDefaultAsync(m => m.EmpleadoId == empleadoid);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // GET: EMPLEADOS/Create
    public IActionResult Create()
    {
    ViewBag.DepartamentoId = new SelectList(_context.Departamentos, "Id", "Nombre");
    return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("EmpleadoId,Nombre,FechaNacimiento,FechaContratacion,Salario,Descripcion,DepartamentoId,Departamento")] Empleado empleado)
    {
        if (ModelState.IsValid)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(empleado);
    }

    // GET: EMPLEADOS/Edit/5
    public async Task<IActionResult> Edit(int? empleadoid)
    {
        if (empleadoid == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleados.FindAsync(empleadoid);
        if (empleado == null)
        {
            return NotFound();
        }

        ViewBag.DepartamentoId = new SelectList(_context.Departamentos, "Id", "Nombre", empleado.DepartamentoId);
        return View(empleado);
    }

    // POST: EMPLEADOS/Edit/5

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? empleadoid, [Bind("EmpleadoId,Nombre,FechaNacimiento,FechaContratacion,Salario,Descripcion,DepartamentoId,Departamento")] Empleado empleado)
    {
        if (empleadoid != empleado.EmpleadoId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(empleado);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(empleado.EmpleadoId))
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
        return View(empleado);
    }

    // GET: EMPLEADOS/Delete/5
    public async Task<IActionResult> Delete(int? empleadoid)
    {
        if (empleadoid == null)
        {
            return NotFound();
        }

        var empleado = await _context.Empleados
            .FirstOrDefaultAsync(m => m.EmpleadoId == empleadoid);
        if (empleado == null)
        {
            return NotFound();
        }

        return View(empleado);
    }

    // POST: EMPLEADOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? empleadoid)
    {
        var empleado = await _context.Empleados.FindAsync(empleadoid);
        if (empleado != null)
        {
            _context.Empleados.Remove(empleado);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmpleadoExists(int? empleadoid)
    {
        return _context.Empleados.Any(e => e.EmpleadoId == empleadoid);
    }

}
