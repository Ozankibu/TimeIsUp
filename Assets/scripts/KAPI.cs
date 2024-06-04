using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAPI : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("1");
        GetComponent<Animator>().SetBool("isopen", true);

    }
   
}
