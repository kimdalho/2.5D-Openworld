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

    public Vector3 fixPoint;
    public Vector3 targetPoint;

    [SerializeField]
    private Animator animator;



    [SerializeField]
    private float range;

    void Start()
    {
        fixPoint = this.gameObject.transform.position;
        targetPoint = this.gameObject.transform.position;
        state = eMonsterType.idle;
        resetTime = Random.Range(2f, 5f);

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
                    Idle();
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

    private float deltime;
    private float resetTime;
    private void Idle()
    {
        
        if (targetPoint.x + targetPoint.z == transform.position.x + targetPoint.z ||
            deltime > resetTime)
        {
            resetTime = Random.Range(2f, 5f);

            deltime = 0f;
            float rndPointX = Random.Range(fixPoint.x, fixPoint.x + range);
            float rndPointZ = Random.Range(fixPoint.z, fixPoint.z + range);
            targetPoint = new Vector3(rndPointX, 4f, rndPointZ);

        }
        else
        {
            deltime += Time.deltaTime;
            Vector3 direction = (targetPoint - transform.position).normalized;
            direction = new Vector3(direction.x, 0, direction.z);

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.z);


            this.transform.Translate(direction * Time.deltaTime * speed);
        }

        


    }
}
//잘못 만든코드 분석 및 피드백 해야함
//if(transform.position == targetPoint)
//{
//    float rndPointX = Random.Range(fixPoint.x, fixPoint.x + range);
//    float rndPointZ = Random.Range(fixPoint.z, fixPoint.z + range);
//    targetPoint = new Vector3(rndPointX, fixPoint.y, rndPointZ);

//}
//else
//{
//    var distance = gameObject.transform.position - targetPoint;
//    Vector3 newPos = new Vector3(distance.x * Time.deltaTime * speed,
//                                 this.gameObject.transform.position.y,
//                                 distance.z * Time.deltaTime * speed);
//    gameObject.transform.position = newPos;
//}
