using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.InteropServices;

public class CreateUser : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;
    public string savedUser;
    private string savedPassword;
    string password = "ThePasswordToDecryptAndEncryptTheFile";

    public void SaveUser(string sceneName)
    {
        if (File.Exists(Application.persistentDataPath + "/Users.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Users.dat";
            FileEncrypt(path, password);
            File.Delete(path);
        }
            if (File.Exists(Application.persistentDataPath + "/Users.dat.aes"))
        {
            string path = Application.persistentDataPath
                       + "/Users.dat";
            FileDecrypt(path + ".aes", path, password);
            foreach (string line in File.ReadAllLines(path))
            {
                if (line == nameField.text)
                {
                    nameField.text = "User Already Exists";
                    return;
                }
            }
            savedUser = "\n" + nameField.text;
            savedPassword = "\n" + passwordField.text;
            string hashedPassword;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hashedPassword = "\n" + GetHash(sha256Hash, passwordField.text);
                Debug.Log(hashedPassword);
            }
            File.AppendAllText(path, savedUser);
            File.AppendAllText(path, hashedPassword);
            //Debug.Log("User Data Saved");
            //Load Main Menu
            //Defined in Unity SDK in Button Script
            //attached to Save Button
            SceneManager.LoadScene(sceneName);
        } else
        {
            StreamWriter file = File.CreateText(Application.persistentDataPath + "/Users.dat");
            savedUser = nameField.text;
            savedPassword = passwordField.text;
            file.WriteLine(savedUser);
            file.Close();
            string path = Application.persistentDataPath
                       + "/Users.dat";
            string hashedPassword;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hashedPassword = GetHash(sha256Hash, savedPassword);
                Debug.Log(hashedPassword);
            }
            File.AppendAllText(path, hashedPassword);
            //Debug.Log("User Data Saved");
            //Load Main Menu
            FileEncrypt(path, password);
            File.Delete(path);
            SceneManager.LoadScene(sceneName);
        }
    }

    private static string GetHash(HashAlgorithm hashAlgorithm, string input)
    {

        // Convert the input string to a byte array and compute the hash.
        byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        var sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();
    }

    //  Call this function to remove the key from memory after use for security
    [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
    public static extern bool ZeroMemory(IntPtr Destination, int Length);

    /// <summary>
    /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
    /// </summary>
    /// <returns></returns>
    public static byte[] GenerateRandomSalt()
    {
        byte[] data = new byte[32];
        return data;
    }

    /// <summary>
    /// Encrypts a file from its path and a plain password.
    /// </summary>
    /// <param name="inputFile"></param>
    /// <param name="password"></param>
    private void FileEncrypt(string inputFile, string password)
    {
        //http://stackoverflow.com/questions/27645527/aes-encryption-on-large-files

        //generate random salt
        byte[] salt = GenerateRandomSalt();

        //create output file name
        FileStream fsCrypt = new FileStream(inputFile + ".aes", FileMode.Create);

        //convert password string to byte arrray
        byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

        //Set Rijndael symmetric encryption algorithm
        RijndaelManaged AES = new RijndaelManaged();
        AES.KeySize = 256;
        AES.BlockSize = 128;
        AES.Padding = PaddingMode.PKCS7;

        //http://stackoverflow.com/questions/2659214/why-do-i-need-to-use-the-rfc2898derivebytes-class-in-net-instead-of-directly
        //"What it does is repeatedly hash the user password along with the salt." High iteration counts.
        var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
        AES.Key = key.GetBytes(AES.KeySize / 8);
        AES.IV = key.GetBytes(AES.BlockSize / 8);

        //Cipher modes: http://security.stackexchange.com/questions/52665/which-is-the-best-cipher-mode-and-padding-mode-for-aes-encryption
        AES.Mode = CipherMode.CFB;

        // write salt to the begining of the output file, so in this case can be random every time
        fsCrypt.Write(salt, 0, salt.Length);

        CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

        FileStream fsIn = new FileStream(inputFile, FileMode.Open);

        //create a buffer (1mb) so only this amount will allocate in the memory and not the whole file
        byte[] buffer = new byte[1048576];
        int read;

        try
        {
            while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
            {
                //Application.DoEvents(); // -> for responsive GUI, using Task will be better!
                cs.Write(buffer, 0, read);
            }

            // Close up
            fsIn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            cs.Close();
            fsCrypt.Close();
        }
    }

    /// <summary>
    /// Decrypts an encrypted file with the FileEncrypt method through its path and the plain password.
    /// </summary>
    /// <param name="inputFile"></param>
    /// <param name="outputFile"></param>
    /// <param name="password"></param>
    private void FileDecrypt(string inputFile, string outputFile, string password)
    {
        byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
        byte[] salt = new byte[32];

        FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
        fsCrypt.Read(salt, 0, salt.Length);

        RijndaelManaged AES = new RijndaelManaged();
        AES.KeySize = 256;
        AES.BlockSize = 128;
        var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
        AES.Key = key.GetBytes(AES.KeySize / 8);
        AES.IV = key.GetBytes(AES.BlockSize / 8);
        AES.Padding = PaddingMode.PKCS7;
        AES.Mode = CipherMode.CFB;

        CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

        FileStream fsOut = new FileStream(outputFile, FileMode.Create);

        int read;
        byte[] buffer = new byte[1048576];

        try
        {
            while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
            {
                //Application.DoEvents();
                fsOut.Write(buffer, 0, read);
            }
        }
        catch (CryptographicException ex_CryptographicException)
        {
            Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        try
        {
            cs.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
        }
        finally
        {
            fsOut.Close();
            fsCrypt.Close();
        }
    }
}