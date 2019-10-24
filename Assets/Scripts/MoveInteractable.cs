using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInteractable : Interactable
{

    [SerializeField] Rigidbody rigidbody = null;

    float timeToThrow = 1f;
    
    public float _time = 0;
    float distance = 0;
    float maxDistance = 12f;

    public float chargeForce = 0;
    
    public float maxThrowForce = 10f;

    private void Update()
    {
        MoveAction();
        ThrowController();
    }

    private void MoveAction()
    {
        if (GetStatus() == InteractStatus.focus && GetStatus() != InteractStatus.interact)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {

                SetStatus(InteractStatus.interact);
                distance = Vector3.Distance(interactor.transform.position, transform.position);
                PlayerRaycastSystem.onInteract += Move;
                rigidbody.isKinematic = true;
            }
        }

        if (GetStatus() != InteractStatus.interact)
        {
            PlayerRaycastSystem.onInteract -= Move;
            rigidbody.isKinematic = false;
        }

        if (GetStatus() == InteractStatus.interact)
        {
            if (Input.GetMouseButtonUp(1))
            {
                SetStatus(InteractStatus.none);
                SetInteractor(null);
            }
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
            {
                distance = Mathf.Clamp(distance + Input.GetAxis("Mouse ScrollWheel"), -maxDistance, maxDistance);
            }
        }
    }
    private void ThrowController()
    {
        if (GetStatus() == InteractStatus.interact)
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {

                _time += Time.deltaTime;
                if (timeToThrow < _time)
                {

                    ThrowAction(chargeForce);

                }
            }
            else
            {
                _time = 0;
            }
        }
    }

    private void ThrowAction(float force)
    {
        SetStatus(InteractStatus.focus);
        Ray ray = interactor.GetComponent<PlayerRaycastSystem>().ray;
        rigidbody.isKinematic = false;
        rigidbody.AddForce(ray.direction * 20f, ForceMode.Impulse);
    }

    public void Move(Ray ray)
    {

        float smoothSpeed = 6.8f;

        Vector3 finalPosition = (ray.direction * distance) + ray.origin;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed * Time.deltaTime);

        rigidbody.MovePosition(smoothPosition);

    }
}
