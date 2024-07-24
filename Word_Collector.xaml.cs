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
    public partial class Word_Collector : Page
    {
        NetworkStream stream = Home.clients.GetStream(); //데이터 전송에 사용된 스트림

        public Word_Collector()
        {
            InitializeComponent();
        }
        private void txtbox_send_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string send_message = "[고객] : " + txtbox_send.Text;
                if (!string.IsNullOrEmpty(send_message))
                {
                    byte[] data = null;
                    data = Encoding.UTF8.GetBytes(send_message);
                    stream.Write(data, 0, data.Length);
                    /*    txtbox_chat.Text += send_message;*/
                    txtbox_send.Clear();
                    txtbox_chat.ScrollToEnd();
                }
            }
        }
    }
}
