﻿using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface ISocieteTierceAdapter
    {
        /// <summary>
        /// Returns List SocieteTierce.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetSocieteTierces();
        /// <summary>
        /// Returns Archived List SocieteTierce.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetArchivedSocieteTierces();
        /// <summary>
        /// Return SocieteTierce by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Fournisseur GetSocieteTierceById(int id);
        //bool GetSocieteTierceTypeById(int id);
        /// <summary>
        /// Create new SocieteTierce
        /// </summary>
        /// <param name="societeTierce"></param>
        /// <returns></returns>
        bool CreateSocieteTierce(Fournisseur societeTierce);
        bool UpdateSocieteTierce(Fournisseur societeTierce);
        bool ArchiveSocieteTierce(Fournisseur societeTierce);
        bool ActiveSocieteTierce(Fournisseur societeTierce);
    }
}


