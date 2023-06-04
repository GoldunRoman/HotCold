using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftAllocation : MonoBehaviour
{
    [SerializeField] GameObject _physicsParrentObject;
    void Awake()
    {
        _physicsParrentObject = this.gameObject;

        int randomElement = Random.Range(0, _physicsParrentObject.transform.childCount - 1);

        //Only physics items can be the Gift so we`re searching this component in physics objects
        for (int i = 0; i < _physicsParrentObject.transform.childCount; i++)
        {
            if (i == randomElement)
            {
                GameObject item = _physicsParrentObject.transform.GetChild(i).gameObject;
                item.AddComponent<Gift>();
                break;
            }
            else continue;
        }
    }
}
