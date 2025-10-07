using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacPackAlpha : MonoBehaviour
{
    public float absorbSpeed;

    public GameObject SlimeBullet;

    public float cooldown = 0;

    public float shootRate = 5;

    public float coolRate = 1;

    public bool imEating = false;

    public float fuelUseAmount = 2f;

    public static VacPackAlpha Instance;

    private RaycastHit _hit;

    public Transform spawnPoint;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (cooldown > 0)
        {
            {
                cooldown -= Time.deltaTime * coolRate;
            }
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Absorb();
            imEating = true;
        }
        else
        {
            imEating = false;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (cooldown <= 0)
            {
                Shoot();
            }
        }
    }


    void Absorb()
    {
        if (Physics.Raycast(transform.position, transform.forward, out _hit))
        {
            Debug.Log("Target Name: " + _hit.transform.name);

            if (_hit.transform.GetComponent<Slime>() != null)
            {
                Debug.Log("Target Present");
                _hit.transform.GetComponent<Slime>().GetPulled();
            }
        }
        Debug.Log("click");
    }
    
    void Shoot()
    {
        PlayerTemp.Instance.currentFuel -= fuelUseAmount;

        if (PlayerTemp.Instance.currentFuel < 0)
        {
            PlayerTemp.Instance.currentFuel = 0;
        }

        cooldown = shootRate;
        Instantiate(SlimeBullet, spawnPoint.position, transform.rotation, null);
        Debug.Log("pew");
    }

}
//Insert following lines into Slime

//under public class

//private bool obtained = false;
//public float attractionSpeed;
//public GameObject targetObject;


//public void GetPulled()
//{
//    if (targetObject != null)
//    {
//        Vector3 targetPosition = targetObject.transform.position;
//        transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, attractionSpeed * Time.deltaTime);
//    }
//}

//public void OnCollisionEnter(Collision collision)
//{
//    if (collision.gameObject.tag == "VacPac")
//    {
//        if (VacPackAlpha.Instance.imEating)
//        {
//            Obtain();
//            obtained = true;
//        }
//    }
//}

//private void Obtain()
//{
//    Destroy(gameObject);
//}



