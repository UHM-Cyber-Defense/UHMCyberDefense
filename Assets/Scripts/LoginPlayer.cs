using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
<<<<<<< Updated upstream
=======
using System;
using System.Security.Cryptography;
using System.Text;
>>>>>>> Stashed changes

public class LoginPlayer : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;
    public Text errorText;
    public static string savedUser;
<<<<<<< Updated upstream
    private string userExists;
    private string savedPassword;
=======
>>>>>>> Stashed changes

    public void LoginUser(string sceneName)
    {
        if (File.Exists(Application.persistentDataPath + "/Users.dat"))
        {
            string path = Application.persistentDataPath
                       + "/Users.dat";
            int i = 0;
            //Read file into string array
            string[] lines = File.ReadAllLines(path);
            //Enumerate through array
            foreach (string line in lines)
            {
                i++;
                //Debug.Log(i);
                //Debug.Log(line);
                //Find User
                if (line == "Ux" + nameField.text)
                {
<<<<<<< Updated upstream
                    //Debug.Log(lines[i]);
                    //Check next line for password
                    //Current line is i - 1, next line is i
                    if (lines[i] == "Px" + passwordField.text)
=======
                    Debug.Log(lines[i]);
                    //Check next line for password
                    //Current line is i - 1, next line is i
                    string hashedPassword;
                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        hashedPassword = GetHash(sha256Hash, passwordField.text);
                        Debug.Log("Px" + hashedPassword);
                    }
                    if (lines[i] == "Px" + hashedPassword)
>>>>>>> Stashed changes
                    {
                        savedUser = nameField.text;
                        //Load Main Menu
                        //Defined in Unity SDK in Button Script
                        //attached to Enter Button
                        SceneManager.LoadScene(sceneName);
                    } else
                    {
                        errorText.text = "Invalid Password";
                        break;
                    }
                } 
            }
            //User not found
            errorText.text = "Invalid User";
        }
    }
<<<<<<< Updated upstream
=======

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
>>>>>>> Stashed changes
}
