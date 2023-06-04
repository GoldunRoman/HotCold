using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    Gift _gift;
    [SerializeField] GameObject _physicsParrentObject;

    private void Start()
    {
        this.gameObject.SetActive(false);

        
    }
    
}
