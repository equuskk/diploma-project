﻿using System.Collections.Generic;

namespace DiplomaProject.Domain.Entities
{
    public class Sector
    {
        public int Id { get; set; }

        //TODO: широта, долгота ??
        public float Square { get; }

        public int LitoralId { get; }

        public virtual Litoral Litoral { get; set; }
        public virtual ICollection<Bioresource> Bioresources { get; set; }
        public virtual ICollection<ExpeditionSector> Expeditions { get; set; }

        public Sector(float square, int litoralId)
        {
            Square = square;
            LitoralId = litoralId;
        }

        private Sector()
        {
        }
    }
}