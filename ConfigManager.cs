using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAppConfig
{
    public class ConfigManager
    {
        public enum Envoironment { PROD, TEST, DEV };

        public Dictionary<string, string> _theApplicationConfiguration { get; set; }
        public string ApplicationTitle { get; set; } = ConfigurationManager.AppSettings["ApplicationTitle"];
        public ConfigManager()
        {
            try
            {
                var appSettings = ConfigurationManager.GetSection("appSettings") as NameValueCollection;
                //var v = appSettings.Count;

                _theApplicationConfiguration = new Dictionary<string, string>();
                foreach (string s in appSettings.AllKeys)
                {
                    var paramKey = s;
                    var paramValue = appSettings.Get(s);
                    _theApplicationConfiguration.Add(paramKey, paramValue);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }

        }



        public void GetApplicationSettings()
        {
            try
            {
                var applicationSettings = ConfigurationManager.GetSection("ApplicationSettings") as NameValueCollection;
                if (applicationSettings == null) throw new Exception($"Error while reading [ApplicationSettings]");

                foreach (var key in applicationSettings.AllKeys)
                {
                    Console.WriteLine(key + " = " + applicationSettings[key]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void GetConfigurationSectionGroup(Envoironment env)
        {

            var node = string.Empty;
            switch (env)
            {
                case Envoironment.PROD:
                    node = "Production";
                    break;
                case Envoironment.TEST:
                    node = "Test";
                    break;
                case Envoironment.DEV:
                    node = "Development";
                    break;
                default: break;
            }
            try
            {
                var PostSetting = ConfigurationManager.GetSection($"EnvoironmentSettings/{node}") as NameValueCollection;
                if (PostSetting == null) throw new Exception($"Error while reading [GetConfigurationSectionGroup]");

                foreach (var key in PostSetting.AllKeys)
                {
                    Console.WriteLine(key + " = " + PostSetting[key]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }

        }

        //public void GetDBSettings(Envoironment env)
        //{
        //    var PostSetting = ConfigurationManager.GetSection($"DBSettings/{env}") as NameValueCollection;
        //    if (PostSetting.Count == 0)
        //    {
        //        Console.WriteLine("Post Settings are not defined");
        //    }
        //}
    }
}
