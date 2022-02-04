using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Custom class to represent a client
/// </summary>
public abstract class ClientData
{
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public int ID { get; }

    public abstract void Action();

    // TODO: Complete class implementation
}
