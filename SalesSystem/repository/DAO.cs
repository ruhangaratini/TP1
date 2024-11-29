using SalesSystem.model;

namespace SalesSystem.repository {
    internal abstract class DAO<T> where T : IEntity {
        private readonly List<T> Data;
        private static int LastCode = 0;

        public DAO() {
            this.Data = [];
        }

        public void Add(T item) {
            item.SetCode(this.GenerateID());
            this.Data.Add(item);
        }

        public T? GetByCode(int code) {
            return this.Data.Find(x => x.GetCode() == code);
        }

        public T[] GetAll() { 
            return this.Data.ToArray();
        }

        public bool Remove(T item) {
            return this.Data.Remove(item);
        }

        public int GenerateID() {
            return ++LastCode;
        }
    }
}
