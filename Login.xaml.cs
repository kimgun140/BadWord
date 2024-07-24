using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    /// Login.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Page
    {
        static readonly HttpClient API = new HttpClient();
        byte[] data = new byte[256];


        NetworkStream stream = Home.clients.GetStream();

        //static NetworkStream stream = clients.GetStream();
        public Login()
        {
            InitializeComponent();

        }
        public void CS_login(string id, string pw) // 상담원 로그인 
        {
            try
            {
                List<string> aaaa = new List<string>();
                byte[] data;

                //TcpClient client = new TcpClient("10.10.21.111", 5558); //연결객체
                //NetworkStream stream = MainPage.client.GetStream(); //데이터 전송에 사용된 스트림

                //stream.WriteAsync(data, 0, data.Length);

                string send_msg;

                // 상담원 로그인 플래그 보내기 

                data = null;
                data = new byte[256];
                send_msg = "로그인요청";// 시그널
                data = Encoding.UTF8.GetBytes(send_msg);
                stream.Write(data, 0, data.Length);//전송할 데이터의 바이트 배열, 전송을 시작할 배열의 인덱스, 전송할 데이터의 길이.

                Thread.Sleep(100);


                data = null;
                data = new byte[256];
                send_msg = id;// 아이디
                data = Encoding.UTF8.GetBytes(send_msg);
                stream.Write(data, 0, data.Length);//전송할 데이터의 바이트 배열, 전송을 시작할 배열의 인덱스, 전송할 데이터의 길이.

                Thread.Sleep(100);



                data = null;
                data = new byte[256];
                send_msg = pw;// 비밀번호 
                data = Encoding.UTF8.GetBytes(send_msg);
                stream.Write(data, 0, data.Length);//전송할 데이터의 바이트 배열, 전송을 시작할 배열의 인덱스, 전송할 데이터의 길이.

                Thread.Sleep(100);



                //read
                data = null;
                data = new byte[256];
                int bytes = stream.Read(data, 0, data.Length);//받는 데이터의 바이트배열, 인덱스, 길이
                string responses = Encoding.UTF8.GetString(data, 0, bytes);
                MessageBox.Show(responses);
                if (responses == "로그인 되었습니다")
                {
                    //MessageBox.Show("responses");
                    NavigationService.Navigate(
                    new Uri("/EmpMainPage.xaml", UriKind.Relative));

                }

                //stream.Close();
                //client.Close();


            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
            }
        }
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {

            string pw = MyTextBoxpw.Password.ToUpper();
            string id = MyTextBoxid.Text.ToUpper();

            //CS_login(id, pw);
            // 로그인 성공하면 채팅창으로 넘어감 

            MyTextBoxid.Clear();
            MyTextBoxpw.Clear();
            //if (qqwwee == 1)
            //{
            //    NavigationService.Navigate(
            //    new Uri("/chatting.xaml", UriKind.Relative));
            //}
        }

        private void MyTextBoxid_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MyTextBoxid.Text == "ID")
            {
                MyTextBoxid.Clear();
            }
        }

        private void MyTextBoxpw_GotFocus(object sender, RoutedEventArgs e)
        {
            if (MyTextBoxpw.Password == "PassWord")
            {
                MyTextBoxpw.Clear();
            }
        }

        private void MyTextBoxid_LostFocus(object sender, RoutedEventArgs e)
        {
            if (MyTextBoxid.Text == "")
            {
                MyTextBoxid.Text = "ID";
            }
        }

        private void MyTextBoxpw_LostFocus(object sender, RoutedEventArgs e)
        {
            if (MyTextBoxpw.Password == "")
            {
                MyTextBoxpw.Password = "PassWord";
            }
        }

        //private void Btn_Signup_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService.Navigate(
        //        new Uri("/Sign_Up.xaml", UriKind.Relative));
        //}
    }



}
