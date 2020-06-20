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
    public class InterventionRepository : IInterventionRepository
    {
        readonly IInterventionAdapter interventionAdapter;
        public InterventionRepository(IInterventionAdapter _interventionAdapter)
        {
            interventionAdapter = _interventionAdapter;
        }
        public bool CreateIntervention(Intervention intervention)
        {
            // traitement
            return interventionAdapter.CreateIntervention(intervention);
        }
        public Intervention GetInterventionById(int id)
        {
            return interventionAdapter.GetInterventionById(id);
        }

        public List<Intervention> GetInterventions()
        {
            List<Intervention> interventions = interventionAdapter.GetInterventions();
            return interventions;
        }
        public List<Intervention> GetFinishedInterventions()
        {
            List<Intervention> interventions = interventionAdapter.GetFinishedInterventions();
            return interventions;
        }
        public List<Intervention> GetCanceledInterventions()
        {
            List<Intervention> interventions = interventionAdapter.GetCanceledInterventions();
            return interventions;
        }
        public bool UpdatedIntervention(Intervention intervention)
        {
            return interventionAdapter.UpdateIntervention(intervention);
        }
        public bool FinishedIntervention(Intervention intervention)
        {
            return interventionAdapter.FinishedIntervention(intervention);
        }

        public bool CanceledIntervention(Intervention intervention)
        {
            return interventionAdapter.CanceledIntervention(intervention);
        }
        // Static reports implementation (tous les interventions)
        public byte[] StaticReports()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.InterventionReport.InterventionStaticReports.rdlc";
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

        // Static report implementaion (une seule intervention)
        public byte[] StaticReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.InterventionReport.InterventionStaticReport.rdlc";
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
        // Dynamic reports (tous les interventions)
        public byte[] DynamicReports(List<InterventionReport> interventionReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.InterventionReport.InterventionDynamicReports.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("InterventionDataSet", interventionReports);

                return GenerateInterventionReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }
        }
        // Dynamic reports (tous les interventions)
        public byte[] DynamicReportsInProgress(List<InterventionReport> interventionReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.InterventionReport.InterventionDynamicReportsInProgress.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("InterventionDataSet", interventionReports);

                return GenerateInterventionReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }
        }

        // Dynamic report implementaion (une seule intervention)
        public byte[] DynamicReport(InterventionReport interventionReport)
        {
            try
            {
                List<InterventionReport> interventionReports = new List<InterventionReport>();
                interventionReports.Add(interventionReport);

                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.InterventionReport.InterventionDynamicReport.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("InterventionDataSet", interventionReports);

                return GenerateInterventionReport(reportEmbeddedResource, reportDataSource);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] GenerateInterventionReport(string reportEmbeddedResource, ReportDataSource reportDataSource)
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

        
    }
}

