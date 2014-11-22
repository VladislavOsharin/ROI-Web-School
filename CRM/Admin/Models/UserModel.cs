namespace Crm.Admin.Models
{
    using System;
    using Domain;

    public class UserModel : IUser
    {
        public int Id { get; private set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserModel(IUser user)
        {
            if (user == null) throw new ArgumentNullException("user");
            Id = user.Id;
            Login = user.Login;
            FirstName = user.FirstName;
            LastName = user.LastName;
        }

        public UserModel(int id)
            : this(ServiceFactory.Resolve<IUserService>().Read(id))
        { }

        public void Save()
        {
            ServiceFactory.Resolve<IUserService>().Update(this);
        }

        public void Delete()
        {
            ServiceFactory.Resolve<IUserService>().Delete(Id);
        }

        public static void Delete(int id)
        {
            if (id != 0)
                ServiceFactory.Resolve<IUserService>().Delete(id);
        }
    }
}