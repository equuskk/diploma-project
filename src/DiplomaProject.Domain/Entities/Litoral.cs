﻿namespace DiplomaProject.Domain.Entities
{
    public class Litoral
    {
        public int Id { get; private set; }
        public string Title { get; set; }

        public Litoral(string title)
        {
            Title = title;
        }

        private Litoral()
        {
        }
    }
}