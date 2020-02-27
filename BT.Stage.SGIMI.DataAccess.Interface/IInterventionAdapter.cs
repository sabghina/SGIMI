﻿using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IInterventionAdapter
    {
         
        /// <summary>
        /// Returns List Interventions.
        /// </summary>
        /// <returns></returns>
        List<Intervention> GetInterventions();
        /// <summary>
        /// Returns Intervention by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Intervention GetInterventionById(int id);
    }
}
    