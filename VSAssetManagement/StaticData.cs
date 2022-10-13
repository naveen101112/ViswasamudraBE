using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using VSAssetManagement.Models;

namespace VSAssetManagement
{
    public static class StaticData
    {
        public static List<Status> statusList { get; set; }

        public static IConfiguration appSettings;

        public static string getDateString(DateTime date)
        {
            if (date == null || date.Year == 0001) return null;
            return date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
