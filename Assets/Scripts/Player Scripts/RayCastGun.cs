using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastGun : MonoBehaviour
{
    [Header("Propriedades do Rifle")]
    //Propriedades do Rifle;
    public bool _isActiveR = true;

    public GameObject _fireRPoint;
    //public GameObject _impactEffect;
    //public ParticleSystem _fireLight;

    public float _damage = 10f;
    public float _range = 100f;
    public float _tempoEntreTiros = 0.1f;
    public float _impactForce = 40f;

    private float _ShootRate = 0f;

    LineRenderer _lineRender;

    void Start()
    {
        _lineRender = this.GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        if (_isActiveR)
        {
            if ((Time.time >= _ShootRate) && (Input.GetKey(KeyCode.Mouse0)))
            {
                _lineRender.enabled = true;
                RifleShooting();
                _ShootRate = Time.time + _tempoEntreTiros;
            }
            else
            {
                _lineRender.enabled = false;
            }
        }
    }

    void RifleShooting()
    {
        RaycastHit hit;

        //_fireLight.Play();

        if (Physics.Raycast(_fireRPoint.transform.position, _fireRPoint.transform.forward,
                           out hit, _range))
        {
            Target target = hit.transform.GetComponent<Target>();

            _lineRender.SetPosition(0, _fireRPoint.transform.position);
            _lineRender.SetPosition(1, hit.point);

            if (target != null)
            {
                target.TakeDamage(_damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * _impactForce);
            }

            //GameObject impactGO = Instantiate(_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            //Destroy(impactGO, 1f);
            //Debug.Log(hit.transform.name);
        }
    }
}
