﻿using BT.Stage.SGIMI.BusinessLogic.Interface;
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
    public class FournisseurRepository : IFournisseurRepository
    {
        readonly IFournisseurAdapter fournisseurAdapter;
        public FournisseurRepository(IFournisseurAdapter _fournisseurAdapter)
        {
            fournisseurAdapter = _fournisseurAdapter;
        }

        public bool CreateFournisseur(Fournisseur fournisseur)
        {
            // traitement
            return fournisseurAdapter.CreateFournisseur(fournisseur);
        }

        public Fournisseur GetFournisseurById(int id)
        {
            return fournisseurAdapter.GetFournisseurById(id);
        }

        public string GetNameFournisseurById(int id)
        {
            return fournisseurAdapter.GetNameFournisseurById(id);
        }
        public List<Fournisseur> GetFournisseursActive()
        {
            List<Fournisseur> fournisseurs = fournisseurAdapter.GetFournisseursActive();
            return fournisseurs;
        }

        
        public bool UpdatedFournisseur(Fournisseur fournisseur)
        {
            return fournisseurAdapter.UpdateFournisseur(fournisseur);
        }


        // Static reports implementation (tous les fournisseurs)
        public byte[] StaticReports()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.FournisseurReport.FournisseurStaticReports.rdlc";
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

        // Static report implementaion (un seul fournisseur)
        public byte[] StaticReport()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.FournisseurReport.FournisseurStaticReport.rdlc";
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


        // Dynamic reports (tous les fournisseurs)
        public byte[] DynamicReports(List<FournisseurReport> fournisseurReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.FournisseurReport.FournisseurDynamicReports.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("FournisseurDataSet", fournisseurReports);

                return GenerateFournisseurReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }
        }
        // Dynamic reportsArchived (tous les fournisseurs)
        public byte[] DynamicReportsArchived(List<FournisseurReport> fournisseurReports)
        {
            try
            {
                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.FournisseurReport.FournisseurDynamicReportsArchived.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("FournisseurDataSet", fournisseurReports);

                return GenerateFournisseurReport(reportEmbeddedResource, reportDataSource);

            }
            catch (Exception)
            {
                throw;
            }
        }
        // Dynamic report implementaion (un seul fournisseur)
        public byte[] DynamicReport(FournisseurReport fournisseurReport)
        {
            try
            {
                List<FournisseurReport> fournisseurReports = new List<FournisseurReport>();
                fournisseurReports.Add(fournisseurReport);

                string reportEmbeddedResource = "BT.Stage.SGIMI.BusinessLogic.Implementation.Reporting.RDLC.FournisseurReport.FournisseurDynamicReport.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource("FournisseurDataSet", fournisseurReports);

                return GenerateFournisseurReport(reportEmbeddedResource, reportDataSource);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte[] GenerateFournisseurReport(string reportEmbeddedResource, ReportDataSource reportDataSource)
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

        public bool ArchivedFournisseur(Fournisseur fournisseur)
        {
            return fournisseurAdapter.ArchiveFournisseur(fournisseur);
        }

        public bool ActivatedFournisseur(Fournisseur fournisseur)
        {
            return fournisseurAdapter.ActiveFournisseur(fournisseur);
        }


        public List<Fournisseur> GetArchivedFournisseurs()
        {
            List<Fournisseur> archivedFournisseurs = fournisseurAdapter.GetArchivedFournisseurs();
            return archivedFournisseurs;
        }

    }
}
