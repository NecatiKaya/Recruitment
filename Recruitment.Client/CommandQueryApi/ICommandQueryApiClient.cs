using Recruitment.Client.CommandQueryApi.Requests;
using Recruitment.Client.CommandQueryApi.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Recruitment.Client.CommandQueryApi
{
    public interface ICommandQueryApiClient
    {
        Task<HashedResult> GenerateHashAsync(CalculateHashRequest request, CancellationToken cancellationToken = default);
    }
}
