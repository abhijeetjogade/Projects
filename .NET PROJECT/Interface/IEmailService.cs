using MedLab.DTO;

namespace MedLab.Interface
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
