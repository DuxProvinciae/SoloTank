using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Base_Controller
{
   
   [SerializeField] private GameObject TurretTarget;
   [SerializeField] private float DetectionRange =5f;

   private void Update()
   {
      RotateToTarget(TurretTarget.transform.position);
      if (CheckTargetDistance())
      {
         Fire();
      }
   }

   private bool CheckTargetDistance()
   {
      RaycastHit hit;
      if (Physics.Raycast(BulletSpawnPosition.position,BulletSpawnPosition.up, out hit,DetectionRange))
      {
         //Debug.DrawRay(BulletSpawnPosition.position, BulletSpawnPosition.up,Color.red, 1f);
         //if(hit.collider.gameObject.CompareTag("Player"))
         return true;
      }
      return false;
      
   }
}
