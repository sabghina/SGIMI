﻿using BT.Stage.SGIMI.Data.Entity;
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
    }
}