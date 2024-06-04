using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAPI : MonoBehaviour, IInteractable
{
    public bool isopen = false;
    public void Interact()
    {
        if (isopen == false)
        {
            GetComponent<Animator>().SetTrigger("isopen");
            isopen = true;
        }
        else if (isopen == true)
        {
            GetComponent<Animator>().SetTrigger("close");
            isopen = false;
        }

    }
   
}
