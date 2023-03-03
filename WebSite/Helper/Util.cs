// ----------------------------------------------------------------------------
// WebSite.Util.cs
// Created by Paulo Gemniczak on 16/07/2019
// Copyright © 2019 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using System;

namespace WebSite.Helper
{
    public abstract class Util
    {
        public static DateTime HrBrasilia()
        {
            DateTime dateTime = DateTime.UtcNow;
            TimeZoneInfo hrBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, hrBrasilia);
        }
    }
}
