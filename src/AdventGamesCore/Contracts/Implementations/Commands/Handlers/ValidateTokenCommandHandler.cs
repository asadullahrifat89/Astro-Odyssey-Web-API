﻿using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventGamesCore
{
    public class ValidateTokenCommandHandler : IRequestHandler<ValidateTokenCommand, ServiceResponse>
    {
        #region Fields

        private readonly ILogger<ValidateTokenCommandHandler> _logger;
        private readonly ValidateTokenCommandValidator _validator;
        private readonly IAuthTokenRepository _repository;

        #endregion

        #region Ctor

        public ValidateTokenCommandHandler(
            ILogger<ValidateTokenCommandHandler> logger,
            ValidateTokenCommandValidator validator,
            IAuthTokenRepository repository)
        {
            _logger = logger;
            _validator = validator;
            _repository = repository;
        }

        #endregion

        #region Methods

        public async Task<ServiceResponse> Handle(ValidateTokenCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = await _validator.ValidateAsync(command, cancellationToken);
                validationResult.EnsureValidResult();

                var response = await _repository.ValidateToken(command);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Response.Build().BuildErrorResponse(ex.Message);
            }
        }

        #endregion
    }
}
