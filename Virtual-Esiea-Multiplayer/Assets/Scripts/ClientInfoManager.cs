using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoManager : MonoBehaviour
{

    private ClientData client;
    public InputField FirstNameField;
    public InputField LastNameField;
    public GameObject RoleSelection;
    public GameObject NameSelection;

    public void SelectGuideRole()
    {
        client = new Visitor();
        RoleSelection.SetActive(false);
        NameSelection.SetActive(true);
    }

    public void SelectVisitorRole()
    {
        client = new Guide();
        RoleSelection.SetActive(false);
        NameSelection.SetActive(true);
    }

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
