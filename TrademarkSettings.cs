using System.Configuration;

namespace ManageAppConfig
{
    public class TrademarkSettings :  ConfigurationSection
    {
        [ConfigurationProperty("CompanyProfile")]
        public CompanyProfile companyProfile
        {
            get
            {
                return (CompanyProfile)this["CompanyProfile"];
            }
            set
            {
                value = (CompanyProfile)this["CompanyProfile"];
            }
        }
    }
}
