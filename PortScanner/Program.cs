using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace PortScanner
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var targets = Utils.GetIPAddressFromCIDR(args[0]);
                var ports = Utils.GetPorts(args[1]);

                foreach (var target in targets)
                {
                    var scanner = new Scanner(target);

                    foreach (int port in ports)
                    {
                        var result = scanner.ScanPort(port);
                        if (result.Result == "OPEN")
                        {
                            Console.WriteLine($"{target}:{port} | {result.Result}", ConsoleColor.Green);
                        }
                    }

                }
            }
            catch
            {
                Utils.PrintHelp();
            }


        }
    }
}
