﻿using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IFournisseurAdapter
    {
        /// <summary>
        /// Returns List Fournissuers.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetFournisseurs();
        /// <summary>
        /// Return fournisseur by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Fournisseur GetFournisseurById(int id);
    }
}