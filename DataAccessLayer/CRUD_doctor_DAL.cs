using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using BusinessEntity.ViewModels;

namespace DataAccessLayer
{
    public class CRUD_doctor_DAL
    {
       Database db = new Database();
       public void create(doctor d)
        {
            db.crud_d.Add(d);
            db.SaveChanges();
        }
       //public List<doctor> read(string s)
       // {
       //     return db.crud_d.Where(i => i.family.Contains(s)).ToList();
       // }
       public doctor read(int id)
        {
            return db.crud_d.Where(i => i.id == id).Single();
        }
        public List<DoctorViewModel> Read()
        {
            var q = db.crud_d.Include("patient");
            List<DoctorViewModel> lst =
              q.Select(x => new DoctorViewModel
                {
                    family = x.family,
                    rdate = x.rdate,
                    rtime = x.rtime,
                    field = x.field
                }).ToList();
            return lst;
            //return db.crud_d.Include("patient")..ToList();
            //List<DoctorViewModel>
        }
        public List<DoctorViewModel> read(string s)
        {
            return db.crud_d.Include("patient") // alan run kon va moshkel ro neshon bede
                .Where(i => i.family.Contains(s))
                .Select(x => new DoctorViewModel
                {
                    field = x.field,
                    family = x.family,
                    
                }).ToList();
        }

        public string update(int id, doctor dn)
        {
            doctor d = new doctor();
            d = read(id);
            d.field = dn.field;
            d.family = dn.family;
            d.rdate = dn.rdate;
            d.rtime = dn.rtime;
            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }
       public bool res(doctor d)
        {
            return db.crud_d.Any(i => i.rdate == d.rdate && i.rtime == d.rtime);
        }

    }
}
