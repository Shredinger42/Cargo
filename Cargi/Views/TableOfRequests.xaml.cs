using Cargo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cargo
{
    /// <summary>
    /// Interaction logic for TableOfApplications.xaml
    /// </summary>
    public partial class TableOfApplications : UserControl
    {
        public TableOfApplications()
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
