using PAYBACK.App.Services;
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

namespace PAYBACK.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPayBackService payBackService;
        public MainWindow()
        {
            InitializeComponent();
            payBackService = new PayBackService();
        }

        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            Error.Content = payBackService.GetAccountBalance();
        }
    }
}
