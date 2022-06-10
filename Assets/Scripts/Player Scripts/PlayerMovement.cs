using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _speed = 5f;
    public float _timeRotation = 10.0f;
    
    public Rigidbody rig;

    Vector3 movement;
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        //Vector3 direcionalMove = movement.normalized * _speed * Time.deltaTime;

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.cyan);
        
        if(Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
          //Vector3 targetPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _timeRotation);
        }
        //rig.AddForce(direcionalMove, ForceMode.VelocityChange);
    }

    void FixedUpdate()
    {
        rig.MovePosition(rig.position + movement * _speed * Time.fixedDeltaTime);
        
    }
}
