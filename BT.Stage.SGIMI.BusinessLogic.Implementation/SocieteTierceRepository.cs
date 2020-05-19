using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Commun.Tools;
using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Implementation
{
    public class SocieteTierceRepository : ISocieteTierceRepository
    {
        readonly ISocieteTierceAdapter societeTierceAdapter;
        public SocieteTierceRepository(ISocieteTierceAdapter _societeTierceAdapter)
        {
            societeTierceAdapter = _societeTierceAdapter;

        }

        public bool CreateSocieteTierce(Fournisseur societeTierce)
        {
            return societeTierceAdapter.CreateSocieteTierce(societeTierce);
        }

        public Fournisseur GetSocieteTierceById(int id)
        {
            return societeTierceAdapter.GetSocieteTierceById(id);
        }

        public List<Fournisseur> GetSocieteTierces()
        {
            List<Fournisseur> societeTierces = societeTierceAdapter.GetSocieteTierces();
            return societeTierces;
        }

        public bool UpdatedSocieteTierce(Fournisseur societeTierce)
        {
            return societeTierceAdapter.UpdateSocieteTierce(societeTierce);
        }

        // Static reports implementation (tous les societés tierces)
        public byte[] StaticReports()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.SocieteTierceReport.SocieteTierceStaticReports.rdlc";
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


        // Static report implementaion (un seule société tierce)
        public byte[] StaticReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.SocieteTierceReport.SocieteTierceStaticReport.rdlc";
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

        // Dynamic reports (tous les societés tierces)
        public byte[] DynamicReports(List<SocieteTierceReport> societeTierceReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.SocieteTierceReport.SocieteTierceDynamicReports.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("SocieteTierceDataSet", societeTierceReports);

                return GenerateSocieteTierceReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }

        }

        public byte[] DynamicReport(SocieteTierceReport societeTierceReport)
        {
            try
            {
                List<SocieteTierceReport> societeTierceReports = new List<SocieteTierceReport>();
                societeTierceReports.Add(societeTierceReport);

                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.SocieteTierceReport.SocieteTierceDynamicReport.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("SocieteTierceDataSet", societeTierceReports);
                return GenerateSocieteTierceReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            };
        }

        private byte[] GenerateSocieteTierceReport(string reportEmbeddedResource, ReportDataSource reportDataSource)
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

    



