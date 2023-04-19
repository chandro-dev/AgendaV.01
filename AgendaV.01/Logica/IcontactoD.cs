using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public interface IcontactoD
    {

        string Add(IcontactoD e);
        List<ContactoFamiliar> GetAll();
        bool Delete(ContactoFamiliar contacto);
        bool Update(ContactoFamiliar contacto);
        List<ContactoFamiliar> GetByPhone(string phone);
        Task<List<ContactoFamiliar>> GetByName(string name);
        bool Exist(ContactoFamiliar contacto);
    }
}
