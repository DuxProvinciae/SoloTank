using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private float speed = 2f;

   private void Start()
   {
      GetComponent<Rigidbody>().velocity = transform.up * speed;
   }

   private void OnCollisionEnter(Collision collision)
   {
      
      Destroy(gameObject);
   }
}
