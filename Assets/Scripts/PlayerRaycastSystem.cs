using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRaycastSystem : MonoBehaviour
{

    public Interactable interactObject { get; private set; }
    [SerializeField] Camera cameraPlayer = null;
    [SerializeField] float rayDistance = 2f;
    [SerializeField] LayerMask interactiveLayer = 0;

    public Image normalImage;
    public Image focusImage;
    public Ray ray { get; private set; }

    public delegate void InteracAction(Ray ray);
    public static event InteracAction onInteract;

    [SerializeField] Transform throwPoint;
    public Color rayColor = Color.green;

    void Update()
    {
        MakeRayCasting();
    }


    void MakeRayCasting()
    {
        RaycastHit hit;


        ray = new Ray(cameraPlayer.transform.position, cameraPlayer.transform.forward);

        Physics.Raycast(ray, out hit, rayDistance, interactiveLayer.value);

        Debug.DrawRay(ray.origin, ray.direction * rayDistance, rayColor);

        if (hit.collider)
        {
            if (!interactObject)
            {
                interactObject = hit.collider.gameObject.GetComponent<Interactable>();
            }
            if (interactObject)
            {
                if (interactObject.GetStatus() != InteractStatus.interact)
                {
                    interactObject.SetInteractor(GetComponent<Interactor>());
                    interactObject.SetStatus(InteractStatus.focus);
                    normalImage.enabled = false;
                    focusImage.enabled = true;
                }
            }
        }
        else
        {
            if (interactObject && interactObject.GetStatus() != InteractStatus.interact)
            {
                interactObject.SetStatus(InteractStatus.none);
                interactObject = null;
            }
            focusImage.enabled = false;
            normalImage.enabled = true;
        }


        if (interactObject)
        {
            InteractStatus currentStatus = interactObject.GetStatus();
            if (currentStatus == InteractStatus.interact)
            {
                onInteract(ray);
            }
        }
    }
}
