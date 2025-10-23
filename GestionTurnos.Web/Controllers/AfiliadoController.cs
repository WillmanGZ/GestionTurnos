using GestionTurnos.Web.Data;
using GestionTurnos.Web.Helpers;
using GestionTurnos.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Web.Controllers
{
    public class AfiliadoController : Controller
    {
        private readonly AppDbContext _context;

        public AfiliadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Afiliado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Afiliados.ToListAsync());
        }

        // GET: Afiliado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // GET: Afiliado/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Afiliado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Documento,Sexo,Correo,Telefono")] Afiliado afiliado)
        {
            // TODO: Do a dynamic photo
            if (afiliado.Sexo == "Masculino")
            {
                afiliado.FotoUrl = "../Assets/man-profile.png";
            }
            else
            {
                afiliado.FotoUrl = "../Assets/woman-profile.png";
            }

            if (!ModelState.IsValid)
            {
                foreach (var e in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {e.ErrorMessage}");
                }
            }


            if (ModelState.IsValid)
            {
                Console.WriteLine("Entré");
                _context.Add(afiliado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(afiliado);
        }

        // GET: Afiliado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Documento,Sexo,Correo,Telefono")] Afiliado afiliado)
        {
            if (id != afiliado.Id)
            {
                return NotFound();
            }

            // TODO: Do a dynamic photo
            if (afiliado.Sexo == "Masculino")
            {
                afiliado.FotoUrl = "../Assets/man-profile.png";
            }
            else
            {
                afiliado.FotoUrl = "../Assets/woman-profile.png";
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afiliado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfiliadoExists(afiliado.Id))
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
            return View(afiliado);
        }

        // GET: Afiliado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return View(afiliado);
        }

        // POST: Afiliado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afiliado = await _context.Afiliados.FindAsync(id);
            if (afiliado != null)
            {
                _context.Afiliados.Remove(afiliado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfiliadoExists(int id)
        {
            return _context.Afiliados.Any(e => e.Id == id);
        }

        // GET: Afiliado/Carnet/5
        public async Task<IActionResult> Carnet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _context.Afiliados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (afiliado == null)
            {
                return NotFound();
            }

            ViewBag.QR = QRHelper.GenerarQRParaAfiliado(afiliado.Id);

            return View(afiliado);
        }
    }
}
