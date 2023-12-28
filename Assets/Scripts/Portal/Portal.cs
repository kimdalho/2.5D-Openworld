using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private Portal linkPortal;


    private void Move(GameObject player)
    {
        player.gameObject.transform.parent.position = linkPortal.transform.position;
    }


    private void OnTriggerStay(Collider other)
    {
        if (linkPortal == null)
            return;

        if(other.gameObject.name == "PlayerPhysic")
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Move(other.gameObject);
            }
        }
    }


}
