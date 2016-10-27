using System;

namespace RumbleApp.Core.Helpers
{
// ReSharper disable once InconsistentNaming
    public class GATimeHelper
    {
        public static void LogPageLoad(string pageName)
        {
            //this may error if long is too large (believe > 2.5h), so we default it
            long ms = 99;
            try
            {
                TimeSpan span = DateTime.UtcNow - App.PageOpenedDateTime;
                ms = span.Ticks;
            }
            catch (Exception ex)
            {
             //don't report
            }
          
        }
    }
}
