using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Global.Entities
{
    public class MeasureType
    {
        private int measureTypeID;
        /// <summary>
        /// Clé primaire de la table "measure_type"
        /// </summary>
        public int MeasureTypeID
        {
            get { return measureTypeID; }
            set { measureTypeID = value; }
        }

        private string name;
        /// <summary>
        /// Nom de ce qui est mesuré (Tour de taille, tour de poitrine, tour de bras, ...)
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private double value;
        /// <summary>
        /// Valeur de ce qui est mesuré
        /// </summary>
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }

        private int measureID;
        /// <summary>
        /// Clé étrangère de la table "mesure"
        /// </summary>
        public int MeasureID
        {
            get { return measureID; }
            set { measureID = value; }
        }
    }
}
