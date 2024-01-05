using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{

    [SerializeField]
    private int maxHp;
    [SerializeField]
    private int curHp;
    public bool isdead;
    public string teamName;



    private void Awake()
    {
        isdead = false;
        curHp = maxHp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Arm" && isdead  == false)
        {
            curHp -= 10;
            if(curHp <= 0)
            {
                isdead = true;
                curHp = 0;
            }

        }
    }
}
