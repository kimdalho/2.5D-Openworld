using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitUnit : MonoBehaviour
{
    [SerializeField]
    private Transform hitPoint;
    [SerializeField]
    private Color hitColor;
    private Color baseColor = Color.white;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private float count = 2f;

    public Transform GetHitPoint()
    {
        return hitPoint;
    }

    private IEnumerator CoHitAnimPlay()
    {
        Debug.Log("check");
        float deltime = 0f;
        
        sprite.material.color = hitColor;
        while(deltime < count)
        {
            deltime += Time.deltaTime;
            yield return null;
        }
        sprite.material.color = baseColor;

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Arm")
        {
            StartCoroutine(CoHitAnimPlay());
        }
    }
}
