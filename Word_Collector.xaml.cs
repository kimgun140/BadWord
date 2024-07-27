using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace talktalk
{
    /// <summary>
    /// Word_Collector.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    public partial class Word_Collector : Page
    {
        jprotocol jprotocol = new jprotocol();
        //NetworkStream stream = Home.clients.GetStream(); //데이터 전송에 사용된 스트림
        string User_id123 = "";

        //public Word_Collector( string user_id)
        public Word_Collector()

        {
            InitializeComponent();



        }

        private void txtbox_send_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                //txtbox_chat.Text +=  jprotocol.nlpmachhine(txtbox_send.Text, this.User_id123);
                jprotocol.Word_Collector(txtbox_send.Text);
                txtbox_chat.Text += txtbox_send.Text +" : " + jprotocol.nlpmachhine(txtbox_send.Text);


            }
        }
    }
}
