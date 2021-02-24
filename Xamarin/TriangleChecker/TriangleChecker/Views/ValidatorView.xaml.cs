using System;
using System.Diagnostics;
using System.Linq;
using TriangleChecker.Controllers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriangleChecker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Validator : ContentView
    {
        public Validator()
        {
            InitializeComponent();
        }

        private void RunButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Enum type = ValidatorController.GetTriangleType(Int32.Parse(sideA.Text), Int32.Parse(sideB.Text), Int32.Parse(sideC.Text));

                switch (type)
                {
                    case TriangleTypes.Equilateral:
                        resultText.Text = "Triangle is Equilateral";
                        break;
                    case TriangleTypes.Isosceles:
                        resultText.Text = "Triangle is Isosceles";
                        break;
                    case TriangleTypes.Scalene:
                        resultText.Text = "Triangle is Scalene";
                        break;
                    case TriangleTypes.None:
                        resultText.Text = "Triangle with provided sides does NOT exist";
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