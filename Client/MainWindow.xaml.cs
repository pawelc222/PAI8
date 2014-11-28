using Client.FacadeServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MyDataContext myDataContext { get; set; }
        private readonly ServiceLocator _serviceLocator;

        public MainWindow()
        {
            myDataContext = new MyDataContext();
            InitializeComponent();
            _serviceLocator = ServiceLocator.GetInstance();
            
        }

        private void GetData()
        {
            var serverFacadeClient = (FacadeServiceReference.Service1Client)_serviceLocator.GetService(ServiceLocator.ServiceTypeFacade);
            var PersonData = serverFacadeClient.GetCompleteData();
            foreach(var p in PersonData)
            {
                myDataContext.PersonsData.Add(p);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void DoSocialismButton_Click(object sender, RoutedEventArgs e)
        {
            var serverFacadeClient = (FacadeServiceReference.Service1Client)_serviceLocator.GetService(ServiceLocator.ServiceTypeFacade);
            serverFacadeClient.DoSocialismCompleted += serverFacadeClient_DoSocialismCompleted;
            serverFacadeClient.DoSocialismAsync();
        }

        void serverFacadeClient_DoSocialismCompleted(object sender, DoSocialismCompletedEventArgs e)
        {
            MessageBox.Show("Nasze kochane socjalistyczna państwo zabierze wam pieniądze, w sumie: " + e.Result);
        }


    }

    public class MyDataContext
    {
        public ObservableCollection<PersonComplete> PersonsData { get; set; }

        public MyDataContext()
        {
            PersonsData = new ObservableCollection<PersonComplete>();
        }
    }
}
