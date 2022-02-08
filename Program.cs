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

                var title = configManager.ApplicationTitle;
                Console.WriteLine($"Application Title coming from app config [{title}].");
                configManager.GetApplicationSettings();
                configManager.GetConfigurationSectionGroup(ConfigManager.Envoironment.PROD);

                //configManager.GetDBSettings(ConfigManager.Envoironment.DEV);
                //ConfigManager configManager = new ConfigManager();

                //for (int i = 0; i < strRequiredParams.Length; i++)
                //{
                //    if (objRun.getParam(strRequiredParams[i]).Equals(""))
                //    {
                //        blnMissingParams = true;
                //        Console.WriteLine("Enter Parameter ('" + strRequiredParams[i] + "'): ");
                //        objRun.setParam(strRequiredParams[i], Console.ReadLine());
                //    }
                //}
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }



            //Console.ReadKey();
        }

        //public void LoadParamsFromAppConfig()
        //{
        //    try
        //    {
        //        System.Collections.Specialized.NameValueCollection appConfig = ConfigurationManager.AppSettings;
        //        foreach (string s in appConfig.AllKeys)
        //        {
        //            var paramKey = s;
        //            var paramValue = appConfig.Get(s);
        //            //System.Diagnostics.Debug.WriteLine("Key: " + paramKey + " Value: " + paramValue);
        //            if (paramKey.StartsWith("ps-"))
        //            {
        //                //var key = paramKey.Remove(0, 3); System.Diagnostics.Debug.WriteLine($"Key: {key}");
        //                if (!getParam(paramKey).Equals("")) { writeWhereRelevant("WARNING: Parameter ('" + paramKey + "') seems to have been defined multiple times."); }

        //                //See if this parameter is encrypted
        //                try { if (!clsCrypto.DecryptStringAES(paramValue, strMasterPassword).Equals("")) { paramValue = clsCrypto.DecryptStringAES(paramValue, strMasterPassword); } }
        //                catch (Exception ex) { }

        //                setParam(paramKey.Remove(0, 3), paramValue);
        //            }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        //private void SaveAppConfig(string key, string value)
        //{
        //    try
        //    {
        //        System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //        var keys = config.AppSettings.Settings.AllKeys;
        //        if (keys.Contains(key))
        //            //Add Key Value
        //            config.AppSettings.Settings[key].Value = value;
        //        else
        //            // Update key value
        //            config.AppSettings.Settings.Add(key, value);

        //        config.Save(ConfigurationSaveMode.Modified);
        //        ConfigurationManager.RefreshSection("appSettings");
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.Message);
        //    }
        //}
        //public void saveParams()
        //{
        //    if (hshParams.Count == 0) { return; }
        //    try
        //    {
        //        IDictionaryEnumerator enumParam = hshParams.GetEnumerator();

        //        while (enumParam.MoveNext())
        //        {
        //            try
        //            {
        //                string strParam = enumParam.Key.ToString();
        //                string strValue = enumParam.Value.ToString();
        //                if (strParam.ToUpper().IndexOf("PASSWORD") > -1)
        //                    //Encrypt this parameter for write to file
        //                    strValue = clsCrypto.EncryptStringAES(strValue, strMasterPassword);

        //                SaveAppConfig($"ps-{strParam}", strValue);
        //            }
        //            catch (Exception ex)
        //            {
        //                writeWhereRelevant("Unable to save parameter ('" + enumParam.Key.ToString() + "'): " + ex.Message);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        writeWhereRelevant("Unable to save parameters: " + ex.Message);
        //    }
        //}

    }
}
