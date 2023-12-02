using EmpApp.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp.Data
{
    public class EmpEnitty : IDataHelper<EmployeeData>
    {
        DataContext db;
        public EmpEnitty()
        {
            db = new DataContext();
        }
        public int Add(EmployeeData table)
        {
            try
            {
                db.EmployeeData.Add(table);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
            
        }

        public int Delete(EmployeeData table)
        {
            try
            {
                db.EmployeeData.Remove(table);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public List<EmployeeData> GetAll()
        {
            try
            {
              return db.EmployeeData.ToList();
            }
            catch
            {
                return new List<EmployeeData>();
            }
        }

        public EmployeeData GetById(int id)
        {
            try
            {
                return db.EmployeeData.Find(id);
            }
            catch
            {
                return new EmployeeData();
            }
        }

        public bool IsConnect()
        {
            try
            {
                return db.Database.CanConnect();
            }
            catch
            {
                return false;
            }
        }

        public List<EmployeeData> Search(string searchIteam)
        {
            try
            {
                return db.EmployeeData.Where(x=>x.Id.ToString()==searchIteam||
                x.FullName.Contains(searchIteam)||
                x.MotherName.Contains(searchIteam)||
                x.Address.Contains(searchIteam)||
                x.Phone.Contains(searchIteam)||
                x.Email.Contains(searchIteam)
                )
                    .ToList();
            }
            catch
            {
                return new List<EmployeeData>();
            }
        }

        public int Update(EmployeeData table)
        {
            try
            {
                db = new DataContext();
                db.EmployeeData.Update(table);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
