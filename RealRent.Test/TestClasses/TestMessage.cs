
using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealRent.Models
{
    public class TestMessage
    {
        private readonly IMessageService messageService;

        public TestMessage(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public void SendMessage(UserMessage userMessage)
        {
            messageService.MessageToUser(userMessage);
        }

       
    }
}
