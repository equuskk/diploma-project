using System;
using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using MediatR;

namespace DiplomaProject.Application.Expeditions.Commands
{
    public class CreateExpeditionCommandHandler : IRequestHandler<CreateExpeditionCommand, Expedition>
    {
        private readonly ApplicationDbContext _context;

        public CreateExpeditionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Expedition> Handle(CreateExpeditionCommand request, CancellationToken cancellationToken)
        {
            if(request.FromDate > request.ToDate)
            {
                throw new ArgumentException("Дата окончания экспедиции меньше даты начала");
            }

            var expedition = new Expedition
            {
                FromDate = request.FromDate,
                ToDate = request.ToDate
            };

            await _context.Expeditions.AddAsync(expedition, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return expedition;
        }
    }

    public class CreateExpeditionCommand : IRequest<Expedition>
    {
        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }
    }
}