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
    public class UniteGestionRepository : IUniteGestionRepository
    {
        readonly IUniteGestionAdapter uniteGestionAdapter;
        public UniteGestionRepository(IUniteGestionAdapter _uniteGestionAdapter)
        {
            uniteGestionAdapter = _uniteGestionAdapter;
        }

        public bool CreateUniteGestion(UniteGestion uniteGestion)
        {
            // traitement
            return uniteGestionAdapter.CreateUniteGestion(uniteGestion);
        }

        public UniteGestion GetUniteGestionById(int id)
        {
            return uniteGestionAdapter.GetUniteGestionById(id);
        }

        public List<UniteGestion> GetUniteGestions()
        {
            List<UniteGestion> uniteGestions = uniteGestionAdapter.GetUniteGestions();
            return uniteGestions;
        }

        public bool UpdatedUniteGestion(UniteGestion uniteGestion)
        {
            return uniteGestionAdapter.UpdateUniteGestion(uniteGestion);
        }

        public bool UpdateUniteGestion(UniteGestion uniteGestion)
        {
            throw new NotImplementedException();
        }
        public byte[] GenerateUniteGestionReport(string reportEmbeddedResource, ReportDataSource reportDataSource)
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

        // Static reports implementation (tous les Unités gestion)
        public byte[] StaticReports()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.UniteGestionReport.UniteGestionStaticReports.rdlc";
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

        // Static report implementaion (une seule UnitéGestion)
        public byte[] StaticReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.RDLC.UniteGestionReport.UniteGestionStaticReport.rdlc";
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


        // Dynamic reports (tous les UnitésGestion)
        public byte[] DynamicReports(List<UniteGestionReport> uniteGestionReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.UniteGestionReport.UniteGestionDynamicReports.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("UniteGestionDataSet", uniteGestionReports);

                return GenerateUniteGestionReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }
        }
        // Dynamic report implementaion (une seule unité de gestion)

        public byte[] DynamicReport(UniteGestionReport uniteGestionReport)
        {
            try
            {
                List<UniteGestionReport> uniteGestionReports = new List<UniteGestionReport>();
                uniteGestionReports.Add(uniteGestionReport);

                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.UniteGestionReport.UniteGestionDynamicReports.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("UniteGestionDataSet", uniteGestionReports);

                return GenerateUniteGestionReport(reportEmbeddedResource, reportDataSource);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

