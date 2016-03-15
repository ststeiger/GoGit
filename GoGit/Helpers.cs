
namespace GoGit
{


    internal class Helpers
    {


        public static string GetGitignoreFile()
        {
            string text = null;
            System.Reflection.Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();

            string resourceName = null;

            foreach (string thisResourceName in ass.GetManifestResourceNames())
            {

                if (thisResourceName.EndsWith(".gitignore", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    resourceName = thisResourceName;
                    break;
                } // End if (thisResourceName.EndsWith(name, System.StringComparison.InvariantCultureIgnoreCase)) 

            } // Next thisResourceName

            using (System.IO.Stream strm = ass.GetManifestResourceStream(resourceName))
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(strm))
                {
                    text = reader.ReadToEnd();
                }

            } // End Using strm 

            return text;
        } // End Function GetGitignoreFile 


        public static string GetLocalTime()
        {
            string timeInfo = System.DateTime.Now.ToString("dddd', 'dd'.'MM' ('MMMM') 'yyyy' 'HH':'mm':'ss' {@TZ} (GMT'zzz')'");

            if (System.TimeZone.CurrentTimeZone.IsDaylightSavingTime(System.DateTime.Now))
                timeInfo = timeInfo.Replace("{@TZ}", System.TimeZone.CurrentTimeZone.DaylightName == "Mitteleuropäische Sommerzeit" ? "CEST" : System.TimeZone.CurrentTimeZone.DaylightName);
            else
                timeInfo = timeInfo.Replace("{@TZ}", System.TimeZone.CurrentTimeZone.StandardName == "Mitteleuropäische Zeit" ? "CET" : System.TimeZone.CurrentTimeZone.StandardName);

            return timeInfo.Replace("\"", "\\\"");
        } // End Function GetLocalTime 


    }


}
