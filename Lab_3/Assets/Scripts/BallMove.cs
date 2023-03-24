using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _ball;
    [SerializeField] private float _speed = 10f;
    private void Update()
    {
        Vector3 dir = Vector3.zero;
        if (Mathf.Abs(Input.acceleration.x) > 0.05f)
            dir.x = Input.acceleration.x;
        if (Mathf.Abs(Input.acceleration.y) > 0.05f)
            dir.z = Input.acceleration.y;
      
        
        if (dir.sqrMagnitude > 1)
                dir.Normalize();

        dir *= Time.deltaTime;

        if (Mathf.Abs(transform.position.x + dir.x * _speed) <= SizeObject(_floor).x/2 - SizeObject(_ball).x/1.9)
        {
         
            transform.Translate(new Vector3(dir.x, 0, 0) * _speed);
        }
        if (Mathf.Abs(transform.position.z + dir.z * _speed) <= SizeObject(_floor).z / 2 - SizeObject(_ball).z / 1.9)
        {
            transform.Translate(new Vector3(0,0, dir.z) * _speed);
        }
       
    }
    private Vector3 SizeObject(GameObject obj)
    {
        Vector3 a = obj.transform.localScale;
        return a;
    }

}
