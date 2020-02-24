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
    public class FournisseurRepository : IFournisseurRepository
    {
        readonly IFournisseurAdapter fournisseurAdapter;
        public FournisseurRepository(IFournisseurAdapter _fournisseurAdapter)
        {
            fournisseurAdapter = _fournisseurAdapter;
        }
        public List<Fournisseur> GetFournisseurs()
        {
            List<Fournisseur> fournisseurs = fournisseurAdapter.GetFournisseurs();
            return fournisseurs;
        }
    }
}
