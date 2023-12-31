using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProcurementSystem.Common.Infrastructure;

public class PasswordEncryptor
{
    public static string Encrpt(string passwod)
    {
        using var md5= MD5.Create();
        byte[] inputBytes=Encoding.ASCII.GetBytes(passwod);
        byte[] hashBytes=md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}
