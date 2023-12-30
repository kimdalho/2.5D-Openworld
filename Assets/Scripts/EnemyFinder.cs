using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField]
    private string targetName;
    [SerializeField]
    private bool existEnemy;
    [SerializeField]
    private GameObject targetObj;

    public bool GetExistEnemy()
    {
        return existEnemy;
    }

    public GameObject GetEnemyData()
    {
        return targetObj;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == targetName)
        {
            existEnemy = true;
            targetObj = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (existEnemy == false)
            return;
        
        if(other.transform.parent.gameObject.name == targetName)
        {
            existEnemy = false;
            targetObj = null;
        }
      
    }


}
