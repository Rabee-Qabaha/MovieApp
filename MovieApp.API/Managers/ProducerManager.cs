using MovieApp.Core.Models;
using MovieApp.EF.Repositories;

namespace MovieApp.API.Managers
{
    public class ProducerManager
    {
        public ProducerRepository _repo;
        public ProducerManager(ProducerRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Producer>> getAll() => await this._repo.GetAll();
        public async Task<IEnumerable<Producer>> findByName(string name) => await this._repo.Find(p => p.Name == name);
        public async Task<IEnumerable<Producer>> findById(int Id) => await this._repo.Find(p => p.Id == Id);
        public async Task<Producer> getById(int Id) => await this._repo.GetById(Id);
        public async Task<Producer> add(Producer producer) => await this._repo.Add(producer);

    }
}
