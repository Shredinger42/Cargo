using Cargo.ViewModels;
using System;
using System.Windows;

namespace Cargo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = new TableOfApplications();
        }

        private void ShowTableOfApplications(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new TableOfApplications();
        }

        private void ShowListOfApplications(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new ListOfApplications();
        }
    }
}
