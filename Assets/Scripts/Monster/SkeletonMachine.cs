using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eMonsterType
{
    idle = 0,
    follow = 1,
    attack = 2,
}

public class SkeletonMachine : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private bool isDead;

    [SerializeField]
    private eMonsterType state;

    [SerializeField]
    private GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        state = eMonsterType.idle;
        StartCoroutine(CoAi());   
    }


    private IEnumerator CoAi()
    {
        while(isDead == false)
        {
            switch(state)
            {
                case eMonsterType.follow:
                    Follow();
                    break;
                case eMonsterType.idle:
                    int test = -1;
                    float deltime = 0f;
                    deltime += Time.deltaTime;
                    while (3 > deltime)
                    {
                        test = Idle(test);
                        yield return null;
                    }
                    
                    
                    break;
                case eMonsterType.attack:
                    break;  
            }

            yield return null;
        }
    }

    private void Follow()
    {
        var dis = this.gameObject.transform.position - target.transform.position;
        transform.Translate(dis.normalized * Time.deltaTime * speed);
    }

    private int Idle(int old)
    {
        int rnd = -1;
        if(old == -1)
        {
             rnd = Random.Range(0, 5);
        }
        else
        {
            rnd = old;
        }
        

        switch(rnd)
        {
            case 0:
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                break;

            case 1:
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                break;

            case 2:
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                break;

            case 3:
                transform.Translate(Vector3.back * Time.deltaTime * speed);
                break;
            case 4:
                transform.Translate(Vector3.zero * Time.deltaTime * speed);
                break;

        }

        return rnd;
    }



}
