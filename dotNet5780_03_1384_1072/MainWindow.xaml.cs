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

namespace dotNet5780_03_1384_1072
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Host currentHost;
        List<Host> hostsList;
        public MainWindow()
        {
            InitializeComponent();
            

            hostsList = new List<Host>()
            {
                new Host()
                {
                    HostName="Dov Baker",
                  Units=new List<HostingUnit>()
                  {
                      new HostingUnit()
                      {
                          UnitName="bakers house",
                          Rooms=25,
                          IsSwimmimgPool=true,
                          AllOrders=new List<DateTime>(),
                          Uris=new List<string>(){ "https://images.app.goo.gl/u2J2aqLrqHFKYYs68" }
                      },
                      new HostingUnit()
                      {
                          UnitName="YAel house",
                          Rooms=1,
                          IsSwimmimgPool=true,
                          AllOrders=new List<DateTime>(),
                          Uris=new List<string>(){ "https://images.app.goo.gl/xmfdidcujfa7MwES9" }
                      }

                  }



                },
                new Host()
                {
                    HostName="David Bretlet",
                  Units=new List<HostingUnit>()
                  {
                      new HostingUnit()
                      {
                          UnitName="david house",
                          Rooms=30,
                          IsSwimmimgPool=true,
                          AllOrders=new List<DateTime>(),
                          Uris=new List<string>(){ "https://images.app.goo.gl/eEjSEttVdv8dy3vj9" }
                      },
                      new HostingUnit()
                      {
                          UnitName="Plonit house",
                          Rooms=3,
                          IsSwimmimgPool=false,
                          AllOrders=new List<DateTime>(),
                          Uris=new List<string>(){ "https://images.app.goo.gl/RuNT1JB5ctMsEDCy7" }
                      },
                      new HostingUnit()
                      {
                          UnitName="Almonit house",
                          Rooms=1,
                          IsSwimmimgPool=true,
                          AllOrders=new List<DateTime>(),
                          Uris=new List<string>(){ "https://images.app.goo.gl/rencSr35kLEnDAJE6" }
                      }

                  }



                },
                new Host()
                {
                    HostName="Rav Kok",
                  Units=new List<HostingUnit>()
                  {
                      new HostingUnit()
                      {
                          UnitName="Temple house",
                          Rooms=2,
                          IsSwimmimgPool=false,
                          AllOrders=new List<DateTime>(),
                          Uris=new List<string>(){ "https://images.app.goo.gl/rDAkrFJMWJF1VpR29" }
                      },


                  }



                }

            };


            cbHostList.ItemsSource = hostsList;
            cbHostList.DisplayMemberPath = "HostName";
            cbHostList.SelectedIndex = 0;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
            {

            }

            private void cbHostList_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                InitializeHost(cbHostList.SelectedIndex);
            }
            private void InitializeHost(int index)
            {
                MainGrid.Children.RemoveRange(1, 3);
                currentHost = hostsList[index];
                UpGrid.DataContext = currentHost;
                for (int i = 0; i < currentHost.Units.Count; i++)
                {
                    HostingUnitUserControl a = new HostingUnitUserControl(currentHost.Units[i]);
                    MainGrid.Children.Add(a);
                    Grid.SetRow(a, i + 1);
                }
            }
       
    } 
}
