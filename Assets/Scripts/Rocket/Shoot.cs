using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bullets;
 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GameObject bullet = Instantiate(_bullet, transform.Chil);
            //bullet.GetComponent<Rigidbody2D>().rotation = -90;
        }
    }
}
