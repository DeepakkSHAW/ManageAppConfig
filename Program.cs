using System;
using System.Collections;
using System.Configuration;
using System.Linq;

namespace ManageAppConfig
{
    class Program
    {
        static string[] strRequiredParams = { "name", "surname" };

        static void Main(string[] args)
        {
            Console.WriteLine("----- Manage Application Configuration -----");
            try
            {
                ConfigManager configManager = new ConfigManager();
                var appconfig = configManager.theApplicationConfiguration;
                var title = configManager.ApplicationTitle;
                Console.WriteLine($"Application Title coming from app config [{title}].");
                var applicationConfig = configManager.GetApplicationSettings();
                var sectionGroupConfig = configManager.GetConfigurationSectionGroup(ConfigManager.Envoironment.PROD);
                var customConfig =  configManager.GetCustomConfiguration();

                //** Check if required parameters are in application configuration otherwise add them**//
                foreach (string s  in strRequiredParams)
                {
                    var foundConfig = appconfig.Where(e => e.Key.ToLower() == s.ToLower()).FirstOrDefault();
                    if (string.IsNullOrEmpty(foundConfig.Value))
                    {
                        Console.WriteLine($"Enter Parameter ({s}):");
                        var value = Console.ReadLine();
                        configManager.SaveAppConfig(s, value);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
