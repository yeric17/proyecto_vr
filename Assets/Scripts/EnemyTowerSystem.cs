using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerSystem : MonoBehaviour
{
   
    [SerializeField] Transform shotPoint;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject prefabBullet;

    public float detectDistance = 5f;
    public float rotateVelocity = .001f;
    public float delayShot = 2f;
    public float nextShot = 0;
    private float _time = 0;
    private bool negative = false;


    EnemyStatus enemyStatus = EnemyStatus.pasive;

    private void Start() {
        nextShot = delayShot;
    }
    private void Update() {
        _time += Time.deltaTime;
        nextShot -= Time.deltaTime;
        if (_time > 4)
        {
            negative = !negative;
            _time = 0;
        }
        RaycastEnemy();

    }
    private void FixedUpdate() {

        if (negative) { 
            transform.Rotate(new Vector3(0, rotateVelocity, 0));
        }
        else transform.Rotate(new Vector3(0, -rotateVelocity, 0));

        if (enemyStatus == EnemyStatus.active)
        {
            Instantiate(prefabBullet, shotPoint.position, shotPoint.rotation);
            nextShot = delayShot;
        }
    }


    private void RaycastEnemy() {
        RaycastHit hit;


        Ray ray = new Ray(shotPoint.transform.position, shotPoint.transform.forward);

        Physics.Raycast(ray, out hit, detectDistance, playerLayer.value);

        Debug.DrawRay(ray.origin, ray.direction * detectDistance, Color.red);

        if (hit.collider) {
            if (hit.collider.gameObject.tag == "Player")
            {
                enemyStatus = EnemyStatus.active;
            }
        }
        else
        {
            enemyStatus = EnemyStatus.pasive;
        }
    }

    public enum EnemyStatus { 
        pasive,
        active
    }
}
