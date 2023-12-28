using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAngleManager : MonoBehaviour
{
    static public ObjectAngleManager instance;

    public Vector3 inclination;

    public readonly int objectSpriteLayerNumber = 1;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        
    }




}
