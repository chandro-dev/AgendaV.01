using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Logica
{
    public interface Icontacto <T>
    {
        
        string Add(T e);
        List<T> GetAll();
        bool Delete(T contacto);
        bool Update(T contacto);
        List<T> GetByPhone(string phone);
        List<T> GetByName(string name);
        bool Exist(T contacto);
    }
}
