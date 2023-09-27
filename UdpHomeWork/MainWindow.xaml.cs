using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
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

namespace UdpHomeWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string address = string.Empty;
        static int port = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            address = ipTxtBox.Text;
            port = int.Parse(portTxtBox.Text);
            ClientSync();
        }
        private void ClientSync()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            EndPoint remoteIpPoint = new IPEndPoint(IPAddress.Any, 0);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {

                string message = "";
                while (message != messageTxtBox.Text)
                {
                    message = messageTxtBox.Text;
                    byte[] data = Encoding.Unicode.GetBytes(message);

                    socket.SendTo(data, ipPoint);

                    int bytes = 0;
                    string response = "";
                    data = new byte[1024]; 
                    do
                    {
                        bytes = socket.ReceiveFrom(data, ref remoteIpPoint);
                        response += Encoding.Unicode.GetString(data, 0, bytes);
                    } while (socket.Available > 1);

                    //MessageBox.Show("server response: " + response);
                }

                socket.Shutdown(SocketShutdown.Both);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                socket.Close();
            }
        }
    }
}
