using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Controller : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] protected Transform BulletSpawnPosition;
    [SerializeField] private Transform TurretHead;
    [SerializeField] private Transform temp;
    private bool IsAlreadyFring = false;
    int Loss = 10;
    //[]int life = 10;
    //public Text scoreText;
    
    protected void Fire()
    {
        if (!IsAlreadyFring)
        {
            IsAlreadyFring = true;
            StartCoroutine(fireDelay());
        }
        
    }

    IEnumerator fireDelay()
    {
        Instantiate(BulletPrefab, BulletSpawnPosition.position, BulletSpawnPosition.rotation);
        yield return new WaitForSeconds(2f);
        IsAlreadyFring = false;
    }
    

    protected void RotateToTarget(Vector3 targetPos)
    {
        temp.position = new Vector3(targetPos.x, TurretHead.transform.position.y, targetPos.z);
        TurretHead.transform.LookAt(temp);
    }
}
