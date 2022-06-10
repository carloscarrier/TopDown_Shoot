using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletGravity : MonoBehaviour
{
    //public GameObject _Enemy;
    public Rigidbody _rigThis;
    
    void FixedUpdate()
    {
        Target[] _targets = FindObjectsOfType<Target>();

        foreach (Target targt in _targets)
        {
            if(Vector3.Distance(this.transform.position, targt.transform.position) <= 25)
            {
                Attract(targt);
            }
        }
        DestroyThis();
    }

    void Attract (Target objAttract)
    {
        Rigidbody _rbAttract = objAttract._targetRig;

        Vector3 direction = _rigThis.position - _rbAttract.position;
        float distance = direction.magnitude;

        float forceMagnetude = (_rigThis.mass * _rbAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnetude;

        _rbAttract.AddForce(force);
    }

    void DestroyThis()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Paredes"))
        {
            Destroy(gameObject);
        }
    }

}
