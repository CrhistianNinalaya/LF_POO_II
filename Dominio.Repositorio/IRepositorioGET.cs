using System.Collections.Generic;

namespace Dominio.Repositorio
{
    public interface IRepositorioGET<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetXCategoria(int? idcat);
    }
}
