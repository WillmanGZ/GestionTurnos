using GestionTurnos.Web.Data.Entities;
using GestionTurnos.Web.Helpers;
using GestionTurnos.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Web.Controllers
{
    public class AfiliadoController : Controller
    {
        private readonly IAfiliadoServicio _afiliadoServicio;

        public AfiliadoController(IAfiliadoServicio afiliadoServicio)
        {
            _afiliadoServicio = afiliadoServicio;
        }


        // GET: Afiliado
        public async Task<IActionResult> Index()
        {
            return View(await _afiliadoServicio.GetAllAfiliados());
        }

        // GET: Afiliado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _afiliadoServicio.GetAfiliadoById(id.Value);

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

            if (ModelState.IsValid)
            {
                await _afiliadoServicio.CreateAfiliado(afiliado);
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

            var afiliado = await _afiliadoServicio.GetAfiliadoById(id.Value);

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
                    await _afiliadoServicio.UpdateAfiliado(afiliado);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AfiliadoExists(afiliado.Id))
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

            var afiliado = await _afiliadoServicio.GetAfiliadoById(id.Value);

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
            var afiliado = await _afiliadoServicio.GetAfiliadoById(id);

            if (afiliado != null)
            {
                await _afiliadoServicio.DeleteAfiliado(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AfiliadoExists(int id)
        {
            return await _afiliadoServicio.GetAfiliadoById(id) != null;
        }

        // GET: Afiliado/Carnet/5
        public async Task<IActionResult> Carnet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afiliado = await _afiliadoServicio.GetAfiliadoById(id.Value);

            if (afiliado == null)
            {
                return NotFound();
            }

            ViewBag.QR = QRHelper.GenerarQRParaAfiliado(afiliado.Id);

            return View(afiliado);
        }
    }
}
