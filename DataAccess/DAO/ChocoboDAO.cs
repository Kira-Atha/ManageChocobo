using ChocoboManagement.DataAccess.IDAO;
using ChocoboManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoboManagement.DataAccess.DAO {
    class ChocoboDAO : IChocoboDAO {
       
        public  List<Chocobo> GetChocobos() {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                return context.Chocobos.ToList();
            }
        }

        public  List<Chocobo> GetStableChocobosByStableId(int stableId) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                return context.Chocobos.Where(q => q.StableId == stableId).ToList();
            }
        }
        public  List<Chocobo> GetChocobosAvailables() {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                return context.Chocobos.Where(q => q.StableId == null).ToList();
            }
        }
        public void ModifyChocobo(Chocobo chocobo) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Chocobos.Update(chocobo);
                context.SaveChanges();
            }
        }
        public void AddStableChocobo(Chocobo chocobo) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Chocobos.Update(chocobo);
                context.SaveChanges();
            }
        }
        public void AddChocobo(Chocobo chocobo) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Chocobos.Add(chocobo);
                context.SaveChanges();
            }
        }
        public void DeleteChocobo(Chocobo chocobo) {
            using (ChocoboManagementJet2Context context = new ChocoboManagementJet2Context()) {
                context.Chocobos.Remove(chocobo);
                context.SaveChanges();
            }
        }
    }
}
