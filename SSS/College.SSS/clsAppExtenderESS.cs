using risersoft.shared;
using risersoft.shared.portable.Models.Nav;
using risersoft.shared.Providers;
using College.SSS.Global;
using Risersoft.Framework.Global;
using System;
using Xamarin.Forms;



namespace College.SSS
{
    public class clsAppExtenderESS : clsXamAppExtendBase
    {
        public override string StartupAppCode()
        {
            //return "ess.mob";
            return "sss";
        }

        public override IForm AboutBox()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicFormModelTypes()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicReportProviderTypes(clsAppController myContext)
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicTaskProviderTypes()
        {
            throw new NotImplementedException();
        }

        public override clsCollecString<Type> dicWOInfoTypes()
        {
            throw new NotImplementedException();
        }
        public override Page AddPage(string pgKey)
        {
            switch (pgKey.ToLower().Trim())
            {
              
                default:
                    return new Page();
            }
        }
        public override string ProgramName()
        {
            return "SSS";
        }
        public override string ProgramCode()
        {
            return "sss";
        }

        public override IAppDataProvider CreateDataProvider(clsAppController context, IAsyncWCFCallBack cb)
        {
            var str1 = AppConstants.RestServiceHost();

            var provider = new clsAppDataProviderREST(context, str1, (clsXamPolice)context.Police);
            return provider;
        }

        public override IForm frmDel(clsView pView, string IDX, string sysentXML)
        {
            throw new NotImplementedException();
        }
    }
}
