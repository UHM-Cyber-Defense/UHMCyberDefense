using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

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
            File.AppendAllText(path, savedUser);
            File.AppendAllText(path, savedPassword);
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
            File.AppendAllText(path, savedPassword);
            //Debug.Log("User Data Saved");
            //Load Main Menu
            SceneManager.LoadScene(sceneName);
        }
    }
}