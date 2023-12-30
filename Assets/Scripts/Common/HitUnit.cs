using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitUnit : MonoBehaviour
{
    [SerializeField]
    private Transform hitPoint;

    public Transform GetHitPoint()
    {
        return hitPoint;
    }
}
