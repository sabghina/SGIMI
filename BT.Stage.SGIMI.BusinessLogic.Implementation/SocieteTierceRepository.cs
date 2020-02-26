﻿using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Commun.Tools;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Implementation;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
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
        public SocieteTierce GetSocieteTierceById(int id)
        {
            return societeTierceAdapter.GetSocieteTierceById(id);
        }

        public List<SocieteTierce> GetSocieteTierces()
        {
            List<SocieteTierce> societeTierces = societeTierceAdapter.GetSocieteTierces();
            return societeTierces;
        }
    }
}