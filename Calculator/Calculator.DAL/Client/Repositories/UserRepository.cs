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

       
    }
}
