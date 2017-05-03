using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginForm
{
    class FormValidation{
        private Regex regex;
        private Match match;

        private static String EMAIL_REGEX = "^[A-Za-z0-9+_.-]+@(.+)$";

        private static String USERNAME_PATTERN = "^[a-z0-9_-]{5,30}$";

        private static String PASSWORD_PATTERN = "((?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{5,30})";

        public bool validUserName(String userName) {
            this.regex = new Regex(USERNAME_PATTERN);
            this.match = this.regex.Match(userName);
            return this.match.Success;
        }

        public bool validPassword(String password) {
            this.regex = new Regex(PASSWORD_PATTERN);
            this.match = this.regex.Match(password);
            return this.match.Success;
        }

        public bool validIsExist(String inputVal) {
            bool returnResult = true;
            inputVal = inputVal.Trim();
            int length = inputVal.Length;
            if (length == 0) {
                returnResult = true;
            } else if (length > 0) {
                returnResult = false;
            }
            return returnResult;
        }
    }
}
