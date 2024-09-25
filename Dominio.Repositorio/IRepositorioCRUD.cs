namespace Dominio.Repositorio
{
    public interface IRepositorioCRUD<T> where T : class
    {
        string Add(T registro);
        string Update(T registro);
        string Delete(string registro);
        T Find(string id);
    }
}
