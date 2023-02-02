namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICommand<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
