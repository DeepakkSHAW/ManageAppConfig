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

        public Dictionary<string, string> theApplicationConfiguration { get; set; }
        public string ApplicationTitle { get; set; } = ConfigurationManager.AppSettings["ApplicationTitle"];
        public ConfigManager()
        {
            try
            {
                var appSettings = ConfigurationManager.GetSection("appSettings") as NameValueCollection;
                //var v = appSettings.Count;

                theApplicationConfiguration = new Dictionary<string, string>();
                foreach (string s in appSettings.AllKeys)
                {
                    var paramKey = s;
                    var paramValue = appSettings.Get(s);
                    theApplicationConfiguration.Add(paramKey, paramValue);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }

        }

        public Dictionary<string, string> GetApplicationSettings()
        {
            var vReturn = new Dictionary<string, string>();
            try
            {
                var applicationSettings = ConfigurationManager.GetSection("ApplicationSettings") as NameValueCollection;
                if (applicationSettings == null) throw new Exception($"Error while reading [ApplicationSettings]");

                foreach (var key in applicationSettings.AllKeys)
                {
                    //Console.WriteLine(key + " = " + applicationSettings[key]);
                    vReturn.Add(key, applicationSettings[key]);
                }
                return vReturn;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public Dictionary<string, string> GetConfigurationSectionGroup(Envoironment env)
        {
            var vReturn = new Dictionary<string, string>();
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
                    //Console.WriteLine(key + " = " + PostSetting[key]);
                    vReturn.Add(key, PostSetting[key]);
                }
                return vReturn;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }

        }

        public Dictionary<string, string> GetCustomConfiguration()
        {
            var vReturn = new Dictionary<string, string>();
            try
            {
                var trademarkSettings = ConfigurationManager.GetSection("TrademarkSettings") as ManageAppConfig.TrademarkSettings;
                if (trademarkSettings == null)
                {
                    throw new Exception($"Error while reading [GetCustomConfiguration]");
                }
                else
                {
                    var companyName = trademarkSettings.companyProfile.CompanyName;
                    vReturn.Add("CompanyName", companyName);
                    var country = trademarkSettings.companyProfile.Country;
                    vReturn.Add("Country", country);
                    var registration = trademarkSettings.companyProfile.Registration;
                    vReturn.Add("Registration", registration.ToString());
                    var industry = trademarkSettings.companyProfile.Industry;
                    vReturn.Add("Industry", industry);

                    //Console.WriteLine("Company Name = " + companyName);
                    //Console.WriteLine("Country = " + country);
                    //Console.WriteLine("Registration  = " + registration.ToString());
                    //Console.WriteLine("Industry = " + industry);

                }
                return vReturn;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void SaveAppConfig(string key, string value)
        {
            try
            {
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var keys = config.AppSettings.Settings.AllKeys;
                if (keys.Contains(key, StringComparer.OrdinalIgnoreCase))
                    //Add Key Value
                    config.AppSettings.Settings[key].Value = value;
                else
                    // Update key value
                    config.AppSettings.Settings.Add(key, value);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                throw;

            }
        }
    }
}
