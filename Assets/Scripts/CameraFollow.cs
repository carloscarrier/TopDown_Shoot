using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _Player;

    float _DistanceZ; 
    void Start()
    {
        _DistanceZ = gameObject.transform.position.z - _Player.position.z;
    }

    
    void Update()
    {
        Vector3 camPos = new Vector3(_Player.position.x, gameObject.transform.position.y, _Player.position.z + _DistanceZ);
        gameObject.transform.position = camPos;
    }
}
