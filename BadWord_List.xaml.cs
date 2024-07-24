using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace talktalk
{
    /// <summary>
    /// BadWord_List.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    public class MyClass
    {
        public string ID { get; set; }
        public string Text { get; set; }

        //public ObservableCollection<MyClass> myClasses = new ObservableCollection<MyClass>();

    };
    public partial class BadWord_List : Page
    {
        public ObservableCollection<MyClass> myClasses = new ObservableCollection<MyClass>();
        public BadWord_List()
        {
            InitializeComponent();
            //viewllist.Items.Add(MyClass);
            myClasses = new ObservableCollection<MyClass>() {
                new MyClass() { ID = "ee", Text = "11" },
                new MyClass() { ID = "dd", Text = "22" },
                new MyClass() { ID = "cc", Text = "33" },
                new MyClass() { ID = "bb", Text = "44" },
                new MyClass() { ID = "aa", Text = "55" } };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            ListView_GetItem(e);

        }

        private static MyClass ListView_GetItem(RoutedEventArgs e)
            // 보내기 슝 
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while (!(dep is System.Windows.Controls.ListViewItem))
            {
                try
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                catch
                {
                    return null;
                }
            }
            // 여기서 받은거 서버로 보내서 처리하기 띵 
            ListViewItem item = (ListViewItem)dep;
            MyClass content = (MyClass)item.Content;
            MessageBox.Show(content.ID + "\n" + content.Text);
            return content;
        }
        public void ListMake()
            // 리스트뷰에 넣기
        {
            viewllist.Items.Add(myClasses);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewllist.ItemsSource = myClasses;


        }
    }
}
