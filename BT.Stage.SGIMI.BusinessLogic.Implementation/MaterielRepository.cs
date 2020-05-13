﻿using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
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

        //// Static reports implementation (tous les materiels)
        //public byte[] StaticReports()
        //{
        //    LocalReport localReport = new LocalReport();
        //    localReport.ReportEmbeddedResource = "Demo.ReportingImplementation.BusinessLogic.Implementation.Reporting.RDLC.StaticReports.rdlc";
        //    localReport.DataSources.Clear();

        //    localReport.Refresh();

        //    ///Orientation Portrait
        //    ///Report properties -> Paper size: A4, Width: 21cm, Height: 29.7cm
        //    ///Report ruler width: 24
        //    string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>10in</PageWidth>" + "  <PageHeight>12in</PageHeight>" +
        //      "  <MarginTop>0.2in</MarginTop>" + "  <MarginLeft>0.2in</MarginLeft>" + "  <MarginRight>0.2in</MarginRight>" + "  <MarginBottom>0.2in</MarginBottom>" + "</DeviceInfo>";
        //    string reportType = "pdf";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    Warning[] warnings;

        //    string[] streams;

        //    //Render the report
        //    byte[] file = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        //    return file;
        //}

        //// Static report implementaion (un seul materiel)
        //public byte[] StaticReport()
        //{
        //    LocalReport localReport = new LocalReport();
        //    localReport.ReportEmbeddedResource = "Demo.ReportingImplementation.BusinessLogic.Implementation.Reporting.RDLC.StaticReport.rdlc";
        //    localReport.DataSources.Clear();

        //    localReport.Refresh();

        //    ///Orientation Portrait
        //    ///Report properties -> Paper size: A4, Width: 21cm, Height: 29.7cm
        //    ///Report ruler width: 24
        //    string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>10in</PageWidth>" + "  <PageHeight>12in</PageHeight>" +
        //      "  <MarginTop>0.2in</MarginTop>" + "  <MarginLeft>0.2in</MarginLeft>" + "  <MarginRight>0.2in</MarginRight>" + "  <MarginBottom>0.2in</MarginBottom>" + "</DeviceInfo>";
        //    string reportType = "pdf";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;
        //    Warning[] warnings;

        //    string[] streams;

        //    //Render the report
        //    byte[] file = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        //    return file;
        //}


        //// Dynamic reports (tous les materiels)
        //public byte[] DynamicReports(List<EmployerReport> employerReports)
        //{
        //    try
        //    {
        //        LocalReport localReport = new LocalReport();
        //        localReport.ReportEmbeddedResource = "Demo.ReportingImplementation.BusinessLogic.Implementation.Reporting.RDLC.DynamicReports.rdlc";
        //        localReport.DataSources.Clear();

        //        localReport.DataSources.Add(new ReportDataSource("EmployerDataSet", employerReports));

        //        localReport.Refresh();

        //        ///Orientation Portrait
        //        ///Report properties -> Paper size: A4, Width: 21cm, Height: 29.7cm
        //        ///Report ruler width: 24
        //        string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>PDF</OutputFormat>" + "  <PageWidth>10in</PageWidth>" + "  <PageHeight>12in</PageHeight>" +
        //          "  <MarginTop>0.2in</MarginTop>" + "  <MarginLeft>0.2in</MarginLeft>" + "  <MarginRight>0.2in</MarginRight>" + "  <MarginBottom>0.2in</MarginBottom>" + "</DeviceInfo>";
        //        string reportType = "pdf";
        //        string mimeType;
        //        string encoding;
        //        string fileNameExtension;
        //        Warning[] warnings;

        //        string[] streams;

        //        //Render the report
        //        byte[] file = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        //        return file;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw;
        //    }
        //}
    }
}

