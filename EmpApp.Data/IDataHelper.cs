using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp.Data
{
    public interface IDataHelper<Table>
    {
        // Read
        List<Table> GetAll();
        List<Table> Search(string searchIteam);
        Table GetById(int id);

        // Write
        int Add(Table table);
        int Update(Table table);
        int Delete(Table table);

        // 
        bool IsConnect();
    }
}
