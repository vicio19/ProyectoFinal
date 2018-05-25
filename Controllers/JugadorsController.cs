using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class JugadorsController : Controller
    {
        private readonly FinalContext _context;

        public JugadorsController(FinalContext context)
        {
            _context = context;
        }

        // GET: Jugadors
        public async Task<IActionResult> Index(int? idPais)
        {
            if (idPais != null)
            {
                var finalContext = _context.Jugadores.Include(j => j.Pais);
                return View(await finalContext.Where(jug => jug.PaisID==idPais).ToListAsync());
            }
            else
            {
                var finalContext = _context.Jugadores.Include(j => j.Pais);
                return View(await finalContext.ToListAsync());

            }
        }

        // GET: Jugadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Pais)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // GET: Jugadors/Create
        public IActionResult Create()
        {
            ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "Nombre");
            return View();
        }

        // POST: Jugadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PaisID,Nombres,Apellido_p,Apellido_M,Lugar_Nac,Fecha_Nac,Altura,Peso,Club,Foto,Condicion,Fuerza,Velocidad,Reacción,Control_de_Balon,Anotacion,Barrida,Centros,Defensa,Marcaje,Carcateristica1,Carcateristica2")] Jugador jugador, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                    try
                    {
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Jugadores",
                                                   Path.GetFileName(file.FileName));
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        jugador.Foto = "/images/Jugadores/" + file.FileName;
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }

                jugador.ID = _context.Jugadores.Max(M => M.ID);
                jugador.ID = jugador.ID + 1;


                _context.Add(jugador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "Nombre", jugador.PaisID);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores.SingleOrDefaultAsync(m => m.ID == id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "Nombre", jugador.PaisID);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PaisID,Nombres,Apellido_p,Apellido_M,Lugar_Nac,Fecha_Nac,Altura,Peso,Club,Foto,Condicion,Fuerza,Velocidad,Reacción,Control_de_Balon,Anotacion,Barrida,Centros,Defensa,Marcaje,Carcateristica1,Carcateristica2")] Jugador jugador, IFormFile file)
        {
            if (id != jugador.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (file != null && file.Length > 0)
                        try
                        {
                            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Banderas",
                                                       Path.GetFileName(file.FileName));
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                            jugador.Foto = "/images/Banderas/" + file.FileName;
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        }
                    else
                    {
                        ViewBag.Message = "You have not specified a file.";
                    }

                    _context.Update(jugador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JugadorExists(jugador.ID))
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
            ViewData["PaisID"] = new SelectList(_context.Paises, "ID", "Nombre", jugador.PaisID);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jugador = await _context.Jugadores
                .Include(j => j.Pais)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jugador = await _context.Jugadores.SingleOrDefaultAsync(m => m.ID == id);
            _context.Jugadores.Remove(jugador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JugadorExists(int id)
        {
            return _context.Jugadores.Any(e => e.ID == id);
        }
    }
}
