using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleManagerObserver : MonoBehaviour
{
    void Start()
    {
        transform.forward = Camera.main.transform.forward;
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = ObjectAngleManager.instance.objectSpriteLayerNumber;
    }

}
