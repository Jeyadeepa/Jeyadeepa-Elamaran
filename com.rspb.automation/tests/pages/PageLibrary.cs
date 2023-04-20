using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rspb.automation.tests.pages
{
    public static class PageLibrary
    {
        private static T GetPageLib<T>() where T : new()
        {
            var page = new T();
            return page;
        }

        public static HomePage Home
        {
            get { return GetPageLib<HomePage>(); }
        }

        public static SignupPage Signup
        {
            get { return GetPageLib<SignupPage>(); }
        }

        public static LoginPage Login
        {
            get { return GetPageLib<LoginPage>(); }
        }
        public static JoinAndDonatePage JoinAndDonate
        {
            get { return GetPageLib<JoinAndDonatePage>(); }
        }

    }
}
