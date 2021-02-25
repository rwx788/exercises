using System;
using System.Linq;
using TriangleChecker.Resources;
using Xamarin.UITest.Queries;

namespace TriangleChecker.UITests.Pages
{
    public class MainPage : BasePage
    {
        private readonly Func<AppQuery, AppQuery> btnRun;
        private readonly Func<AppQuery, AppQuery> lblHeader;
        private readonly Func<AppQuery, AppQuery> lblResult;
        private readonly Func<AppQuery, AppQuery> txtSideA;
        private readonly Func<AppQuery, AppQuery> txtSideB;
        private readonly Func<AppQuery, AppQuery> txtSideC;

        public MainPage()
        {
            if (OnAndroid)
            {
                btnRun    = x => x.Marked(ValidatorRes.RunBtnText);
                lblHeader = x => x.Marked(HeaderRes.HeaderLabelText);
                lblResult = x => x.Marked(ValidatorRes.ResultLabelid);
                txtSideA  = x => x.Marked(ValidatorRes.SideAid);
                txtSideB  = x => x.Marked(ValidatorRes.SideBid);
                txtSideC  = x => x.Marked(ValidatorRes.SideCid);
            }
        }

        public bool IsHeaderDisplayed()
        {
            return app.WaitForElement(lblHeader).Any();
        }

        public MainPage PressRunButton()
        {
            app.WaitForElement(btnRun);
            app.Tap(btnRun);
            return this;
        }

        public MainPage SetSideALength(string text)
        {
            EnterText(ValidatorRes.SideAid, text);
            return this;
        }

        public MainPage SetSideBLength(string text)
        {
            EnterText(ValidatorRes.SideBid, text);
            return this;
        }

        public MainPage SetSideCLength(string text)
        {
            EnterText(ValidatorRes.SideCid, text);
            return this;
        }

        public string GetResultText()
        {
            return app.Query(lblResult)[0].Text;


        }
    }
}
