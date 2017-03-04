using System;

namespace Caliburn.Micro.Training.Common
{
    public interface IDateTimeProvider
    {
        DateTimeOffset GetCurrentTime();
        DateTime GetUtcNow();
    }
}
