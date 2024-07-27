using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace talktalk
{
    /// <summary>
    /// Cs_Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Cs_Login : Page
    {
        public string User_ID;
        jprotocol jprotocol = new jprotocol();
        NetworkStream stream = Home.clients.GetStream();
        List<string> str_list_jobject = new List<string>();
        List<string> login_list = new List<string>();
        byte[] data = new byte[256];

        public Cs_Login()
        {
            InitializeComponent();
        }
        private void txt_ID_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_ID.Clear();
        }

        private void pw_PW_GotFocus(object sender, RoutedEventArgs e)
        {
            pw_PW.Clear();
        }
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string id = txt_ID.Text;
            string pw = pw_PW.Password;
            User_ID = txt_ID.Text;

            int response = jprotocol.Login(id, pw);


            if (response == 1) // 로그인 성공
            {
                stream.Flush();
                //Word_Collector word_Collector = new Word_Collector(User_ID);
                NavigationService.Navigate(new Uri("Word_Collector.xaml", UriKind.Relative));

                //NavigationService.Navigate(word_Collector);
                //User_ID = id;
            }
            else if (response == 0)// 실패 
            {
                MessageBox.Show("회원정보가 일치하지 않습니다.");
            }
        }

        private void btn_join_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("User_Signup.xaml", UriKind.Relative));
        }
    }


}
