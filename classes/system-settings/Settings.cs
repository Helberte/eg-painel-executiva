using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eg_painel.classes.system_settings
{
   
    internal class Settings
    {
        private FontFamily montserrat;
        static Settings? config;
    

        private Settings()
        {
            montserrat = new FontFamily("Montserrat");
        }
        public static FontFamily GetFontMontserrat()
        {
            if (config is null)
            {
                config = new Settings();
                return config.montserrat;
            }
            return config.montserrat;
        }
    }
}
