using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecWeb.Dao;
using TecWeb.Models;

namespace TecWeb.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
               
        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create (FormCollection collection)
        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pessoaDAO pessoaDB = new pessoaDAO();
                    pessoaDB.Salvar(pessoa);

                    //return RedirectToAction("ObterTodos");
                    return Sucesso(pessoa);
                }
                catch(Exception ex)
                {
                    return View(ex.ToString());
                }
            }
            else
            {
                return View(pessoa);
            }            
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            Pessoa pessoa = new Pessoa();

            try
            {
                pessoaDAO pessoaDB = new pessoaDAO();
                pessoa = pessoaDB.BuscarPessoa(id);
            }
            catch
            {
                return View();
            }

            return View(pessoa);
        }

        // POST: Pessoa/Edit/5 (FormCollection collection)
        [HttpPost]
        public ActionResult Edit(int id, Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    pessoaDAO pessoaDB = new pessoaDAO();
                    pessoaDB.Editar(pessoa);

                    return RedirectToAction("ObterTodos");
                }
                catch(Exception ex)
                {
                    return View(ex.ToString());
                }
            }
            else
            {
                return View(pessoa);
            }
        }
        
        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                pessoaDAO pessoaDB = new pessoaDAO();
                pessoaDB.Deletar(id);

                return RedirectToAction("ObterTodos");
            }
            catch
            {
                return View();
            }
        }

        //Listar as pessoas
        public ActionResult ObterTodos()
        {
            pessoaDAO pessoaDB = new pessoaDAO();
            List<Pessoa> pessoa = pessoaDB.Listar();

            return View(pessoa);
        }

        //Página de sucesso, entrega dados da pessoa.
        public ActionResult Sucesso(Pessoa pessoa)
        {
            return View("Sucesso", pessoa);
        }
    }
}
