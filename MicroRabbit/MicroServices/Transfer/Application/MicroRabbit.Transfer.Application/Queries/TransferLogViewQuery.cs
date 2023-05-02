using System.Collections.Generic;
using MediatR;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Transfer.Application.Models;

namespace MicroRabbit.Banking.Application.Queries
{
    public class TransferLogViewQuery : IRequest<List<TransferLogViewModel>>
    {
    }
}