using System;
using MediatR;

namespace Tienda.SharedKernel.Core
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
    }
}