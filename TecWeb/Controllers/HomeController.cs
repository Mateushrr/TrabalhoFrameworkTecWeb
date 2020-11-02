using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TecWeb.Models;

namespace TecWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            List<Pessoa> membros = new List<Pessoa>();

            Pessoa p1 = new Pessoa() { cpf = "000.000.000-00", idade = "0", email = "alberto.paiva@sga.pucminas.br", nome = "Alberto Paiva" };
            Pessoa p2 = new Pessoa() { cpf = "000.000.000-00", idade = "0", email = "maria.a.b.lima@gmail.com", nome = "Maria Alice" };
            Pessoa p3= new Pessoa() { cpf = "000.000.000-00", idade = "0", email = "mateushrr@gmail.com", nome = "Mateus Henrique Rocha" };
            Pessoa p4= new Pessoa() { cpf = "000.000.000-00", idade = "0", email = "winclatisf@gmail.com", nome = "Winclatis Filipe" };

            membros.Add(p1);
            membros.Add(p2);
            membros.Add(p3);
            membros.Add(p4);

            ViewBag.Message = "Atividade de frameworks - Tecweb.";
            return View(membros);
        }
    }
}