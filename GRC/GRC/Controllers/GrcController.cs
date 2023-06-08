using GRC.Domain;
using GRC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GRC.Controllers
{
    public class GrcController : Controller
    {
        private readonly GrcContext _context = new GrcContext();

        public GrcController(GrcContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Organisation> organisations = _context.Organisations.OrderBy( o => o.Nom).ThenBy(o => o.OrganisationId).ToList();
            return View(organisations);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Organisation organisation)
        {
            if (_context.Organisations.Any(o => o.OrganisationId.Equals(organisation.OrganisationId)))
            {
                ViewBag.Erreur = "Cette Organisation éxiste déja";
                return View(organisation);
            }
            _context.Organisations.Add(organisation);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
            Organisation organisationExistant = _context.Organisations.FirstOrDefault(o => o.OrganisationId.Equals(organisation.OrganisationId));
            if(organisationExistant == null) 
            {
                ViewBag.Erreur = "Cette Organisation n'éxiste pas";
                return View(organisation);
            }
            organisationExistant.Nom = organisation.Nom;
            organisationExistant.OrganisationId = organisation.OrganisationId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Delete(Organisation organisation)
        {
            if (_context.Organisations.Any(o => o.OrganisationId.Equals(organisation.OrganisationId)))
            {
                ViewBag.Erreur = "Cette Organisation à été supprimer";
                return View(organisation);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
