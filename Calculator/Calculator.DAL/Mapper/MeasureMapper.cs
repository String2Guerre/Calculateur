using G = Calculator.DAL.Global.Entities;
using C = Calculator.DAL.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Mapper
{
    public class MeasureMapper
    {
        public G.Measure ToGlobal(C.Measure entity)
        {
            return new G.Measure()
            {
                MeasureID = entity.MeasureID,
                Date = entity.Date
            };
        }

        public List<G.Measure> ToGlobal(List<C.Measure> entities)
        {
            List<G.Measure> measures = new List<G.Measure>();

            foreach (C.Measure item in entities)
            {
                measures.Add(ToGlobal(item));
            }

            return measures;
        }

        public C.Measure ToClient(G.Measure entity)
        {
            return new C.Measure()
            {
                MeasureID = entity.MeasureID,
                Date = entity.Date
            };
        }

        public List<C.Measure> ToClient(List<G.Measure> entities)
        {
            List<C.Measure> measures = new List<C.Measure>();

            foreach (G.Measure item in entities)
            {
                measures.Add(ToClient(item));
            }

            return measures;
        }
    }
}
