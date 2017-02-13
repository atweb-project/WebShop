using System;
using System.IO;
using System.Net.Sockets;

namespace WebShop.Infrastructure.Email
{
    internal class SmtpConnection
    {
        //variables
        private TcpClient socket;
        private StreamReader reader;
        private StreamWriter writer;
        private bool connected;

        /// <summary>
        /// Connection status.
        /// </summary>
        public bool Connected
        {
            get { return connected; }
        }

        /// <summary>
        /// Create a new connection.
        /// </summary>
        internal SmtpConnection()
        {
            socket = new TcpClient();
        }

        /// <summary>
        /// Open connection with specified host and default port.
        /// </summary>
        /// <param name="host">Host name to connect to.</param>
        internal void Open(string host)
        {
            Open(host, 25);
        }

        /// <summary>
        /// Open connection to host on port.
        /// </summary>
        /// <param name="host">Host name to connect to.</param>
        /// <param name="port">Port to connect to.</param>
        internal void Open(string host, int port)
        {
            if (host == null || host.Trim().Length == 0 || port <= 0)
            {
                throw new System.ArgumentException("Invalid Argument found.");
            }
            socket.Connect(host, port);
            reader = new StreamReader(socket.GetStream(), System.Text.Encoding.ASCII);
            writer = new StreamWriter(socket.GetStream(), System.Text.Encoding.ASCII);
            connected = true;
        }

        /// <summary>
        /// Close connection.
        /// </summary>
        internal void Close()
        {
            reader.Close();
            writer.Flush();
            writer.Close();
            reader = null;
            writer = null;
            socket.Close();
            connected = false;
        }

        /// <summary>
        /// Send a command to the server.
        /// </summary>
        /// <param name="cmd">Command to send.</param>
        internal void SendCommand(string cmd)
        {
            writer.WriteLine(cmd);
            writer.Flush();
        }

        /// <summary>
        /// Send data to the server. Used for sending attachments.
        /// </summary>
        /// <param name="buf">Data buffer.</param>
        /// <param name="start">Starting position in buffer.</param>
        /// <param name="length">Length to send.</param>
        internal void SendData(char[] buf, int start, int length)
        {
            writer.Write(buf, start, length);
        }

        /// <summary>
        /// Get the reply message from the server.
        /// </summary>
        /// <param name="reply">Text reply from server.</param>
        /// <param name="code">Status code from server.</param>
        internal void GetReply(out string reply, out int code)
        {
            String s;
            s = reader.ReadLine();
            reply = s;
            while (s != null && s.Substring(3, 1).Equals("-"))
            {
                s = reader.ReadLine();
                if (s != null)
                {
                    reply += s + "\r\n";
                }
            }
            code = reply == null ? -1 : Int32.Parse(reply.Substring(0, 3));
        }
    }
}
