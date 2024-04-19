using Fiminski.RG.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Fiminski.RG.DAL.DAL
{
    public interface IApplicationDBContext
    {
        DbSet<Espion> espion { get; set; }
        DbSet<Mission> mission { get; set; }

        List<Espion> GetAllEspions();

        Espion GetEspion(int id);

        Espion AddEspion(string nom, string code);

        void EditEspion(int espionId, Espion espionModified);

        void DeleteEspion(int espionId);

        List<Mission> GetAllMissions();

        Mission GetMission(int id);

        Mission AddMission(string lieu, int year);

        void DeleteMission(int missionId);

        void AssignEspionToMission(int espionId, int missionId);

        List<Espion> GetEspionsByVille(string ville);

    }
}