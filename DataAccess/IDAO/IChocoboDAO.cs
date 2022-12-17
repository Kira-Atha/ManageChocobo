using ChocoboManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoboManagement.DataAccess.IDAO {
     public interface IChocoboDAO {
        public List<Chocobo> GetChocobos();
        public List <Chocobo> GetChocobosAvailables();
        public List<Chocobo> GetStableChocobosByStableId(int stableId);
        public void AddStableChocobo(Chocobo Chocobo);
        public void AddChocobo(Chocobo chocobo);
        public void ModifyChocobo(Chocobo chocobo);
        public void DeleteChocobo(Chocobo chocobo);
    }
}