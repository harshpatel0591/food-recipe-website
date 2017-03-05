using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorLog;

namespace Common
{
    public class CommonCompute
    {

        public static string ConvertTime(int seconds) 
        {
            string result = "";
            try
            {
                TimeSpan t = new TimeSpan(0, 0, seconds);
                result = (t.ToString("hh") == "00" ? "" : t.ToString("hh") + "hrs") +
                    (t.ToString("mm") == "00" ? "" : t.ToString("mm") + "mins") +
                    (t.ToString("ss") == "00" ? "" : t.ToString("ss") + "secs");
                
            }
            catch (Exception ex)
            {
                ex.SendMail();
                result = "";
            }
            return result;
        }

    }
}
