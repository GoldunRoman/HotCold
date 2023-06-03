using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RigidBodyInjector : MonoBehaviour
{
    private void Start()
    {
        Transform[] childrenObjectsArray = GetComponentsInChildren<Transform>();

        foreach (Transform child in childrenObjectsArray)
        {
            if (child.GetComponent<Rigidbody>() == null)
            {
                child.gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
