﻿namespace DiplomaProject.Domain.Entities
{
    public class Seaweed
    {
        public int Id { get; private set; }
        public float AvgWeight { get; set; }

        public int SeaweedTypeId { get; set; }
        public int SeaweedCategoryId { get; set; }

        public virtual SeaweedType Type { get; set; }
        public virtual SeaweedCategory Category { get; set; }
    }
}