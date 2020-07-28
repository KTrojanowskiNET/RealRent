using MimeKit;
using MailKit.Net.Smtp;
using Xunit;
using FluentAssertions;

using RentModel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions.Common;
using Moq;
using RealRent.Models;

namespace RealRent.Test
{
    public class MessageServiceTests
    {
        [Fact]
        public void UserMessageService_ShouldInvoke()
        {
            //Arrange
            var testMessage = new UserMessage
            {
                SenderName = "SenderName",
                RecieverName = "RecieverName",
                SenderEmail = "SenderEmail",
                RecieverEmail = "RecieverEmail",
                Subject = "Subject",
                Text = "TestMessage"
            };

            var testMessageService = new  Mock<IMessageService>();
           
            var testClass = new TestMessage(testMessageService.Object);

            //Act

            testClass.SendMessage(testMessage);

            //Assert

            testMessageService.Verify(ms => ms.MessageToUser(testMessage), Times.AtLeastOnce);
            
            

            
            
           
        }

    }
}
