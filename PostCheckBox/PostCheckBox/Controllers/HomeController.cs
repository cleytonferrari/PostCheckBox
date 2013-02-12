using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PostCheckBox.Models;

namespace PostCheckBox.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            var grupo = new Grupo() { Permissoes = new Collection<Permissao>() };
            ViewBag.Permissoes = PopularPermissoesAssociadas(grupo);
            return View(grupo);
        }

        [HttpPost]
        public ActionResult Cadastrar([Bind(Exclude = "Permissoes")]Grupo grupo, int[] permissoesSelecionadas)
        {
            grupo.Permissoes = new List<Permissao>();
            foreach (var permissoesSelecionada in permissoesSelecionadas)
            {
                var permissao = new BancoExemplo().Permissoes.FirstOrDefault(x => x.PermissaoId == permissoesSelecionada);
                grupo.Permissoes.Add(permissao);
            }
            ViewBag.Permissoes = PopularPermissoesAssociadas(grupo);
            return View(grupo);
        }


        private List<PermissoesAssociadasAoGrupo> PopularPermissoesAssociadas(Grupo grupo)
        {
            var todasPermissoes = new BancoExemplo().Permissoes.ToList();
            var permissoesGrupo = new HashSet<int>(grupo.Permissoes.Select(c => c.PermissaoId));
            var viewModel = new List<PermissoesAssociadasAoGrupo>();
            foreach (var permissao in todasPermissoes)
            {
                viewModel.Add(new PermissoesAssociadasAoGrupo
                {
                    Permissao = permissao,
                    Associado = permissoesGrupo.Contains(permissao.PermissaoId)
                });
            }
            return viewModel;
        }

    }
}
