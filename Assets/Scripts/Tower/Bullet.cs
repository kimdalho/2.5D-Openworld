using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float speed;


    private void Update()
    {
        if(target == null)
        {
            Debug.Log("check");
            gameObject.SetActive(false);
        }
        else
        {
            //var distance = (target.transform.position - this.gameObject.transform.position).normalized;
            var direction = (target.transform.position - this.gameObject.transform.position).normalized;
            direction = transform.InverseTransformDirection(direction);
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == target)
        {
            
            gameObject.SetActive(false);
            target = null;
        }
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

}
