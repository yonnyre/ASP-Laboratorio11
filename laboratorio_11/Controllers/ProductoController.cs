using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using laboratorio_11.Models;
using laboratorio_11.Repository;

namespace laboratorio_11.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            ProductoRepository pr = new ProductoRepository();
            ModelState.Clear();

            return View(pr.GetAllProductos());
        }

        public ActionResult AddProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProducto(ProductoModel prod)
        {
            try
            {
                ProductoRepository pr = new ProductoRepository();
                if (pr.AddProducto(prod))
                {
                    ViewBag.message = "Almacenado correctamente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult EditProducto(int id)
        {
            ProductoRepository pr = new ProductoRepository();
            return View(pr.GetAllProductos().Find(Prod => Prod.IdProducto == id));
        }

        [HttpPost]
        public ActionResult EditProducto(ProductoModel prod)
        {
            try
            {
                ProductoRepository pr = new ProductoRepository();
                pr.UpdateProducto(prod);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteProducto(int id)
        {
            try
            {
                ProductoRepository pr = new ProductoRepository();
                if (pr.DeleteProducto(id))
                {
                    ViewBag.message = "Eliminado correctamente";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}