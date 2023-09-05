using Restful_Example.ViewModels;

namespace Restful_Example.Repos
{
    public interface IUserRepo
    {
        public List<UserViewModel> GetAll();
        public UserViewModel GetById(Guid Id);
        public void Add(UserViewModel model);
        public void Update(UserViewModel model);
        public void Delete(Guid id);
    }
}
