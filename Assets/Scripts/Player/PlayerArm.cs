using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArm : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject ArmObject;



    private void Awake()
    {
        ArmObject.SetActive(false);
    }

    public void AnimPlay()
    {
        animator.Play("Anim_Arm",-1,0f);
    }
}
