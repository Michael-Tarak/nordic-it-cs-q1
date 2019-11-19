using System;
using NUnit.Framework;

namespace Reminder.Storage.Memory.Test
{
    public class ReminderItemTests
    {
        [Test]
        public void WhenDefine_IfIdIsDefault_ThrowException()
        {
            Assert.Catch<ArgumentException>(()=>
                new ReminderItem(
                    default,
                    "some",
                    "thing",
                    DateTimeOffset.Now)
                );
        }
        [Test]
        public void WhenDefine_IfContactIdIsNullOrWhitespace_ThrowException()
        {
            Assert.Catch<ArgumentException>(() =>
                new ReminderItem(
                    Guid.NewGuid(),
                    null,
                    "thing",
                    DateTimeOffset.Now)
                );
        }
        [Test]
        public void WhenDefine_IfMessageIsNullOrWhitespace_ThrowException()
        {
            Assert.Catch<ArgumentException>(() =>
                new ReminderItem(
                    Guid.NewGuid(),
                    "contactId",
                    null,
                    DateTimeOffset.Now)
                );
        }
        [Test]
        public void WhenDefine_IfDateTimeIsDefault_ThrowException()
        {
            Assert.Catch<ArgumentException>(() =>
                new ReminderItem(
                    Guid.NewGuid(),
                    "contactId",
                    "message",
                    default)
                );
        }
    }
}