using ChocoboManagement.DataAccess.IDAO;
using ChocoboManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoboManagement.DataAccess.DAO {
    class TrainerDAO : ITrainerDAO {
        public void AddTrainer(Trainer trainer) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Trainers.Add(trainer);
                context.SaveChanges();
            }
        }
        public void DeleteTrainer(Trainer trainer) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Trainers.Remove(trainer);
                context.SaveChanges();
            }
        }
        public List<Trainer> GetTrainers() {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                return context.Trainers.ToList();
            }
        }
        public void ModifyTrainer(Trainer trainer) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Trainers.Update(trainer);
                context.SaveChanges();
            }
        }
    }
}
