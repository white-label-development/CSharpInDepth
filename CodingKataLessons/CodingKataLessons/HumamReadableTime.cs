using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodingKataLessons.IpValidation
{
    // https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
    class HumanReadableTime
    {
        public HumanReadableTime()
        {
            
        }

        static string GetReadableTime(int seconds)
        {
            var ts = TimeSpan.FromSeconds(seconds);
           
            //return string.Format("{0:00}:{1:00}:{2:00}", ts.TotalSeconds, ts.TotalMinutes, ts.TotalHours);(())
            var d = new DateTime(0,0,0);
            d.AddSeconds(seconds);
            
            return string.Format("{0:00}:{1:00}:{2:00}", d.ToString("HH"), d.ToString("mm"), d.ToString("ss"));
        }

    //   Assert.AreEqual("00:00:00", TimeFormat.GetReadableTime(0));
    //   Assert.AreEqual("00:00:05", TimeFormat.GetReadableTime(5));
    //   Assert.AreEqual("00:01:00", TimeFormat.GetReadableTime(60));
    //   Assert.AreEqual("23:59:59", TimeFormat.GetReadableTime(86399));
    //   Assert.AreEqual("99:59:59", TimeFormat.GetReadableTime(359999));
    }

}

