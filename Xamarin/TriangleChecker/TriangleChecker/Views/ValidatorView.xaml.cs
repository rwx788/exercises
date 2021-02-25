using System;
using System.Diagnostics;
using System.Linq;
using TriangleChecker.Controllers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriangleChecker.Resources;

namespace TriangleChecker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ValidatorView : ContentView
    {
        public ValidatorView()
        {
            InitializeComponent();
        }

        private void RunButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Enum type = ValidatorController.GetTriangleType(UInt32.Parse(sideA.Text), UInt32.Parse(sideB.Text), UInt32.Parse(sideC.Text));

                switch (type)
                {
                    case TriangleTypes.Equilateral:
                        resultText.Text = ValidatorRes.ResultEquilateral;
                        break;
                    case TriangleTypes.Isosceles:
                        resultText.Text = ValidatorRes.ResultIsosceles;
                        break;
                    case TriangleTypes.Scalene:
                        resultText.Text = ValidatorRes.ResultScalene;
                        break;
                    case TriangleTypes.None:
                        resultText.Text = ValidatorRes.ResultNone;
                        break;
                }
            }
            catch (FormatException ex)
            {
                Debug.WriteLine("Unable to parse input: " + ex.Message);
            }
        }

        private void EntryCompleted(object sender, EventArgs e)
        {
            try
            {
                // Check that event sender is Entry and StackLayout is used
                if (!(sender is Entry entry) || !(entry.Parent is StackLayout stack))
                    return;
                var list = stack.Children;
                var index = list.IndexOf(entry);
                var next = list.ElementAt(++index % list.Count);
                next?.Focus();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}