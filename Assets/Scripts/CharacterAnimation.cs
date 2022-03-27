using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (LevelComplete.instance.IsStageCompleted())
        {
            anim.SetBool("isCheering", true);
        }        
    }
}
