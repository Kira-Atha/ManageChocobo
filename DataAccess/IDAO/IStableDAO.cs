using ChocoboManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoboManagement.DataAccess.IDAO {
    public interface IStableDAO {
        public List<Stable> GetStables();
        public List<Stable> GetStableByTrainerId(int trainerId);
        public void ModifyStable(Stable stable);
        public void AddStable(Stable stable);
        public void DeleteStable(Stable stable);
    }
}
