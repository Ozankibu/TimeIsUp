using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool hasShovel = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shovel"))
        {
            hasShovel = true;
            Destroy(other.gameObject);
            Debug.Log("Shovel picked up!");
        }
    }

    private void Update()
    {
        if (hasShovel && Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (hit.collider.CompareTag("Dirt"))
                {
                    DigHole(hit.collider.gameObject);
                }
            }
        }
    }

    private void DigHole(GameObject hole)
    {
        foreach (Transform child in hole.transform)
        {
            if (child.gameObject.activeSelf)
            {
                child.gameObject.SetActive(false);
                break;
            }
        }
    }
}
