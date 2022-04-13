using CommandQuery;
using Microsoft.AspNetCore.Mvc;
using Recruitment.API.Cryptography;
using Recruitment.Contracts;
using Recruitment.Contracts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.API.Controllers
{
    [Route("hash")]
    public class CommandQueryController : ICommandHandler<CalculateHashCommand, HashedResult>
    {
        [HttpPost("generate")]
        public Task<HashedResult> HandleAsync(CalculateHashCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command), "Command to process can not be null");
            }

            string cryptoResult = CryptoHelper.ComputeSha256Hash(command);
            HashedResult hashedResult = new HashedResult() { Result = cryptoResult };
            return Task.FromResult(hashedResult);
        }
    }
}
