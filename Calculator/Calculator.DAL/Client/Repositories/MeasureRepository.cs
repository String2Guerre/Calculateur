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
    public class MeasureRepository
    {
        private MeasureRepository instance;
        public MeasureRepository Instance
        {
            get { return instance ?? (instance = new MeasureRepository()); }
        }

        private GR.MeasureRepository MeasureRepo;

        public MeasureRepository()
        {
            MeasureRepo = new GR.MeasureRepository();
        }


        public C.Measure GetOne(int id)
        {
            return MeasureMapper.ToClient(MeasureRepo.GetOne(id));
        }

        public List<C.Measure> GetAll()
        {
            return MeasureMapper.ToClient(MeasureRepo.GetAll());
        }

        public int Insert(C.Measure entity)
        {
            return MeasureRepo.Insert(MeasureMapper.ToGlobal(entity));
        }

        public bool Update(C.Measure entity)
        {
            return MeasureRepo.Update(MeasureMapper.ToGlobal(entity));
        }

        public bool Delete(int id)
        {
            return MeasureRepo.Delete(id);
        }
    }
}
