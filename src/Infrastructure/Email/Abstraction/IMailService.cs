using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Email.Abstraction;

public interface IMailService
{
    Task SendEmailAsync(string body, string email, string subject = null, CancellationToken cancellationToken = default);
}