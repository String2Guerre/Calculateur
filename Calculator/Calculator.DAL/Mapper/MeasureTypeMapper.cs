using G = Calculator.DAL.Global.Entities;
using C = Calculator.DAL.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Mapper
{
    public static class MeasureTypeMapper
    {
        public static G.MeasureType ToGlobal(C.MeasureType entity)
        {
            return new G.MeasureType()
            {
                MeasureTypeID = entity.MeasureTypeID,
                Name = entity.Name,
                Value = entity.Value,
                MeasureID = entity.MeasureID
            };
        }

        public static List<G.MeasureType> ToGlobal(List<C.MeasureType> entities)
        {
            List<G.MeasureType> measureTypes = new List<G.MeasureType>();

            foreach (C.MeasureType item in entities)
            {
                measureTypes.Add(ToGlobal(item));
            }

            return measureTypes;
        }

        public static C.MeasureType ToClient(G.MeasureType entity)
        {
            return new C.MeasureType()
            {
                MeasureTypeID = entity.MeasureTypeID,
                Name = entity.Name,
                Value = entity.Value,
                MeasureID = entity.MeasureID
            };
        }

        public static List<C.MeasureType> ToClient(List<G.MeasureType> entities)
        {
            List<C.MeasureType> measureTypes = new List<C.MeasureType>();

            foreach (G.MeasureType item in entities)
            {
                measureTypes.Add(ToClient(item));
            }

            return measureTypes;
        }
    }
}
