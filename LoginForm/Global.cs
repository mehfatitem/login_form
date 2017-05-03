using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm{
    static class Global{
        private static String systemLanguage = "";
        private static String userName = "";

        public static String systemLang{
            get { return systemLanguage; }
            set { systemLanguage = value; }
        }
        public static String systemUserName{
            get { return userName; }
            set { userName = value; }
        }

    }
}
