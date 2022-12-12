using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Base_Controller
{
    [SerializeField] private float Speed = 0.01f;
    [SerializeField] private float BoostSpeed = 0.2f;
    [SerializeField] private float BoostDuration = 3f;
    [SerializeField] private float RotationSpeed = 0.01f;
    private bool IsBoosted = false;
    private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0f, 0f, Speed*Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0f, 0f, -Speed*Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0f, RotationSpeed*Time.deltaTime, 0f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0f, -RotationSpeed*Time.deltaTime, 0f);
            }
            AimToTarget();
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }

    private void AimToTarget()
    {
        Ray tempRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(tempRay, out hit)) 
        {
            RotateToTarget(hit.point);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BoostZone") && !IsBoosted)
        {
            IsBoosted = true;
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost()
    {
        float tempSpeed = Speed;
        Speed = 2f;
        yield return new WaitForSeconds(3f);
        Speed = tempSpeed;
        IsBoosted = false;
    }
            
}
        

