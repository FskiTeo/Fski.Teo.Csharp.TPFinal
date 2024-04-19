using Fiminski.RG.DAL.DAL;
using Fiminski.RG.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fiminski.RG.DAL.Service
{
    public class EspionnageService : IEspionnageService
    {
        private IApplicationDBContext _applicationDBContext;

        public EspionnageService(IApplicationDBContext applicationDBContext)
        {
            this._applicationDBContext = applicationDBContext;
        }

        public Espion AddEspion(string nom, string code)
        {
            return this._applicationDBContext.AddEspion(nom, code);
        }

        public Mission AddMission(string lieu, int year)
        {
            return this._applicationDBContext.AddMission(lieu, year);
        }

        public void AssignEspionToMission(int espionId, int missionId)
        {
            this.AssignEspionToMission(espionId, missionId);
        }

        public void DeleteEspion(int espionId)
        {
            this._applicationDBContext.DeleteEspion(espionId);
        }

        public void DeleteMission(int missionId)
        {
            this._applicationDBContext.DeleteMission(missionId);
        }

        public void EditEspion(int espionId, Espion espionModified)
        {
            this._applicationDBContext.EditEspion(espionId, espionModified);
        }

        public List<Espion> GetAllEspions()
        {
            return this._applicationDBContext.GetAllEspions();
        }

        public List<Mission> GetAllMissions()
        {
            return this._applicationDBContext.GetAllMissions();
        }

        public Espion GetEspion(int id)
        {
            return this._applicationDBContext.GetEspion(id);
        }

        public List<Espion> GetEspionsByVille(string ville)
        {
            return _applicationDBContext.GetEspionsByVille(ville);
        }

        public Mission GetMission(int id)
        {
            return this._applicationDBContext.GetMission(id);
        }
    }
}
