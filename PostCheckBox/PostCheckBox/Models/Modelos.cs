using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace PostCheckBox.Models
{
    public class Grupo
    {
        public int GrupoId { get; set; }
        public string Nome { get; set; }
        public ICollection<Permissao> Permissoes { get; set; }
    }

    public class Permissao
    {
        public int PermissaoId { get; set; }
        public string Descricao  { get; set; }
        public string Chave { get; set; }
    }

    public class BancoExemplo
    {
        public ICollection<Grupo> Grupos { get; set; }
        public ICollection<Permissao> Permissoes { get; set; }  
        public BancoExemplo()
        {
            Grupos = new Collection<Grupo>();
            Permissoes = new Collection<Permissao>();

            Permissoes.Add(new Permissao
                               {
                                   PermissaoId = 1,
                                   Descricao = "Alterar Usuário",
                                   Chave = "usuario_alterar"
                               });
            Permissoes.Add(new Permissao
            {
                PermissaoId = 2,
                Descricao = "Inserir Usuário",
                Chave = "usuario_inserir"
            });

            Permissoes.Add(new Permissao
            {
                PermissaoId = 3,
                Descricao = "Excluir Usuário",
                Chave = "usuario_excluir"
            });

            var grupo = new Grupo()
                            {
                                GrupoId = 1,
                                Nome = "Administrador de Usuário",
                                Permissoes = Permissoes.ToList()
                            };
            Grupos.Add(grupo);
        }
    }

    public class PermissoesAssociadasAoGrupo
    {
        public Permissao Permissao { get; set; }
        public bool Associado { get; set; }
    }
}