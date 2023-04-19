using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Logica
{
    public interface IContactoFamiliar<i>
    {
        string Add(i contacto);    
        List<i> GetAll();
        bool Delete( i contacto);
        bool Update( i contacto);
        i GetByPhone(string phone);
        List<i> GetByName(string name);
        bool Exist(i contacto);
    }
}
