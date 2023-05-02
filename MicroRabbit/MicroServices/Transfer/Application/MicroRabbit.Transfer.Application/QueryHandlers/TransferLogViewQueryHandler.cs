using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroRabbit.Banking.Application.Queries;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Models;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Banking.Application.QueryHandlers
{
    public class TransferLogViewQueryHandler : IRequestHandler<TransferLogViewQuery, List<TransferLogViewModel>>
    {
        private readonly ITransferLogRepository _transferLogRepository;
        private readonly IMapper _mapper;

        public TransferLogViewQueryHandler(ITransferLogRepository transferLogRepository, IMapper mapper)
        {
            _transferLogRepository = transferLogRepository;
            _mapper = mapper;
        }

        public async Task<List<TransferLogViewModel>> Handle(TransferLogViewQuery request, CancellationToken cancellationToken)
        {
            var transferLogList =  await _transferLogRepository.GetTransferLogs();
            var transferLogDto = _mapper.Map<List<TransferLog>, List<TransferLogViewModel>>(transferLogList);
            return transferLogDto;
        }
    }
}