using System.Security.Cryptography;

namespace Shared.Helper;

public static class SecurePasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 10000;

    private static readonly HashAlgorithmName Algorthim = HashAlgorithmName.SHA512;

    public static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorthim, HashSize);
        return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
    }

    public static bool Verify(string password, string hashPassword)
    {
        var parts = hashPassword.Split('-');
        var hash = Convert.FromHexString(parts[0]);
        var salt = Convert.FromHexString(parts[1]);
        var inputHash =  Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorthim, HashSize);
        
        return CryptographicOperations.FixedTimeEquals(hash, inputHash);
    }
}