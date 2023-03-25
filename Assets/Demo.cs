using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyUI.Toast;

public class Demo : MonoBehaviour
{
    public void Print_Message (string message)
    {
        Debug.Log (message);
        PlayerMovement.instance.Right();
    }
}
