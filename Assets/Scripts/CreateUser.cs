using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using System.Security.Cryptography;
using System.Text;


public class CreateUser : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;
    public string savedUser;
    private string savedPassword;

    public void SaveUser(string sceneName)
    {
        if (File.Exists(Application.persistentDataPath + "/Users.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Users.dat";
            foreach (string line in File.ReadAllLines(path))
            {
                if (line == "Ux" + nameField.text)
                {
                    nameField.text = "User Already Exists";
                    return;
                }
            }
            savedUser = "\nUx" + nameField.text;
            savedPassword = "\nPx" + passwordField.text;
            string hashedPassword;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                hashedPassword = "\nPx" + GetHash(sha256Hash, passwordField.text);
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
            savedUser = "Ux" + nameField.text;
            savedPassword = "Px" + passwordField.text;
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
}