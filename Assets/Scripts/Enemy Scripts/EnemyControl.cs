using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int _enemySpeed;
    public float _distancePlayer = 50f;

    GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(Vector3.Distance(this.transform.position, _player.transform.position) < _distancePlayer)
        {
        Vector3 localPosition = _player.transform.position - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * _enemySpeed, 
                            0f, 
                            localPosition.z * Time.deltaTime * _enemySpeed);
        }
    }
}
