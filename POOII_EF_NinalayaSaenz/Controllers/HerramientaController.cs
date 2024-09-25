using Dominio.Entidad.Negocios.Entidad;
using Infraestructura.Data.Negocio;
using System.Web.Mvc;

namespace POOII_EF_NinalayaSaenz.Controllers
{
    public class HerramientaController : Controller
    {
        HerraCategoriaDAO _herraCategoriaDAO = new HerraCategoriaDAO();

        HerramientaDAO _herramientaDAO = new HerramientaDAO();
        CategoriaDAO _categoriaDAO = new CategoriaDAO();

        public ActionResult Index(int? idcat)
        {
            ViewBag.categorias = new SelectList(_categoriaDAO.GetAll(), "idcategoria", "nomcategoria");
            return View(_herraCategoriaDAO.GetXCategoria(idcat));
        }

        public ActionResult Agregar()
        {
            ViewBag.categorias = new SelectList(_categoriaDAO.GetAll(),"idcategoria","nomcategoria");
            return View(new Herramienta());
        }
        [HttpPost]
        public ActionResult Agregar(Herramienta reg)
        {
            ViewBag.mensaje = _herramientaDAO.Add(reg);
            ViewBag.categorias = new SelectList(_categoriaDAO.GetAll(), "idcategoria", "nomcategoria",reg.IdCategoria);
            return View(reg);
        }        

        public ActionResult Editar(string IdHer)
        {
            Herramienta reg = _herramientaDAO.Find(IdHer);

            ViewBag.categorias = new SelectList(_categoriaDAO.GetAll(), "idcategoria", "nomcategoria", reg.IdCategoria);
            return View(reg);
        }

        [HttpPost]
        public ActionResult Editar(Herramienta reg)
        {
            ViewBag.mensaje = _herramientaDAO.Update(reg);
            ViewBag.categorias = new SelectList(_categoriaDAO.GetAll(), "idcategoria", "nomcategoria", reg.IdCategoria);
            return View(reg);            
        }

        public ActionResult Borrar(string IdHer)
        {
            if (IdHer == null)           
                return RedirectToAction("Index");

            ViewBag.mensaje = _herramientaDAO.Delete(IdHer);
            return RedirectToAction("Index");
        }
    }
}