using System;

namespace DiplomaProject.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id, string entityType) : base($"Entity {entityType} with id {id} not found")
        {
        }
    }
}