using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner
{
    public class Scanner
    {
        // Creating a property of type IPAdress called target
        public IPAddress target { get; set; }

        // Adding a constructor to create the target when the scanner class is instantiated
        public Scanner(IPAddress target)
        {
            this.target = target;  // assign the supplied target to the target property
        }

        // Create method to scan a supplied TCP port
        public async Task<string> ScanPort(int port)
        {
            var client = new TcpClient();
            var cancellationToken = new CancellationTokenSource();
            string result = null;
            cancellationToken.CancelAfter(500);

            try
            {
                await client.ConnectAsync(target, port, cancellationToken.Token);
                result = "OPEN";
            }
            catch
            {
                result = "CLOSED";
            }
            finally
            {
                client.Dispose();
            }

            return result;
        }
    }
}
