using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ecoMonedas.Models
{
    public class UsuarioLN
    {
        public static IQueryable queryListaCategorias()
        {
            var db = new ContextoUsuario();
            IQueryable query = db.Usuarios;
            return query;
        }

        public static IEnumerable<Usuario> listaCategorias()
        {
            IEnumerable<Usuario> lista = (IEnumerable<Usuario>)
                UsuarioLN.queryListaCategorias();
            return lista;
        }
    }
}