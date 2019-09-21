/*
 * Chug
 * 
 * Chug is an unconventional symmetric cipher in which the ciphertext is used to map a message into a key value that defines how the
 * ciphertext can be read in order to reveal the plaintext message. The only requirement of the cipher is that the size of the ciphertext
 * be equal to or larger than the size of the plaintext. Chug very closely resembles the One-time pad encryption technique, but differs
 * in mathematic operation and in the use of the key.
 * 
 * Author       :   https://github.com/sblmnl
 * Date Created :   2019-08-14 (YYYY-MM-DD)
 * License      :   MIT
 * 
 * [!* Disclaimer *!]
 * I am not a professional cryptographer, therefore it is advised that you do not rely on the security of this cipher for any
 * information. I am not liable for any damage caused by the use of cipher. Use this cipher at your own risk!
 */

using System;
using System.Text;


public static class Chug
{
    /// <summary>
    /// Generates a key that can be used to deduce the plaintext from the ciphertext
    /// </summary>
    /// <param name="plaintext">The set of data that you want to encrypt</param>
    /// <param name="ciphertext">The set of data that you want to combine with the plaintext to deduce a key</param>
    /// <param name="startIndex">The index at which to start reading from the ciphertext</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    /// <exception cref="ArgumentOutOfRangeException"/>
    /// <returns>Returns a <see cref="byte[]"/> containing a key</returns>
    public static byte[] Map(byte[] plaintext, byte[] ciphertext, int startIndex = 0)
    {
        if (plaintext == null)
        {
            throw new ArgumentNullException(nameof(plaintext), "The plaintext is null!");
        }

        if (ciphertext == null)
        {
            throw new ArgumentNullException(nameof(ciphertext), "The ciphertext is null!");
        }

        if (plaintext.Length > ciphertext.Length)
        {
            throw new ArgumentException("The ciphertext is smaller than the plaintext!", nameof(ciphertext));
        }

        if (startIndex < 0 || startIndex + plaintext.Length > ciphertext.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex), "Index is outside the bounds of the array!");
        }

        byte[] key = new byte[plaintext.Length + 4];

        // set the first 4 bytes of the key to the 32-bit value of the start index
        Buffer.BlockCopy(BitConverter.GetBytes(startIndex), 0, key, 0, 4);

        for (int i = 0; i < plaintext.Length; i++)
        {
            byte[] value = { (byte)((plaintext[i] - ciphertext[startIndex + i]) % 256) };
            Buffer.BlockCopy(value, 0, key, i + 4, 1);
        }

        return key;
    }

    /// <summary>
    /// Derives a message from the ciphertext using a key
    /// </summary>
    /// <param name="ciphertext">The data that you want to decrypt</param>
    /// <param name="key">An array of byte values that defines how to read a message from the ciphertext</param>
    /// <exception cref="ArgumentNullException"/>
    /// <exception cref="ArgumentException"/>
    /// <returns>Returns a <see cref="byte[]"/> containing the hidden message within the seed</returns>
    public static byte[] Morph(byte[] ciphertext, byte[] key)
    {
        if (ciphertext == null)
        {
            throw new ArgumentNullException(nameof(ciphertext), "The ciphertext is null!");
        }

        if (key == null)
        {
            throw new ArgumentNullException(nameof(key), "The key is null!");
        }

        // read the start index from first 4 bytes of the key
        int startIndex = BitConverter.ToInt32(key, 0);

        if (startIndex >= ciphertext.Length || key.Length - 4 > ciphertext.Length)
        {
            throw new ArgumentException("Invalid key!", nameof(key));
        }

        byte[] plaintext = new byte[key.Length - 4];

        for (int i = 0; i < key.Length - 4; i++)
        {
            byte[] value = { (byte)((ciphertext[i + startIndex] + key[i + 4]) % 256) };
            Buffer.BlockCopy(value, 0, plaintext, i, 1);
        }

        return plaintext;
    }

    /// <summary>
    /// Executes an example mapping and morphing operation in the console
    /// </summary>
    public static void Example()
    {
        byte[] ciphertext = Encoding.UTF8.GetBytes("I really want some grilled cheese!");
        byte[] plaintext = Encoding.UTF8.GetBytes("I secretly want steak");
        byte[] key = Map(plaintext, ciphertext);
        byte[] secret = Morph(ciphertext, key);

        Console.WriteLine("[mapping]");
        Console.WriteLine($"ciphertext\t:\t{BitConverter.ToString(ciphertext).Replace("-", "").ToLower()} (\"{Encoding.UTF8.GetString(ciphertext)}\")\r\n");
        Console.WriteLine($"plaintext\t:\t{BitConverter.ToString(plaintext).Replace("-", "").ToLower()} (\"{Encoding.UTF8.GetString(plaintext)}\")\r\n");
        Console.WriteLine($"key\t\t:\t{BitConverter.ToString(key).Replace("-", "").ToLower()}\r\n");

        Console.WriteLine("[morphing]");
        Console.WriteLine($"secret\t\t:\t{BitConverter.ToString(secret).Replace("-", "").ToLower()} (\"{Encoding.UTF8.GetString(secret)}\")");
    }
}