using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerInteraction1 : MonoBehaviour
{
    private bool hasShovel = false;
    public Camera cameraUsed;
    public float delay = 3;

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
            Debug.Log("Attempting to dig...");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, cameraUsed.transform.forward, out hit, 2f))
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Hole"))
                {
                    Debug.Log("Hole detected: " + hit.collider.gameObject.name);
                    DigHole(hit.collider.gameObject);
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Gun"))
                {
                    Destroy(hit.collider.gameObject);
                    StartCoroutine(LoadLevelAfterDelay(delay));


                }

                else
                {
                    Debug.Log("Raycast hit but not a hole: " + hit.collider.gameObject.name);
                }
            }
            else
            {
                Debug.Log("Raycast did not hit anything.");
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
                Debug.Log("Dug one stage of the hole: " + child.gameObject.name);
                break;
            }
        }
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }

}
