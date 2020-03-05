﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class InterventionViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Etat { get; set; }
        public int Reclamation { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
