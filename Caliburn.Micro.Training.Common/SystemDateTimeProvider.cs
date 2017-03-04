using System;

namespace Caliburn.Micro.Training.Common
{
    internal sealed class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset GetCurrentTime()
        {
            return DateTimeOffset.Now;
        }

        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
