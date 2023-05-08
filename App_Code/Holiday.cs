using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Holiday
{


    public Holiday()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static Dictionary<DateTime, String> GetHolidays(int year)
    {
        Dictionary<DateTime, String> holidays = new Dictionary<DateTime, String>();

        // New Years
        DateTime newYearsDate = AdjustForWeekendHoliday(new DateTime(year, 1, 1));
        holidays.Add(newYearsDate, "New Years Observered");

        // Martn Luther King Jr Birthday -- 3rd Monday in January 
        var mlk = (from day in Enumerable.Range(1, 30)
                            where new DateTime(year, 1, day).DayOfWeek == DayOfWeek.Monday
                            select day).ElementAt(2);
        DateTime martinLutherKingDay = new DateTime(year, 1, mlk);
        holidays.Add(martinLutherKingDay, "Martn Luther King Jr Day Observered");

        // Memorial Day -- last monday in May 
        DateTime memorialDay = new DateTime(year, 5, 31);
        DayOfWeek dayOfWeek = memorialDay.DayOfWeek;
        while (dayOfWeek != DayOfWeek.Monday)
        {
            memorialDay = memorialDay.AddDays(-1);
            dayOfWeek = memorialDay.DayOfWeek;
        }
        holidays.Add(memorialDay, "Memorial Day Observered");

        // Independence Day
        DateTime independenceDay = AdjustForWeekendHoliday(new DateTime(year, 7, 4));
        holidays.Add(independenceDay, "Independence Day Observered");

        DateTime goodFriday = AdjustForWeekendHoliday(EasterSunday(year).AddDays(-2));
        holidays.Add(goodFriday, "Good Friday Observered");

        // Labor Day -- 1st Monday in September 
        DateTime laborDay = new DateTime(year, 9, 1);
        dayOfWeek = laborDay.DayOfWeek;
        while (dayOfWeek != DayOfWeek.Monday)
        {
            laborDay = laborDay.AddDays(1);
            dayOfWeek = laborDay.DayOfWeek;
        }
        holidays.Add(laborDay, "Labor Day Observered");

        // Thanksgiving Day -- 4th Thursday in November 
        var thanksgiving = (from day in Enumerable.Range(1, 30)
                            where new DateTime(year, 11, day).DayOfWeek == DayOfWeek.Thursday
                            select day).ElementAt(3);
        DateTime thanksgivingDay = new DateTime(year, 11, thanksgiving);
        holidays.Add(thanksgivingDay, "Thanksgiving Observered");
        holidays.Add(thanksgivingDay.AddDays(1), "Black Friday Observered");


        DateTime christmasEve = AdjustForChristmasEveWeekendHoliday(new DateTime(year, 12, 24), holidays);
        holidays.Add(christmasEve, "Christmas Eve Observered");

        // Christmas Day 
        DateTime christmasDay = AdjustForChristmasWeekendHoliday(new DateTime(year, 12, 25), holidays);
        holidays.Add(christmasDay, "Christmas Observered");

        // Next year's new years check
        //DateTime nextYearNewYearsDate = AdjustForWeekendHoliday(new DateTime(year + 1, 1, 1));
        //if (nextYearNewYearsDate.Year == year)
        //    holidays.Add(nextYearNewYearsDate, "birthday Observer");

        return holidays;
    }

    public static DateTime AdjustForWeekendHoliday(DateTime holiday)
    {
        if (holiday.DayOfWeek == DayOfWeek.Saturday)
        {
            return holiday.AddDays(-1);
        }
        else if (holiday.DayOfWeek == DayOfWeek.Sunday)
        {   
            return holiday.AddDays(1);
        }
        else
        {
            return holiday;
        }
    }

    public static DateTime AdjustForChristmasEveWeekendHoliday(DateTime holiday, Dictionary<DateTime, String> holidays)
    {

        //if (holiday.DayOfWeek == DayOfWeek.Friday)
        //{
        //    return holiday.AddDays(-1);
        //}
        if (holiday.DayOfWeek == DayOfWeek.Saturday)
        {
            return holiday.AddDays(-1);
        }
        else if (holiday.DayOfWeek == DayOfWeek.Sunday)
        {
            return holiday.AddDays(1);
        }
        else
        {
            return holiday;
        }
    }


    public static DateTime AdjustForChristmasWeekendHoliday(DateTime holiday, Dictionary<DateTime, String> holidays)
    {
        if (holiday.DayOfWeek == DayOfWeek.Saturday)
        {
            return holiday.AddDays(2);
        }
        else if (holiday.DayOfWeek == DayOfWeek.Sunday)
        {
            return holiday.AddDays(1);
        }
        else if (holiday.DayOfWeek == DayOfWeek.Monday)
        {
            return holiday.AddDays(1);
        }
        else
        {
            return holiday;
        }
    }

    public static DateTime EasterSunday(int year)
    {
        int day = 0;
        int month = 0;

        int g = year % 19;
        int c = year / 100;
        int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
        int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

        day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
        month = 3;

        if (day > 31)
        {
            month++;
            day -= 31;
        }

        return new DateTime(year, month, day);
    }

}