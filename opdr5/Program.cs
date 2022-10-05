using System.Net;
using System.Net.Sockets;

namespace Pretpark
{
    class Program
    {
        public static int getContentLen(string content) => content.Length;
        static TcpListener server = StartServer();
        const string OK = "200 OK", NotFound = "404 NOT FOUND";

        static void Main(string[] args)
        {


            while (!server.Pending())
            {
                Socket connection = server.AcceptSocket();
                Stream request = new NetworkStream(connection);
                StreamReader requestLezer = new StreamReader(request);

                string[]? regel1 = requestLezer.ReadLine()?.Split(" ");
                string? host = requestLezer.ReadLine();
                string? userAgent = requestLezer.ReadLine();

                if (regel1 == null) return;

                (string method, string uri, string httpversie) = (regel1[0], regel1[1], regel1[2]);

                if (method.ToLower() == "get")
                {
                    switch (uri)
                    {
                        case "/":
                            Get_Root(connection, userAgent != null ? userAgent : "unknown");
                            break;

                        case "/contact":
                            Get_Contact(connection);
                            break;
                        case "/mijnTeller":
                            Get_MijnTeller(connection);
                            break;
                        case "/add?a=3&b=4":
                            Get_addshit(connection);
                            break;
                        default:
                            ErrorPage(connection);
                            break;
                    }
                }

                System.Console.WriteLine(uri);
            }

        }

        private static void Get_addshit(Socket connection)
        {
            writeMessage(connection, "7", OK);
        }

        private static void Get_MijnTeller(Socket connection)
        {
            writeMessage(connection, File.ReadAllText("mijnteller.html"), OK, true);
        }

        public static void Get_Root(Socket conn, string userAgent)
        {
            var message = $"Welkom bij de website van Pretpark Den Haag!\n{userAgent}";
            writeMessage(conn, message, OK);
        }
        public static void Get_Contact(Socket conn)
        {
            var message = "Contact page!";
            writeMessage(conn, message, OK);
        }

        private static void ErrorPage(Socket conn)
        {
            var message = "Sorry Page not found " + NotFound;
            writeMessage(conn, message, NotFound);

        }

        static void writeMessage(Socket conn, string message, string statusCode, bool html = false)
        {
            var type = "text/plain";

            if (html) type = "text/html";

            conn.Send(System.Text.Encoding.ASCII.GetBytes($"HTTP/1.0 {statusCode}\r\nContent-Type: {type}\r\nContent-Length: {getContentLen(message)}\r\n\r\n{message}"));
        }



        public static TcpListener StartServer()
        {

            var port = 5000;

            TcpListener server = new TcpListener(IPAddress.Any, port);

            System.Console.WriteLine($"server running on http://localhost:{port}");

            server.Start();

            return server;
        }

        public static void checkContents(StreamReader requestReader)
        {
            string? line = requestReader.ReadLine();

            int contentLength = 0;

            while (!string.IsNullOrEmpty(line) && !requestReader.EndOfStream)
            {
                string[] stukjes = line.Split(":");
                (string header, string waarde) = (stukjes[0], stukjes[1]);

                if (header.ToLower() == "content-length")
                    contentLength = int.Parse(waarde);
                line = requestReader.ReadLine();
            }

            if (contentLength > 0)
            {
                char[] bytes = new char[(int)contentLength];
                requestReader.Read(bytes, 0, (int)contentLength);
            }
        }
    }
}
