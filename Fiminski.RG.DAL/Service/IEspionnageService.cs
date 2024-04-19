using Fiminski.RG.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiminski.RG.DAL.Service
{
    public interface IEspionnageService
    {
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
