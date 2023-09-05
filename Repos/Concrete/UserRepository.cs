using Restful_Example.ViewModels;

namespace Restful_Example.Repos
{
    public class UserRepository : IUserRepo
    {
        private static  List<UserViewModel> UsersList = new List<UserViewModel>
        {
            new UserViewModel { Id = Guid.NewGuid(),Name="Eslam"},
            new UserViewModel { Id = Guid.NewGuid(),Name="Zidan"}
        };
        public void Add(UserViewModel model)
        {
            model.Id= Guid.NewGuid();
            UsersList.Add(model);
        }

        public void Delete(Guid id)
        {
           var user= UsersList.Where(c => c.Id == id).FirstOrDefault();

            if( user!=null)
                UsersList.Remove(user);
            else
            throw new Exception("Object Not Found");
        }

        public List<UserViewModel> GetAll()
        {
            return UsersList;
        }

        public UserViewModel GetById(Guid Id)
        {
            var user = UsersList.Where(c => c.Id == Id).FirstOrDefault();
            if (user != null)
                return user;
            else
            throw new Exception("Object Not Found");
        }

        public void Update(UserViewModel model)
        {
            var user = UsersList.FirstOrDefault(c => c.Id == model.Id);

            if (user == null)
            throw new Exception("Object Not Found");

            user.Name = model.Name;
        }
    }
}
