using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class LoginPlayer : MonoBehaviour {

    public InputField nameField;
    public InputField passwordField;
    public Text errorText;
    public static string savedUser;
    private string userExists;
    private string savedPassword;

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
                    //Debug.Log(lines[i]);
                    //Check next line for password
                    //Current line is i - 1, next line is i
                    if (lines[i] == "Px" + passwordField.text)
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
}
