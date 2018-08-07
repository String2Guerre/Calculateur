using G = Calculator.DAL.Global.Entities;
using C = Calculator.DAL.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Mapper
{
    public class UserMapper
    {
        public G.User ToGlobal(C.User entity)
        {
            return new G.User()
            {
                UserID = entity.UserID,
                Name=entity.Name,
                Email=entity.Email,
                Pwd=entity.Pwd,
                Gender=entity.Gender,
                Birthdate=entity.Birthdate,
                InitialWeight=entity.InitialWeight
            };
        }

        public List<G.User> ToGlobal(List<C.User> entities)
        {
            List<G.User> users = new List<G.User>();

            foreach (C.User item in entities)
            {
                users.Add(ToGlobal(item));
            }

            return users;
        }

        public C.User ToCLient(G.User entity)
        {
            return new C.User()
            {
                UserID = entity.UserID,
                Name = entity.Name,
                Email = entity.Email,
                Pwd = entity.Pwd,
                Gender = entity.Gender,
                Birthdate = entity.Birthdate,
                InitialWeight = entity.InitialWeight
            };
        }

        public List<C.User> ToClient(List<G.User> entities)
        {
            List<C.User> users = new List<C.User>();

            foreach (G.User item in entities)
            {
                users.Add(ToCLient(item));
            }

            return users;
        }
    }
}
