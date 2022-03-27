using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NetTools;

namespace PortScanner
{
    class Utils
    {

        public static void PrintHelp()
        {
            Console.WriteLine("Usage: portscan.exe <hosts> <ports>\n");
            Console.WriteLine("Examples:");
            Console.WriteLine("   Scan a single IP - portscan.exe 192.168.1.10 443,80");
            Console.WriteLine("   Scan by CIDR - portscan.exe 192.168.1.0/24 443,80");
            Console.WriteLine("   Scan by Range - portscan.exe 192.168.1.1-10 443,80\n");
        }

        public static IEnumerable<IPAddress> GetIPAddressFromCIDR(string cidr)
        {
            var range = IPAddressRange.Parse(cidr);
            return range.AsEnumerable();
        }

        public static List<int> GetPorts(string strPorts)
        {
            var ports = strPorts.Split(',').Select(Int32.Parse).ToList();
            return ports;
        }
    }
}
