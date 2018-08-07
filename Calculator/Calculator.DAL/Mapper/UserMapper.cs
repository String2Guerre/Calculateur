using G = Calculator.DAL.Global.Entities;
using C = Calculator.DAL.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Mapper
{
    public static class UserMapper
    {
        public static G.User ToGlobal(C.User entity)
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

        public static List<G.User> ToGlobal(List<C.User> entities)
        {
            List<G.User> users = new List<G.User>();

            foreach (C.User item in entities)
            {
                users.Add(ToGlobal(item));
            }

            return users;
        }

        public static C.User ToClient(G.User entity)
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

        public static List<C.User> ToClient(List<G.User> entities)
        {
            List<C.User> users = new List<C.User>();

            foreach (G.User item in entities)
            {
                users.Add(ToClient(item));
            }

            return users;
        }
    }
}
