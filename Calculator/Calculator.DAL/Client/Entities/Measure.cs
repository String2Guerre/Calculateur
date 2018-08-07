using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Client.Entities
{
    public class Measure
    {
        private int measureID;
        /// <summary>
        /// Clé primaire de la table "measure"
        /// </summary>
        public int MeasureID
        {
            get { return measureID; }
            set { measureID = value; }
        }

        private DateTime date;
        /// <summary>
        /// Date de la mesure
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Measure() { }

        public Measure(DateTime date)
        {
            this.Date = date;
        }
    }
}
