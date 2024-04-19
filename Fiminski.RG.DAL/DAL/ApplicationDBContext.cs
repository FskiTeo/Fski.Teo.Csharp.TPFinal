using Fiminski.RG.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Fiminski.RG.DAL.DAL
{
    public class ApplicationDBContext : DbContext, IApplicationDBContext
    {

        public DbSet<Espion> espion { get; set; }

        public DbSet<Mission> mission { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }

        public Espion AddEspion(string nom, string code)
        {
            Espion espionAjouter = new Espion(nom, code);
            Add(espionAjouter);
            SaveChanges();
            return espionAjouter;
        }

        public Mission AddMission(string lieu, int year)
        {
            Mission missionAjouter = new Mission(lieu: lieu, year: year);
            Add(missionAjouter);
            SaveChanges();
            return missionAjouter;
        }

        public void AssignEspionToMission(int espionId, int missionId)
        {
            Mission missionCherchee = GetMission(missionId);
            missionCherchee.EspionId = espionId;
            SaveChanges();
        }

        public void DeleteEspion(int espionId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMission(int missionId)
        {
            throw new NotImplementedException();
        }

        public void EditEspion(int espionId, Espion espionModified)
        {
            Espion espionCherche = GetEspion(espionId);
            espionCherche.Name = espionModified.Name;
            espionCherche.Code = espionModified.Code;
            SaveChanges(true);
        }

        public List<Espion> GetAllEspions()
        {
            return espion.ToList();
        }

        public List<Mission> GetAllMissions()
        {
            return mission.ToList();
        }

        public Espion GetEspion(int id)
        {
            return espion.Find(id);
        }

        public Mission GetMission(int id)
        {
            return mission.Find(id);
        }

        public List<Espion> GetEspionsByVille(string ville)
        {
            var espionsDansVille = from espion in espion
                                   join mission in mission on espion.EspionId equals mission.EspionId
                                   where mission.Lieu == ville
                                   select espion;

            return espionsDansVille.ToList();

        }
    }
}
