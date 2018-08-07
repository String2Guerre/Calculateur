using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GR = Calculator.DAL.Global.Repositories;
using G = Calculator.DAL.Global.Entities;
using C = Calculator.DAL.Client.Entities;
using Calculator.DAL.Mapper;

namespace Calculator.DAL.Client.Repositories
{
    public class UserRepository
    {
        private UserRepository instance;
        public UserRepository Instance
        {
            get { return instance ?? (instance = new UserRepository()); }
        }

        private GR.UserRepository UserRepo;

        public UserRepository()
        {
            UserRepo = new GR.UserRepository();
        }



        public C.User GetOne(int id)
        {
            return UserMapper.ToClient(UserRepo.GetOne(id));
        }

        public List<C.User> GetAll()
        {
            return UserMapper.ToClient(UserRepo.GetAll());
        }

        public int Insert(C.User entity)
        {
            return UserRepo.Insert(UserMapper.ToGlobal(entity));
        }

        public bool Update(C.User entity)
        {
            return UserRepo.Update(UserMapper.ToGlobal(entity));
        }

        public bool Delete(int id)
        {
            return UserRepo.Delete(id);
        }
    }
}
