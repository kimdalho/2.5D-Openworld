using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private PlayerArm playerArm;
    [SerializeField]
    private Rigidbody _rigidbody;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        //Left
        if (Input.GetKey(KeyCode.A))
        {
            //_rigidbody.velocity = Vector3.left * Time.deltaTime * speed;
     
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //Right
        if (Input.GetKey(KeyCode.D))
        {
            //_rigidbody.velocity = Vector3.right * Time.deltaTime * speed;
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        //Up
        if (Input.GetKey(KeyCode.W))
        {
            //_rigidbody.velocity = Vector3.forward * Time.deltaTime * speed;
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //Down
        if (Input.GetKey(KeyCode.S))
        {
            //_rigidbody.velocity = Vector3.back * Time.deltaTime * speed;
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Attack");
            playerArm.AnimPlay();
        }
    }
}
