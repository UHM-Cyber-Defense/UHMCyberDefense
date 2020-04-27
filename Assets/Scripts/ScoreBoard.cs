using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

//IN PROGRESS
//NOT IMPLEMENTED
public class ScoreBoard : MonoBehaviour {

    private PlayerController player1;
    string userScore;
    string tempScore;
    static int scoreVal;
    static int tempVal;
    public Text SBText;
    string password = "ThePasswordToDecryptAndEncryptTheFile";
    // Use this for initialization
    void Start () {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player1 = playerObject.GetComponent<PlayerController>();
        }
        if (player1 == null)
        {
            Debug.Log("Cannot find 'PlayerController' script");
        }
    }
	
    public void SaveScoreboard()
    {
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            FileEncrypt(path, password);
            File.Delete(path);
        }
        if (File.Exists(Application.persistentDataPath + "/Scoreboard.dat.aes"))
        {
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            FileDecrypt(path + ".aes", path, password);
            int i = 0;
            string tempScore;
            //Read file into string array
            string[] lines = File.ReadAllLines(path);
            userScore = player1.score.ToString() + " " + LoginPlayer.savedUser;
            Debug.Log("userScore is: " + userScore);
            tempVal = player1.score;
            //This foreach loops goes through and sorts our new
            //score into the scoreboard
            foreach (string line in lines)
            {
                //trimScore = line.Split(new char[] { ' ' });
                tempScore = Regex.Match(line, "\\d+").Value;
                scoreVal = Int32.Parse(tempScore);
                //Debug.Log("scoreVal is: " + scoreVal);
                if (tempVal > scoreVal)
                {
                    i++;
                    tempScore = line;
                    lines[i] = userScore;
                    //Debug.Log("lines[" + i + "] is: " + lines[i]);
                    userScore = tempScore;
                    tempVal = scoreVal;
                }
            }
            StreamWriter file = new StreamWriter(path);
            foreach (string line in lines)
            {
                file.WriteLine(line);
            }
            file.Close();
            //Debug.Log("userScore is: " + userScore);
            File.AppendAllText(path, userScore);
            FileEncrypt(path, password);
            File.Delete(path);
        }
        else
        {
            string path = Application.persistentDataPath
                       + "/Scoreboard.dat";
            StreamWriter file = File.CreateText(path);
            userScore = player1.score.ToString() + " " + LoginPlayer.savedUser;
            file.WriteLine(userScore);
            file.Close();
            FileEncrypt(path, password);
            File.Delete(path);
        }
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
