using api.Models;

namespace api.Data
{
    public interface IMail
    {
        Mail SendMail(Mail msg);
    }
}