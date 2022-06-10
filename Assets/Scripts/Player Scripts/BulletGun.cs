using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [Header("Propriedades do Tiro Gravitico")]
    //Propriedades das Granadas;
    public bool _isActive = false; //responsavel pelo ativamento ou nao 

    public GameObject _bulletPrefab;
    public Transform _firePoint;

    public float _damageG = 25f;
    public float _bulletSpeed = 50f;
    public float _tempoEntreTirosG = 0.5f; //tempo para que aconteçaum novo disparo;
    public float _timeToDestroy = 2f;

    private float _timeStamp = 0f;

    void FixedUpdate()
    {
        if (_isActive)
        {
            if ((Time.time >= _timeStamp) && (Input.GetKey(KeyCode.Mouse1)))
            {
                GranadeShooting();
                _timeStamp = Time.time + _tempoEntreTirosG;
            }
        }
    }

    void GranadeShooting()
    {
        GameObject bulletGranade = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        //Adiciona velocidade a bullet;
        bulletGranade.GetComponent<Rigidbody>().velocity = bulletGranade.transform.forward * _bulletSpeed;
        Destroy(bulletGranade, _timeToDestroy);
    }
}
