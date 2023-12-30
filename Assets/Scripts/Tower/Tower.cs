using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eToweStateType
{
    Find = 0,
    ExistEnemy = 1,
    Shouting = 2,
    End = 3
}



public class Tower : MonoBehaviour
{
    [SerializeField]
    private GameObject ball;

    [SerializeField]
    private EnemyFinder enemyFinder;

    [SerializeField]
    private eToweStateType state;

    [SerializeField]
    private Transform spawnPoint;



    private void Awake()
    {
        state = eToweStateType.Find;
        ball.transform.position = spawnPoint.transform.position;
    }

    private void Update()
    {
        switch(state)
        {
            case eToweStateType.Find:
                Finding();
                break;
            case eToweStateType.ExistEnemy:
                ExistEnemy();
                break;
            case eToweStateType.Shouting:
                Shouting();
                break;
            case eToweStateType.End:
                End();
                break;

        }
    }

    private void Finding()
    {
        bool existMonstr = enemyFinder.GetExistEnemy();
        if(existMonstr)
        {
            state = eToweStateType.ExistEnemy;
            //enemyFinder.gameObject.SetActive(false);
        }
        else
        {
            enemyFinder.gameObject.SetActive(true);
            //
        }
    }

    private void ExistEnemy()
    {
        state = eToweStateType.Shouting;
    }
    private void Shouting()
    {
        GameObject target = enemyFinder.GetEnemyData();
        if(target == null)
        {
            state = eToweStateType.Find;
            enemyFinder.gameObject.SetActive(true);
            return;
        }
        else
        {
            ball.gameObject.SetActive(true);
            var targetHitpoint =  target.GetComponent<HitUnit>().GetHitPoint();
            ball.GetComponent<Bullet>().SetTarget(targetHitpoint.gameObject);
            state = eToweStateType.End;
        }

    }

    private void End()
    {
        if(ball.activeSelf != true)
        {
            ball.transform.position = spawnPoint.transform.position;
            state = eToweStateType.Find;
            enemyFinder.gameObject.SetActive(true);
        }
    }






}
