using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessEntity;
using BusinessEntity.ViewModels;

namespace BusinessLogicLayer
{
    public class CRUD_doctor_BLL
    {
        CRUD_doctor_DAL cdd = new CRUD_doctor_DAL();
        public void create(doctor d)
        {
            cdd.create(d);
        }
        public List<DoctorViewModel> Read()
        {
            return cdd.Read();
        }
        //public List<DoctorViewModel> read(string s)
        //{
        //    return cdd.read(s);
        //}
        public List<DoctorViewModel> read(string s)
        {
            return cdd.read(s);
        }
        public string update(int id, doctor dn)
        {
            return cdd.update(id, dn);
        }
    }
}
