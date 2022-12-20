using MyHistory.Domain.Entities;

namespace MyHistory.Application.Services.Authentication
{

    public record AuthenticationResult(
       User user,
        string Token);
}
