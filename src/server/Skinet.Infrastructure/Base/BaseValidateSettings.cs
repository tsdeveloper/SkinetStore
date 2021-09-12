using System;
using Skinet.Core.Entities.Base;

namespace Skinet.Infrastructure.Base
{
    public static class BaseValidateSettings
    {
        public static void ValidateSettings(this Settings settings)
        {
            if (settings.AppSettings == null)
                throw new ArgumentException($"Not found entity of {nameof(settings.AppSettings)}");
            
            if (string.IsNullOrWhiteSpace(settings.AppSettings.ConnectionString))
                throw new ArgumentException($"Not found connection of {nameof(settings.AppSettings.ConnectionString)}");
        }
    }
}