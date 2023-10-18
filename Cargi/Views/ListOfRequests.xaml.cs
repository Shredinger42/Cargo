using Cargo.ViewModels;
using System;
using System.Windows.Controls;

namespace Cargo
{
   
    public partial class ListOfApplications : UserControl
    {
        public ListOfApplications()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            if (DataContext != null && DataContext is RequestsViewModel vm)
            {
                vm.Load();
            }
        }
    }
}
