using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Navigation;

namespace talktalk
{
    internal class jprotocol
    {
        int Buffersize = 1024;
        byte msg;
        int len;

        public int Login(string ID, string PW)
        {
            var data = new
            {
                protocol = "로그인요청",
                id = ID,
                pw = PW,

            };
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

            NetworkStream stream = Home.clients.GetStream();
            stream.Write(buffer, 0, buffer.Length);
            // 읽기 
            byte[] recv_data = new byte[1024];
            int databyte = stream.Read(recv_data, 0, recv_data.Length);
            string readdata = Encoding.UTF8.GetString(recv_data, 0, databyte);
            //var receivedData = JsonConvert.serializeObject<string>(readdata);
            var receivedData = JObject.Parse(readdata);
            if (receivedData["protocol"].ToString() == "로그인완료")
            {
                return 1;
            }
            else // 로그인 실패 
            {
                return 0;
            }

        }
        public static int User_Signup(string ID, string PW)
        {
            var data = new
            {
                protocol = "회원가입요청",
                id = ID,
                pw = PW,

            };
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

            NetworkStream stream = Home.clients.GetStream();
            stream.Write(buffer, 0, buffer.Length);
            // 읽기 
            byte[] recv_data = new byte[2000];
            int databyte = stream.Read(recv_data, 0, recv_data.Length);
            string readdata = Encoding.UTF8.GetString(recv_data, 0, databyte);
            //var receivedData = JsonConvert.serializeObject<string>(readdata);
            var receivedData = JObject.Parse(readdata);

            if (receivedData["protocol"].ToString() == "회원가입완료")
            {

            return 1;
            }
            else
            {
                return 0;
            }

            
        }
        public static int Word_Collector( string SentenceData)
        {
            var data = new
            {
                protocol = "단어수집",
                data_collect = SentenceData

            };
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);

            NetworkStream stream = Home.clients.GetStream();
            stream.Write(buffer, 0, buffer.Length);//슈웅


            return 1;
        }
        public static string nlpmachhine(string sentencedata, string User_id)
        {
            //TcpClient pyclients = new TcpClient("localhost", 12345); //연결객체

            var data = new
            {
                protocol = "단어수집",
                id = User_id,
                data_collect = sentencedata

            };
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            NetworkStream pystream = Home.pyclients.GetStream();
            pystream.Write(buffer, 0, buffer.Length);//슈웅




            //받기 
            byte[] recv_data = new byte[2000];
            int databyte = pystream.Read(recv_data, 0, recv_data.Length);
            string readdata = Encoding.UTF8.GetString(recv_data, 0, databyte);
            //var receivedData = JsonConvert.serializeObject<string>(readdata);
            var receivedData = JObject.Parse(readdata);
            return receivedData["data_collect"].ToString();
            //receivedData[""];

        }
        public static string nlpmachhine(string sentencedata)
        {
            //TcpClient pyclients = new TcpClient("localhost", 12345); //연결객체

            var data = new
            {
                protocol = "단어수집",
                //id = User_id,
                data_collect = sentencedata

            };
            string jsonData = JsonConvert.SerializeObject(data);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
            NetworkStream pystream = Home.pyclients.GetStream();
            pystream.Write(buffer, 0, buffer.Length);//슈웅




            //받기 
            byte[] recv_data = new byte[2000];
            int databyte = pystream.Read(recv_data, 0, recv_data.Length);
            string readdata = Encoding.UTF8.GetString(recv_data, 0, databyte);
            //var receivedData = JsonConvert.serializeObject<string>(readdata);
            var receivedData = JObject.Parse(readdata);
            return receivedData["data_collect"].ToString();
            //receivedData[""];

        }

    }
}
