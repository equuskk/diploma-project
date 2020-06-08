using System;

namespace DiplomaProject.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(object id, string entityType) : base($"Сущность {entityType} с идентификатором {id} не найдена")
        {
        }
    }
}