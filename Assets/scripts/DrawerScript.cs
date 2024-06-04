using UnityEngine;

public class DrawerScript : MonoBehaviour, IInteractable
{
    public bool isOpen = false;
    public void Interact()
    {
        if (isOpen == false)
        {
            Debug.Log("1");
            GetComponent<Animator>().SetTrigger("Run");
            isOpen = true;
        }

        else if (isOpen == true)
        {
            GetComponent<Animator>().SetTrigger("Run2");
            isOpen=false;
        }
    }
}