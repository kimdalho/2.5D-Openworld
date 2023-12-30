using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject target;
    public float speed;

    private void Update()
    {
        var direction = (target.transform.position - this.gameObject.transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * speed);
    }
}
