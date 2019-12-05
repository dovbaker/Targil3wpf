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
    /// Interaction logic for HostingUnitUserControl.xaml
    /// </summary>
    public partial class HostingUnitUserControl : UserControl
    {

        int imageIndex;
        Viewbox vbImage;
        Image MyImage;

        private Calendar MyCalendar;
        public HostingUnit CurrentHostingUnit
        { get; set; }

        //עבור על כל הימים שברשימה המעודכנת, וסמן אותם בלוח השנה. 
        private void SetBlackOutDates()
        {
            foreach (DateTime date in CurrentHostingUnit.AllOrders)
            {
                MyCalendar.BlackoutDates.Add(new CalendarDateRange(date));
            }
        }

        //צור לוח, הצגה 'חודשית', ניתן לבחור רצף אחד, סמן את היום הנוכחי.
        private Calendar CreateCalendar()
        {
            Calendar MonthlyCalendar = new Calendar();
            MonthlyCalendar.Name = "MonthlyCalendar";
            MonthlyCalendar.DisplayMode = CalendarMode.Month;
            MonthlyCalendar.SelectionMode = CalendarSelectionMode.SingleRange;
            MonthlyCalendar.IsTodayHighlighted = true;
            return MonthlyCalendar;
        }

        //constructor
        public HostingUnitUserControl(HostingUnit hostUnit)
        {
            vbImage = new Viewbox();

            InitializeComponent();

            //size of pic
            imageIndex = 0;
            vbImage.Width = 75;
            vbImage.Height = 75;
            vbImage.Stretch = Stretch.Fill;
            UserControlGrid.Children.Add(vbImage);
            Grid.SetColumn(vbImage, 2);
            Grid.SetRow(vbImage, 0);

            //צרו תמונה חדשה, ושים אותה על ה ViewBox.
            //MyImage = CreateViewImage();
            //vbImage.Child = null;
            //vbImage.Child = MyImage;




            this.CurrentHostingUnit = hostUnit;
            UserControlGrid.DataContext = hostUnit;

            MyCalendar = CreateCalendar();
          vbCalendar.Child = null;
            vbCalendar.Child= MyCalendar;
            SetBlackOutDates();

            //vbImage.MouseUp += vbImage_MouseUp;
            //vbImage.MouseEnter += vbImage_MouseEnter;
            //vbImage.MouseLeave += vbImage_MouseLeave;


        }

        //private Image CreateViewImage()
        //{
        //    Image dynamicImage = new Image();
        //    BitmapImage bitmap = new BitmapImage();
        //    bitmap.BeginInit();
        //    bitmap.UriSource = new Uri(@CurrentHostingUnit.Uris[imageIndex]);
        //    bitmap.EndInit();
        //    // Set Image.Source
        //    dynamicImage.Source = bitmap;
        //    // Add Image to Window
        //    return dynamicImage;
        //}

        //private void vbImage_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    vbImage.Width = 75;
        //    vbImage.Height = 75;
        //}
        //private void vbImage_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    vbImage.Width = this.Width / 3;
        //    vbImage.Height = this.Height;
        //}
        //private void vbImage_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    vbImage.Child = null;
        //    imageIndex =
        //   (imageIndex + CurrentHostingUnit.Uris.Count - 1) % CurrentHostingUnit.Uris.Count;
        //    MyImage = CreateViewImage();
        //    vbImage.Child = MyImage;
        //}
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            List<DateTime> myList = MyCalendar.SelectedDates.ToList();
            MyCalendar = CreateCalendar();
            vbCalendar.Child = null;
            vbCalendar.Child = MyCalendar;
            addCurrentList(myList);
            SetBlackOutDates();
        }
        private void addCurrentList(List<DateTime> tList)
        {
            foreach (DateTime d in tList)
            {
                CurrentHostingUnit.AllOrders.Add(d);
            }
        }

    }
}
