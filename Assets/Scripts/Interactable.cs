using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    [SerializeField] protected InteractStatus interactStatus = InteractStatus.none;

    public static InteractStatus SNone = InteractStatus.none;
    public static InteractStatus SFocus = InteractStatus.focus;
    public static InteractStatus SInteract = InteractStatus.interact;



    public Interactor interactor { get; private set; }
    public void SetStatus(InteractStatus i)
    {
        interactStatus = i;
    }

    public InteractStatus GetStatus()
    {
        return interactStatus;
    }

    public void SetInteractor(Interactor i)
    {
        interactor = i;
    }
}


public enum InteractStatus
{
    none,
    focus,
    interact
}
