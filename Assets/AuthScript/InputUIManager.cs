using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class InputUIManager : MonoBehaviour
{
    public static InputUIManager instance;
    [Header("Panel")]
    public GameObject SignupPanel;
    public GameObject SigninPanel;
    public  GameObject LoadingPanel;
    //public Root root;
    [Header("Signin Input Area")]
    public InputField s_emailInput;
    public InputField s_passwordInput;

    [Header("SignUp Input Area")]
    public InputField emailInput;
    public InputField passwordInput;
    private const string MatchEmailPattern =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";


    private const string MatchDOBpattern = "^[0-9]{1,2}\\-[0-9]{1,2}\\-[0-9]{4}$";
  

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void Next()
    {
        if (emailInput.text == "")
        {
            ConsoleManagerAuth.instance.ShowMessage("Email is Empty!");
            return;
        }
        if (!ValidateEmail(emailInput.text))
        {
            ConsoleManagerAuth.instance.ShowMessage("Email not Valid!");
            return;
        }
    }

    public void SignInUser()
    {

        if (s_emailInput.text == "")
        {
            ConsoleManagerAuth.instance.ShowMessage("Email is Empty!");
            return;
        }
        if (s_passwordInput.text == "")
        {
            ConsoleManagerAuth.instance.ShowMessage("Password is Empty!");
            return;
        }

        if (s_passwordInput.text.Length < 6)
        {
            ConsoleManagerAuth.instance.ShowMessage("Password is not 6 characters!");
            return;
        }
        LoadingPanel.SetActive(true);
        AuthManager.instance.LoginUser(s_emailInput.text.ToLower(), s_passwordInput.text);
    }

    public void CreateUser()
    {
        LoadingPanel.SetActive(true);
        SignUpPanelValidation();
        AuthManager.instance.CreateUser(emailInput.text.ToLower(), passwordInput.text);
    }

    private bool ValidateEmail(string email)
    {
        if (email != null)
            return Regex.IsMatch(email, MatchEmailPattern);
        else
            return false;
    }
    public void SignUpPanelValidation()
    {
        if (emailInput.text == "")
        {
            ConsoleManagerAuth.instance.ShowMessage("Email is Empty!");
            return;
        }

        if (passwordInput.text == "")
        {
            ConsoleManagerAuth.instance.ShowMessage("Password is Empty!");
            return;
        }
        if (!ValidateEmail(emailInput.text))
        {
            ConsoleManagerAuth.instance.ShowMessage("Email not Valid!");
            return;
        }
        SigninPanel.SetActive(false);
    }


}
