using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Implementation
{
    public class ReclamationRepository : IReclamationRepository
    {
        readonly IReclamationAdapter reclamationAdapter;
        public ReclamationRepository(IReclamationAdapter _reclamationAdapter)
        {
            reclamationAdapter = _reclamationAdapter;
        }

        public bool CreateReclamation(Reclamation reclamation)
        {
            return reclamationAdapter.CreateReclamation(reclamation);
        }

        public Reclamation GetReclamationById(int id)
        {
            return reclamationAdapter.GetReclamationById(id);
        }

        public List<Reclamation> GetReclamations()
        {
            List<Reclamation> reclamations = reclamationAdapter.GetReclamations();
            return reclamations;
        }

        public List<Reclamation> GetUserReclamations(string currentUser)
        {
            List<Reclamation> userReclamations = reclamationAdapter.GetUserReclamations(currentUser);
            return userReclamations;
        }
        public List<Reclamation> GetInProgressReclamations()
        {
            List<Reclamation> reclamations = reclamationAdapter.GetInProgressReclamations();
            return reclamations;
        }
        public List<Reclamation> GetUserInProgressReclamations(string currentUser)
        {
            List<Reclamation> userReclamations = reclamationAdapter.GetUserInProgressReclamations(currentUser);
            return userReclamations;
        }
        public List<Reclamation> GetFinishedReclamations()
        {
            List<Reclamation> reclamations = reclamationAdapter.GetFinishedReclamations();
            return reclamations;
        }

        public List<Reclamation> GetUserFinishedReclamations(string currentUser)
        {
            List<Reclamation> userReclamations = reclamationAdapter.GetUserFinishedReclamations(currentUser);
            return userReclamations;
        }

        public List<Reclamation> GetCanceledReclamations()
        {
            List<Reclamation> reclamations = reclamationAdapter.GetCanceledReclamations();
            return reclamations;
        }

        public bool UpdatedReclamation(Reclamation reclamation)
        {
            return reclamationAdapter.UpdateReclamation(reclamation);
        }

        // Static reports implementation (tous les reclamations)
        public byte[] StaticReports()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.ReclamationReport.ReclamationStaticReports.rdlc";
            localReport.DataSources.Clear();

            localReport.Refresh();

            ///Orientation Portrait
            ///Report properties -> Paper size: A4, Width: 21cm, Height: 29.7cm
            ///Report ruler width: 24
            string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>10in</PageWidth>" + "  <PageHeight>12in</PageHeight>" +
              "  <MarginTop>0.2in</MarginTop>" + "  <MarginLeft>0.2in</MarginLeft>" + "  <MarginRight>0.2in</MarginRight>" + "  <MarginBottom>0.2in</MarginBottom>" + "</DeviceInfo>";
            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;

            string[] streams;

            //Render the report
            byte[] file = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return file;
        }

        // Static report implementaion (une seul reclamation)
        public byte[] StaticReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.ReclamationReport.ReclamationStaticReport.rdlc";
            localReport.DataSources.Clear();

            localReport.Refresh();

            ///Orientation Portrait
            ///Report properties -> Paper size: A4, Width: 21cm, Height: 29.7cm
            ///Report ruler width: 24
            string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>10in</PageWidth>" + "  <PageHeight>12in</PageHeight>" +
              "  <MarginTop>0.2in</MarginTop>" + "  <MarginLeft>0.2in</MarginLeft>" + "  <MarginRight>0.2in</MarginRight>" + "  <MarginBottom>0.2in</MarginBottom>" + "</DeviceInfo>";
            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;

            string[] streams;

            //Render the report
            byte[] file = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return file;
        }
        private byte[] GenerateReclamationReport(string reportEmbeddedResource, ReportDataSource reportDataSource)
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = reportEmbeddedResource;
            localReport.DataSources.Clear();

            localReport.DataSources.Add(reportDataSource);

            localReport.Refresh();

            ///Orientation Portrait
            ///Report properties -> Paper size: A4, Width: 21cm, Height: 29.7cm
            ///Report ruler width: 24
            string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>10in</PageWidth>" + "  <PageHeight>12in</PageHeight>" +
              "  <MarginTop>0.2in</MarginTop>" + "  <MarginLeft>0.2in</MarginLeft>" + "  <MarginRight>0.2in</MarginRight>" + "  <MarginBottom>0.2in</MarginBottom>" + "</DeviceInfo>";
            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            Warning[] warnings;

            string[] streams;

            //Render the report
            byte[] file = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return file;
        }
        // Dynamic reports (tous les reclamations)
        public byte[] DynamicReports(List<ReclamationReport> reclamationReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.ReclamationReport.ReclamationDynamicReports.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("ReclamationDataSet", reclamationReports);

                return GenerateReclamationReport(reportEmbeddedResource, reportDataSource);
                
            }
            catch (Exception)
            {
                throw;
            }
        }
        // Dynamic report implementaion (une seule reclamation)
        public byte[] DynamicReport(ReclamationReport reclamationReport)
        {
            try
            {
                List<ReclamationReport> reclamationReports = new List<ReclamationReport>();
                reclamationReports.Add(reclamationReport);

                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.ReclamationReport.ReclamationDynamicReport.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("ReclamationDataSet", reclamationReports);
                return GenerateReclamationReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangeReclamation(Reclamation reclamationById)
        {
            return reclamationAdapter.ChangeReclamation(reclamationById);
        }

        public bool CanceledReclamation(Reclamation reclamation)
        {
            return reclamationAdapter.CancelReclamation(reclamation);
        }

        
    }
}

