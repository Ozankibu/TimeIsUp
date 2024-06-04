using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public GameObject device;
    public GameObject canvas;
    public bool deviceActive = false;
    public bool canvasActive = false;

    private void Start()
    {
        deviceActive = false;
        canvasActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }

        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (deviceActive == false)
            {
                canvas.SetActive(true);
                device.SetActive(true);
                deviceActive= true;
                canvasActive= true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (deviceActive == true)
            {
                canvas.SetActive(false);
                device.SetActive(false);
                deviceActive= false;
                canvasActive= false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}