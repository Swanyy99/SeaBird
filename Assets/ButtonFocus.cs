using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonFocus : MonoBehaviour
{
    public EventSystem system;

    private void OnEnable()
    {
        system.SetSelectedGameObject(gameObject);
    }

}
