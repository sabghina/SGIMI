﻿using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IMaterielRepository
    {
        /// <summary>
        /// Returns List Materiels.
        /// </summary>
        /// <returns></returns>
        List<Materiel> GetMateriels();
        /// <summary>
        /// Returns materiel by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Materiel GetMaterielById(int id);
        string GetReferenceMaterielById(int id);
        /// <summary>
        /// Create new materiel.
        /// </summary>
        /// <param name="materiel"></param>
        /// <returns></returns> 
        bool CreateMateriel(Materiel materiel);
        bool UpdatedMateriel(Materiel materiel);
        bool AffecterMateriel(Materiel materiel);
        bool RevokeMateriel(Materiel materiel);
        byte[] StaticReports();
        byte[] StaticReport();

        byte[] DynamicReports(List<MaterielReport> materielReports);
        byte[] DynamicReport(MaterielReport materielReport);
        List<Materiel> GetAffectedMateriels();
        bool ArchivedMateriel(Materiel materiel);
        List<Materiel> GetArchivedMateriels();
    }
}
