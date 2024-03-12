using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public void Fadeout()
    {
         animator.SetTrigger("FadeOut");
         Debug.Log("FadeOut Start");

    }
}
