using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject prefab;
    [SerializeField] Collider spawnArea;
    public float delaySpawn = 2f;
    private float _time = 0;
    bool enableSpawn = true;


    private void Update()
    {
        _time += Time.deltaTime;
        if (enableSpawn && delaySpawn <= _time)
        {
            Instantiate(prefab, spawnArea.transform.position, spawnArea.transform.rotation);
            enableSpawn = false;
            _time = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        enableSpawn = false;
    }
    private void OnTriggerStay(Collider other)
    {
        enableSpawn = false;
    }
    private void OnTriggerExit(Collider other)
    {
        enableSpawn = true;
    }

}
