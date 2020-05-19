﻿using System.Collections.Generic;

namespace DiplomaProject.Domain.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        //TODO: широта, долгота ??
        public float Square { get; set; }

        public int LitoralId { get; set; }

        public virtual Litoral Litoral { get; set; }
        public virtual ICollection<Bioresource> Bioresources { get; set; }
        public virtual ICollection<ExpeditionSector> Expeditions { get; set; }
    }
}