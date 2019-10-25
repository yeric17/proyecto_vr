using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonUI : Interactable
{
    public float _time = 0;
    public float delatyTime = 2f;

    [SerializeField] EventSystem eventSystem;

    private void Update() {


        if (interactStatus == InteractStatus.focus)
        {
            _time += Time.deltaTime;
            if (delatyTime <= _time)
            {
                var button = GetComponent<Button>();
                ExecuteEvents.Execute(button.gameObject, new BaseEventData(eventSystem), ExecuteEvents.submitHandler);
            }
        }
        else {
            _time = 0;
        }
        
    }
}
