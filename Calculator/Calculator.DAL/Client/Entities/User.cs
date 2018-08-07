using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Client.Entities
{
    public class User
    {
        private int userID;
        /// <summary>
        /// Clé primaire de la table "User"
        /// </summary>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string name;
        /// <summary>
        /// Nom de l'utilisateur (max. 25 caractères)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string email;
        /// <summary>
        /// Adresse mail de l'utilisateur (max. 320 caractères)
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string pwd;
        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        private DateTime birthdate;
        /// <summary>
        /// Date de naissance de l'utilsateur (format jj/mm/aaaa - facultatif à la création du compte)
        /// </summary>
        public DateTime Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        private string gender;
        /// <summary>
        /// Sexe de l'utilisateur (1 caractère - facultatif à la création du compte)
        /// </summary>
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private double initialWeight;
        /// <summary>
        /// Poids initial de l'utilisateur (facultatif à la création du compte)
        /// </summary>
        public double InitialWeight
        {
            get { return initialWeight; }
            set { initialWeight = value; }
        }


        public User()
        { }

        public User(string name, string email, string pwd)
        {
            this.Name = name;
            this.Email = email;
            this.Pwd = pwd;
        }
    }
}
