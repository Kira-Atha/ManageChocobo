using ChocoboManagement.DataAccess.IDAO;
using ChocoboManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoboManagement.DataAccess.DAO {
    class StableDAO : IStableDAO {
        public void AddStable(Stable stable) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Stables.Add(stable);
                context.SaveChanges();
            }
        }

        public void DeleteStable(Stable stable) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Stables.Remove(stable);
                context.SaveChanges();
            }
        }

        public List<Stable> GetStableByTrainerId(int trainerId) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                return context.Stables.Include(q => q.TrainerStables)
                                        .Where(q => q.TrainerStables.Any(pq => pq.TrainerId == trainerId))
                                        .ToList();
            }
        }
        public List<Stable> GetStables() {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                return context.Stables.ToList();
            }
        }

        public void ModifyStable(Stable stable) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Stables.Update(stable);
                context.SaveChanges();
            }
        }
    }
}