using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Tasks.Int32ToIpAddress
{
	/// <summary>
	/// Класс для решения задачи int32 to IPv4
	/// </summary>
	/// <remarks>
	/// 
	/// <see cref="https://www.codewars.com/kata/52e88b39ffb6ac53a400022e">TASK</see>:
	/// Take the following IPv4 address: 128.32.10.1
	/// 
	/// This address has 4 octets where each octet is a single byte (or 8 bits).
	/// 
	/// 1st octet 128 has the binary representation: 10000000
	/// 2nd octet 32 has the binary representation: 00100000
	/// 3rd octet 10 has the binary representation: 00001010
	/// 4th octet 1 has the binary representation: 00000001
	/// So 128.32.10.1 == 10000000.00100000.00001010.00000001
	/// 
	/// Because the above IP address has 32 bits, we can represent it as the unsigned 32 bit number: 2149583361
	/// 
	/// Complete the function that takes an unsigned 32 bit number and returns a string representation of its IPv4 address.
	///
	/// EXAMPLES:
	/// 2149583361 == "128.32.10.1"
	/// 32         == "0.0.0.32"
	/// 0          == "0.0.0.0"
	/// </remarks>
	public class Int32ToIpAddress
	{
		private uint _ip;

		public Int32ToIpAddress(uint ip)
		{
			_ip = ip;
		}

		public string ConvertInt32ToIp()
		{
			/*
			 * Best solution
			 * return string.Join(".", new[] {24, 16, 8, 0}.Select(e => (_ip >> e) & 255));
			 */

			int partCount = 4;
			int partLength = 8;
			int ipLength = partCount * partLength;
			string byteString = Convert.ToString(_ip, 2);

			StringBuilder sb = new StringBuilder(byteString);
			if (ipLength - byteString.Length > 0)
			{
				sb.Insert(0, new string('0', ipLength - byteString.Length));
			}

			string intermediateString = sb.ToString();
			
			List<uint> list = new List<uint>();

			for (int i = 0; i < intermediateString.Length; i += partLength)
			{
				list.Add(Convert.ToUInt32(intermediateString.Substring(i, partLength), 2));
			}

			return list.Aggregate(string.Empty, (s, u) => s + $"{u}.").Trim('.');
		}
    }
}