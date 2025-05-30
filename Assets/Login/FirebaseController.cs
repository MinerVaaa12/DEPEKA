using UnityEngine;
using TMPro;

public class FirebaseController : MonoBehaviour
{
    public GameObject loginPanel, signUpPanel, notificationPanel;
    public TMP_InputField loginEmail, loginPassword, signUpEmail, signUpPassword;
    public TMP_Text notifMessageText;

    public void OpenLoginPanel()
    {
        ShowNotificationMessage("Fields Empty, Input all the requirement");
        loginPanel.SetActive(true);
        signUpPanel.SetActive(false);
    }

    public void OpenSignUpPanel()
    {
        ShowNotificationMessage("Fields Empty, Input all the requirement");
        loginPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    public void LoginUser()
    {
        if (string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
        {
            return;
        }
    }

    public void SignUpUser()
    {
        if (string.IsNullOrEmpty(signUpEmail.text) && string.IsNullOrEmpty(signUpPassword.text))
        {
            return;
        }
    }

    private void ShowNotificationMessage(string message)
    {
        notifMessageText.text = message;
        notificationPanel.SetActive(true);
    }

    public void CloseNotifPanel()
    {
        notifMessageText.text = "";
        notificationPanel.SetActive(false);
    }
}
