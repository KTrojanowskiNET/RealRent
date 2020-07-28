using RentModel.Models;

namespace RealRent
{
    public interface IMessageService
    {
        void MessageToCustomerService(ServiceMessage model);
        void MessageToUser(UserMessage model);
        
    }
}