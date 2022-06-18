﻿using System.Security.Cryptography;
using System.Text;

namespace ClimaWeather.Helpers {

    public static class HashHelper {

        public static byte[] GetHash(string inputString) {
            HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString) {
            var sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}