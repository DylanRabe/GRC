using GRC.Domain;
using GRC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GRC.Controllers
{
    public class GrcController : Controller
    {
        private readonly GrcContext _context = new GrcContext();
        public IActionResult Index()
        {
            List<Organisation> organisations = _context.Organisations.OrderBy( o => o.Nom).ThenBy(o => o.OrganisationId).ToList();
            return View(organisations);
        }

        public IActionResult Edit(String id)
        {
            Organisation organisation = _context.Organisations.FirstOrDefault(o => o.OrganisationId.Equals(id));
            if (organisation == null)
            {
                return NotFound();
            }
            return View(organisation);
        }

        //recuperer la valeure

        [HttpPost]
        public IActionResult Edit(Organisation organisation) 
        {
            return RedirectToAction("Index");
        }
    }
}
