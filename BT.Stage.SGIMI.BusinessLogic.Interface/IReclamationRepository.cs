﻿using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IReclamationRepository
    {
        /// <summary>
        /// Returns List Reclamations.
        /// </summary>
        /// <returns></returns>
        List<Reclamation> GetReclamations();
        /// <summary>
        /// Returns reclamation by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Reclamation GetReclamationById(int id);
        bool CreateReclamation(Reclamation reclamation);
        bool UpdatedReclamation(Reclamation reclamation);
        byte[] StaticReports();
        byte[] StaticReport();
        byte[] DynamicReportsCanceled(List<ReclamationReport> reclamationReports);
        byte[] DynamicReportsFinished(List<ReclamationReport> reclamationReports);
        byte[] DynamicReportsOnHold(List<ReclamationReport> reclamationReports);
        byte[] DynamicReportsInProgress(List<ReclamationReport> reclamationReports);
        byte[] UserDynamicReportsCanceled(List<ReclamationReport> reclamationReports);
        byte[] UserDynamicReportsFinished(List<ReclamationReport> reclamationReports);
        byte[] UserDynamicReportsOnHold(List<ReclamationReport> reclamationReports);
        byte[] UserDynamicReportsInProgress(List<ReclamationReport> reclamationReports);
        byte[] DynamicReport(ReclamationReport reclamationReport);
        bool ChangeReclamation(Reclamation reclamationById);
        bool CanceledReclamation(Reclamation reclamation);
        List<Reclamation> GetFinishedReclamations();
        List<Reclamation> GetCanceledReclamations();
        List<Reclamation> GetUserCanceledReclamations(string currentUser);
        List<Reclamation> GetInProgressReclamations();
        List<Reclamation> GetUserReclamations(string currentUser);
        List<Reclamation> GetUserFinishedReclamations(string currentUser);
        List<Reclamation> GetUserInProgressReclamations(string currentUser);
    }
}
