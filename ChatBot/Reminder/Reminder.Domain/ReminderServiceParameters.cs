using System;

namespace Reminder.Domain
{
    public class ReminderServiceParameters
    {
        public TimeSpan CreateTimerInterval { get; }
        public TimeSpan CreateTimerDelay { get; } 
        public TimeSpan ReadyTimerInterval { get; } 
        public TimeSpan ReadyTimerDelay { get; } 
        public ReminderServiceParameters():
            this (
                TimeSpan.FromSeconds(1),
                TimeSpan.Zero,
                TimeSpan.FromSeconds(1),
                TimeSpan.Zero)
        {

        }
        public ReminderServiceParameters(
            TimeSpan createTimerInterval,
            TimeSpan createTimerDelay,
            TimeSpan readyTimerInterval,
            TimeSpan readyTimerDelay
        )
        {
            CreateTimerInterval = createTimerInterval;
            CreateTimerDelay = createTimerDelay;
            ReadyTimerInterval = readyTimerInterval;
            ReadyTimerDelay = readyTimerDelay;
        }
    }
}
