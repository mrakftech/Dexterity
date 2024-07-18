using System.Security.Cryptography;
using System.Text;

namespace Shared.Helper;

public static class CryptographyHelper
{
    public static string GetUniqueKey(int size=10)
    {
        var chars = new char[26];
        string a;
        a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        chars = a.ToCharArray();
        var data = new byte[1];
        var crypto = RandomNumberGenerator.Create();
        crypto.GetNonZeroBytes(data);
        data = new byte[size];
        crypto.GetNonZeroBytes(data);
        var result = new StringBuilder(size);
        foreach (var b in data) result.Append(chars[b % (chars.Length - 1)]);
        return result.ToString();
    }
    
    public static string GetUniqueSeqKey(int size=6)
    {
        var chars = new char[11];
        string a;
        a = "A1234567890";
        chars = a.ToCharArray();
        var data = new byte[1];
        var crypto = RandomNumberGenerator.Create();
        crypto.GetNonZeroBytes(data);
        data = new byte[size];
        crypto.GetNonZeroBytes(data);
        var result = new StringBuilder(size);
        foreach (var b in data) result.Append(chars[b % (chars.Length - 1)]);
        return result.ToString();
    }
}