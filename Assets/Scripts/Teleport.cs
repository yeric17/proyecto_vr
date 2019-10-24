using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Interactable
{

    [SerializeField] Transform spawnPoint = null;
    private void Update()
    {
        if (GetStatus() == InteractStatus.focus && GetStatus() != InteractStatus.interact)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                SetStatus(InteractStatus.interact);
                PlayerRaycastSystem.onInteract += MovePlayer;
            }
        }
    }

    public void MovePlayer(Ray ray)
    {
        if (interactor)
        {
            Transform playerTransform = interactor.GetPlayerTranform();
            Vector3 newPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
            playerTransform.position = newPosition;
            playerTransform.parent = transform;
            SetStatus(InteractStatus.none);
            PlayerRaycastSystem.onInteract -= MovePlayer;
        }
    }
}
