using ChocoboManagement.DataAccess.IDAO;
using ChocoboManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoboManagement.DataAccess.DAO {
    class TrainerStableDAO : ITrainerStableDAO {
        public void AddTrainerStable(TrainerStable trainerStable) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.TrainerStables.Add(trainerStable);
                context.SaveChanges();
            }
        }
    }
}