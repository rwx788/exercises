using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriangleChecker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Validator: ContentView
    {
        public Validator()
        {
            InitializeComponent();
        }

        private void RunButtonClicked(object sender, EventArgs e)
        {
            
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