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
    public class MeasureTypeRepository
    {
        private MeasureTypeRepository instance;
        public MeasureTypeRepository Instance
        {
            get { return instance ?? (instance = new MeasureTypeRepository()); }
        }

        private GR.MeasureTypeRepository MeasureTypeRepo;

        public MeasureTypeRepository()
        {
            MeasureTypeRepo = new GR.MeasureTypeRepository();
        }



        public C.MeasureType GetOne(int id)
        {
            return MeasureTypeMapper.ToClient(MeasureTypeRepo.GetOne(id));
        }

        public List<C.MeasureType> GetAll()
        {
            return MeasureTypeMapper.ToClient(MeasureTypeRepo.GetAll());
        }

        public int Insert(C.MeasureType entity)
        {
            return MeasureTypeRepo.Insert(MeasureTypeMapper.ToGlobal(entity));
        }

        public bool Update(C.MeasureType entity)
        {
            return MeasureTypeRepo.Update(MeasureTypeMapper.ToGlobal(entity));
        }

        public bool Delete(int id)
        {
            return MeasureTypeRepo.Delete(id);
        }
    }
}
