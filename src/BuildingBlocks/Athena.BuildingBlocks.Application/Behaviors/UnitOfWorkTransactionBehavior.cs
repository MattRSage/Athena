using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Athena.BuildingBlocks.Application.Behaviors
{
    public class UnitOfWorkTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkTransactionBehavior(
            ILogger<TRequest> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var name = typeof(TRequest).Name;


            var transactionId = await _unitOfWork.BeginTransaction();
            _logger.LogInformation($"Begin Transaction: {name} {request} {transactionId}");


            var response = await next();

            _logger.LogInformation($"Completing Transaction: {name} {request} {transactionId}");
            await _unitOfWork.Complete(cancellationToken);
            _logger.LogInformation($"Completed Transaction: {name} {request} {transactionId}");

            return response;
        }
    }
}
