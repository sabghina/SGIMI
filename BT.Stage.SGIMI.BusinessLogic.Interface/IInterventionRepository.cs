using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IInterventionRepository
    {
        /// <summary>
        /// Returns List Interventions.
        /// </summary>
        /// <returns></returns>
        List<Intervention> GetInterventions();
        /// <summary>
        /// Returns Intervention by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Intervention GetInterventionById(int id);
        bool CreateIntervention(Intervention intervention);
        bool UpdatedIntervention(Intervention intervention);


        byte[] StaticReports();
        byte[] StaticReport();

        byte[] DynamicReports(List<InterventionReport> interventionlReports);
        byte[] DynamicReport(InterventionReport interventionReport);
        List<Intervention> GetFinishedInterventions();
        List<Intervention> GetCanceledInterventions();
        bool FinishedIntervention(Intervention intervention);
        bool CanceledIntervention(Intervention intervention);
    }
    }
