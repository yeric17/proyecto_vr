using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform parenthBody = null;

    private void Update()
    {
        parenthBody.transform.position = transform.position;
    }
    public Transform GetPlayerTranform()
    {
        return parenthBody;
    }
}
