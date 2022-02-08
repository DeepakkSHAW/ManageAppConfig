using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageAppConfig
{
   public class CompanyProfile : ConfigurationElement
    {
        [ConfigurationProperty("CompanyName", DefaultValue = "OM", IsRequired = true)]
        public string CompanyName
        {
            get
            {
                return (string)this["CompanyName"];
            }
            set
            {
                value = (string)this["CompanyName"];
            }
        }

        [ConfigurationProperty("Registration", DefaultValue = 0, IsRequired = true)]
        public int Registration
        {
            get
            {
                return (int)this["Registration"];
            }
            set
            {
                value = (int)this["Registration"];
            }
        }

        [ConfigurationProperty("Country", IsRequired = false)]
        public string Country
        {
            get
            {
                return (string)this["Country"];
            }
            set
            {
                value = (string)this["Country"];
            }
        }

        [ConfigurationProperty("Industry", DefaultValue = "IT", IsRequired = false)]
        public string Industry
        {
            get
            {
                return (string)this["Industry"];
            }
            set
            {
                value = (string)this["Industry"];
            }
        }
    }
}
