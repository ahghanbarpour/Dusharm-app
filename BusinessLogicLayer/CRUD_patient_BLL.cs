using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using BusinessEntity.ViewModels;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CRUD_patient_BLL
    {
        CRUD_patient_DAL cpd = new CRUD_patient_DAL();
        public string create(patient p)
        {
            if (!cpd.res(p))
            {
                return cpd.create(p);
            }
            else
            {
                return "روز و ساعت مورد نظر تداخل دارد";
            }
        }
        public List<PatientViewModel> Read()
        {
            return cpd.Read();
        }
        public List<PatientViewModel> read(string s)
        {
            return cpd.read(s);
        }
        public patient read(int id)
        {
            return cpd.read(id);
        }
        public string update(int id, patient pn)
        {
            return cpd.update(id, pn);
        }
        public string delete(int id)
        {
            return cpd.delete(id);
        }
        public bool check(patient p)
        {
            return cpd.check(p);
        }


    }
}
