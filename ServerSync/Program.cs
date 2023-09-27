using System.Net.Sockets;
using System.Net;
using System.Text;

class Program
{
    static string address = "127.0.0.1";
    static int port = 8080;             
    
    public static void Main(string[] args)
    { 
        IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
        IPEndPoint? remoteEndPoint = null;
        UdpClient listener = new UdpClient(ipPoint);

        try
        {
            Console.WriteLine("Server started! Waiting for connection...");

            while (true)
            {

                byte[] data = listener.Receive(ref remoteEndPoint);

                string msg = Encoding.Unicode.GetString(data);
                Console.WriteLine($"{DateTime.Now.ToShortTimeString()}: {msg} from {remoteEndPoint}");

                string message = "Message was sent!";
                data = Encoding.Unicode.GetBytes(message);
                listener.Send(data, data.Length, remoteEndPoint);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            listener.Close();
        }
    }
}