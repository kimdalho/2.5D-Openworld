using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject monsterPrefab;

    [SerializeField]
    private int spawnCount;
    [SerializeField]
    private float cooldown;

    private void Start()
    {
        StartCoroutine(SpawnMonster(1));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SpawnMonster());
        }
    }

    private IEnumerator SpawnMonster(int fixSpawnCount)
    {
        int curCount = 0;

        for(int i =0; i < fixSpawnCount; i++)
        {
            curCount++;
            var newMonster = Instantiate(monsterPrefab);
            newMonster.transform.position = this.gameObject.transform.position;
            yield return new WaitForSeconds(cooldown);
        }
    }


    private IEnumerator SpawnMonster()
    {
        int curCount = 0;
        while(spawnCount > curCount)
        {
            curCount++;
            var newMonster = Instantiate(monsterPrefab);
            newMonster.transform.position = this.gameObject.transform.position;
            yield return new WaitForSeconds(cooldown);
        }    
    }





}
