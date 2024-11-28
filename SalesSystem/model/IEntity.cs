using SalesSystem.repository;

namespace SalesSystem.model {
    internal interface IEntity {
        public int GetCode();
        void SetCode(Func<int> generateID);
    }
}
