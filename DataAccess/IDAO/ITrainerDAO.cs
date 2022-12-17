using ChocoboManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoboManagement.DataAccess.IDAO {
    public interface ITrainerDAO {
        public List<Trainer> GetTrainers();
        public void AddTrainer(Trainer trainer);
        public void ModifyTrainer(Trainer trainer);
        public void DeleteTrainer(Trainer trainer);
    }
}
