using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using BusinessEntity.ViewModels;

namespace DataAccessLayer
{
    public class CRUD_patient_DAL
    {
        Database db = new Database();
        public string create(patient p)
        {
            if (!read(p))
            {
                if (p.tel.Length == 11)
                {
                    if (!check(p))
                    {
                        p.code = Random();
                        db.crud_p.Add(p);
                        db.SaveChanges();
                        return "ثبت اطلاعات با موفقیت انجام شد" + "\n" + "شماره پرونده:" + Convert.ToString(p.code);
                    }
                    else
                    {
                        p.code = selectCode(p);
                        db.crud_p.Add(p);
                        db.SaveChanges();
                        return "خدمت جدید بیمار ثبت شد";
                    }
                }
                else
                {
                    return "شماره تلفن وارد شده نامعتبر است";
                }
            }
            else
            {
                return "اطلاعات وارد شده تکراری است";
            }
        }
        public List<PatientViewModel> Read()
        {
            return db.crud_p.Include("doctor")
                .Select(x => new PatientViewModel 
                {
                    code = x.code,
                    name = x.name,
                    Birthday = x.Birthday,
                    DoctorName = x.doctor.family,
                    tel = x.tel,
                    family = x.family,
                    rdate = x.rdate,
                    rtime = x.rtime
                }).ToList();
        }
        public bool read(patient p)
        {
            return db.crud_p.Any(i => i.name == p.name && i.family == p.family && i.Birthday == p.Birthday && i.rdate == p.rdate && i.rtime == p.rtime);
        }
        public List<PatientViewModel> read(string s) 
        { 
            return db.crud_p.Include("doctor") 
                .Where(i => i.name.Contains(s) || i.family.Contains(s))
                .Select(x => new PatientViewModel
                {
                    code = x.code,
                    name = x.name,
                    Birthday = x.Birthday,
                    DoctorName = x.doctor.family
                }).ToList();

        }
        public patient read(int id)
        {
            return db.crud_p.Where(i => i.id == id).FirstOrDefault();
        }
        public string update(int id, patient pn)
        {
            patient p = new patient();
            p = read(id);
            p.name = pn.name;
            p.family = pn.family;
            p.Birthday = pn.Birthday;
            p.rtime = pn.rtime;
            p.rdate = pn.rdate;
            p.doctor = pn.doctor;
            p.tel = pn.tel;
            p.code = pn.code;
            db.SaveChanges();
            return "ویرایش اطلاعات با موفقیت انجام شد";
        }
        public string delete(int id)
        {
            patient p = read(id);
            db.crud_p.Remove(p);
            db.SaveChanges();
            return "اطلاعات مورد نظر با موفقیت حذف گردید";
        }
        public bool res(patient p)
        {
            return db.crud_p.Any(i=>i.rdate == p.rdate && i.rtime == p.rtime);
        }
        public int Random()
        {
            Random rnd = new Random();
            int c = rnd.Next(22548, 98657);
            return c;
        }
        public bool check(patient p)
        {
            return db.crud_p.Any(i => i.name == p.name && i.family == p.family && i.tel == p.tel && i.Birthday == p.Birthday);
        }
        public int selectCode(patient p)
        {
            return p.code;
        }

    }
}
