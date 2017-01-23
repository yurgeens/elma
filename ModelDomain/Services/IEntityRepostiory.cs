using System.Collections.Generic;
namespace Services
{
    /// <summary>
    /// Общее хранилище данных
    /// </summary>
    /// <typeparam name="T">Любой класс</typeparam>
    public interface IEntityRepostiory<T>
        where T : class
    {
        /// <summary>
        /// Создать операцию
        /// </summary>
        /// <returns></returns>
        T Create();

        T Load(int Id);

        //T Find(string name);

        bool Delete(int Id);

        void Update(T operResult);

        IEnumerable<T> GetAll();
    }
}