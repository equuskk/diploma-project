using System;

namespace DiplomaProject.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(int id, string entityType) : base($"Сущность {entityType} с идентификатором {id} не найдена")
        {
        }
    }
}