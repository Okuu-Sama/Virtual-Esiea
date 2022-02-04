using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Custom Script to keep track of the data entered by a user
/// </summary>
public class ClientInfoManager : MonoBehaviour
{
    //TODO: Make object attached to this script persistent.
    //The idea is to use it in the multiplayer scene to fill the data of the client

    private ClientData client;
    public InputField FirstNameField;
    public InputField LastNameField;
    public GameObject RoleSelection;
    public GameObject NameSelection;

    //Function fired by the UI button in the scene to confirm the guide role
    public void SelectGuideRole()
    {
        client = new Visitor();
        RoleSelection.SetActive(false);
        NameSelection.SetActive(true);
    }

    //Function fired by the UI button in the scene to confirm the visitor role
    public void SelectVisitorRole()
    {
        client = new Guide();
        RoleSelection.SetActive(false);
        NameSelection.SetActive(true);
    }

    //Function fired by the UI button in the scene to confirm the client information
    public void ConfirmClientInformation()
    {
        client.FirstName = FirstNameField.text;
        client.LastName = LastNameField.text;
        NameSelection.SetActive(false);
        this.enabled = false;
    }

    public ClientData RetrieveUserData()
    {
        return client;
    }

    private void Update()
    {
        if(!string.IsNullOrEmpty(FirstNameField.text) && !string.IsNullOrEmpty(LastNameField.text))
        {
            Button confirmationButton = GameObject.Find("ConfirmationButton").GetComponent<Button>();
            confirmationButton.interactable = true;
        }
    }
}
