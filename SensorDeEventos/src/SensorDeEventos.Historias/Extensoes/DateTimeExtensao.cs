
using System;

namespace SensorDeEventos.Historias.Extensoes
{
   public static class DateTimeExtensao
    {
        public static DateTime ToDateTime(this long unixTimeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();

            return dateTime;
        }
    }
}
