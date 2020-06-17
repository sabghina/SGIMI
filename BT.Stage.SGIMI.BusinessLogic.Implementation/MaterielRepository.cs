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
    public class MaterielRepository : IMaterielRepository
    {
        readonly IMaterielAdapter materielAdapter;
        public MaterielRepository(IMaterielAdapter _materielAdapter)
        {
            materielAdapter = _materielAdapter;
        }
        public Materiel GetMaterielById(int id)
        {
            return materielAdapter.GetMaterielById(id);
        }

        public List<Materiel> GetMateriels()
        {
            List<Materiel> materiels = materielAdapter.GetMateriels();
            return materiels;
        }

        public bool UpdatedMateriel(Materiel materiel)
        {
            return materielAdapter.UpdateMateriel(materiel);
        }

        bool IMaterielRepository.CreateMateriel(Materiel materiel)
        {
            return materielAdapter.CreateMateriel(materiel);
        }

        // Static reports implementation (tous les materiels)
        public byte[] StaticReports()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.MaterielReport.MaterielStaticReports.rdlc";
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

        // Static report implementaion (un seul materiel)
        public byte[] StaticReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.MaterielReport.MaterielStaticReport.rdlc";
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


        // Dynamic reports (tous les materiels)
        public byte[] DynamicReports(List<MaterielReport> materielReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.MaterielReport.MaterielDynamicReports.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("MaterielDataSet", materielReports);

                return GenerateMaterielReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }
           
        }
        // Dynamic report implementaion (un seul fournisseur)
        public byte[] DynamicReport(MaterielReport materielReport)
        {
            try
            {
                List<MaterielReport> materielReports = new List<MaterielReport>();
                materielReports.Add(materielReport);

                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.MaterielReport.MaterielDynamicReport.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("MaterielDataSet", materielReports);

                return GenerateMaterielReport(reportEmbeddedResource, reportDataSource);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] GenerateMaterielReport(string reportEmbeddedResource, ReportDataSource reportDataSource)
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

        public bool AffecterMateriel(Materiel materiel)
        {
            return materielAdapter.AffecterMateriel(materiel);
        }

        public string GetReferenceMaterielById(int id)
        {
            return materielAdapter.GetReferenceMaterielById(id);
        }

        public List<Materiel> GetAffectedMateriels()
        {
            List<Materiel> affectedMateriels = materielAdapter.GetAffectedMateriels();
            return affectedMateriels;
        }

        public bool RevokeMateriel(Materiel materiel)
        {
            return materielAdapter.RevokeMateriel(materiel);
        }

        public bool ArchivedMateriel(Materiel materiel)
        {
            return materielAdapter.ArchivedMateriel(materiel);
        }

        public List<Materiel> GetArchivedMateriels()
        {
            List<Materiel> archivedMateriels = materielAdapter.GetArchivedMateriels();
            return archivedMateriels;
        }

        public List<Materiel> GetComplainedMateriels()
        {
            List<Materiel> complainedMateriels = materielAdapter.GetComplainedMateriels();
            return complainedMateriels;
        }

        public bool ChangeMateriel(Materiel materielEtat)
        {
            return materielAdapter.ChangedMateriel(materielEtat);
        }

        public List<Materiel> GetUserMateriels(string currentUser)
        {
            List<Materiel> userMateriels = materielAdapter.GetUserMateriels(currentUser);
            return userMateriels;
        }

        public List<Materiel> GetComplainedUserMateriels(string currentUser)
        {
            List<Materiel> complainedUserMateriels = materielAdapter.GetComplainedUserMateriels(currentUser);
            return complainedUserMateriels;
        }
    }
}

