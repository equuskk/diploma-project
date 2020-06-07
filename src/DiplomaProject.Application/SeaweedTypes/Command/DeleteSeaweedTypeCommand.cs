﻿using System.Threading;
using System.Threading.Tasks;
using DiplomaProject.DataAccess;
using DiplomaProject.Domain.Entities;
using DiplomaProject.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Application.SeaweedTypes.Command
{
    public class DeleteSeaweedTypeCommandHandler : IRequestHandler<DeleteSeaweedTypeCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteSeaweedTypeCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSeaweedTypeCommand request, CancellationToken cancellationToken)
        {
            var item = await _context.SeaweedTypes.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(item is null)
            {
                throw new NotFoundException(request.Id, nameof(SeaweedType));
            }

            _context.Remove(item);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

    public class DeleteSeaweedTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}