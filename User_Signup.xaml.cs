using System;
using System.Collections.Generic;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace talktalk
{
    /// <summary>
    /// User_Signup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class User_Signup : Page
    {
        NetworkStream stream = Home.clients.GetStream(); //데이터 전송에 사용된 스트림
        jprotocol jprotocol;
        public User_Signup()
        {
            InitializeComponent();
        }
        public void btn_login_Click(object sender, RoutedEventArgs e)
        {

            string SignUpID = MyTextBoxid.Text;
            string SignUpPW = MyTextBoxpw.Text;
            int responses = jprotocol.User_Signup(SignUpID, SignUpPW);

            if (responses == 1) // 성공
            {

                MessageBox.Show("성공띠");

                NavigationService.Navigate(
                                        new Uri("/Cs_Login.xaml", UriKind.Relative));

            }
            else if (responses == 0)
            {
                MessageBox.Show("중복된 아이디데스");
            }
        }
    }
}
