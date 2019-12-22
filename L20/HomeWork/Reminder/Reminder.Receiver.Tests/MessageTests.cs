using NUnit.Framework;
using Reminder.Receiver.Telegram;
using System;

namespace Reminder.Receiver.Tests
{
    public class ReminderReceiverTests
    {
        [Test]
        public void WhenDeclare_IfArgumentTokenNullSpecified_ShouldThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                new ReminderReceiver(null));

        [Test]
        public void WhenOnMessage_IfMessageIsCorrect_ShouldRaiseEvent()
        {

        }
    }
    public class MessageTests
    {
        [Test]
        public void WhenDeclare_IfArgumentTextNullSpecified_ShouldThrowException() =>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                new Message(null, DateTimeOffset.Now));

        [Test]
        public void WhenDeclare_IfArgumentDatetimeDefaultSpecified_ShouldThrowException()=>
            //Arrange-Act-Assert
            Assert.Catch<ArgumentNullException>(() =>
                new Message("text", default));

        [Test]
        public void WhenTryParse_IfArgumentMessageNullSpecified_ShouldReturnError()
        {
            //Arrange-Act
            var (temp, error) = Message.TryParse(null);

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }

        [Test]
        public void WhenTryParse_IfNoDelimeterInMessage_ShouldReturnError()
        {
            //Arrange-Act
            var (temp, error) = Message.TryParse("text 2010-10-01");

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }

        [Test]
        public void WhenTryParse_IfTextPartIsNullOrWhitespace_ShouldReturnError()
        {
            //Arrange-Act
            var (temp, error) = Message.TryParse("    ,2010-10-01");

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }

        [Test]
        public void WhenTryParse_IfDatetimePartIsNullOrWhitespace_ShouldReturnError()
        {
            //Arrange-Act
            var (temp, error) = Message.TryParse("text,  ");

            //Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(error));
        }
    }
}