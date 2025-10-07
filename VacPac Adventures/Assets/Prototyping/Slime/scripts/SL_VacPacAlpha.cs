using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SL_VacPacAlpha : MonoBehaviour
{
    public float absorbSpeed;

    public GameObject SlimeBullet;

    public float cooldown = 0;

    public float shootRate = 5;

    public float coolRate = 1;

    public static SL_VacPacAlpha Instance;

    private RaycastHit _hit;

    public Transform spawnPoint;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
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

                TargetSlime();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (cooldown <= 0)
                {
                    Shoot();
                }
            }
      }
    
    public void TargetSlime()
    { 
        //Renamed Absorb to TargetSlime
        if (Physics.Raycast(transform.position, transform.forward, out _hit))
        {
            Debug.Log("Target Name: " + _hit.transform.name);
                if (_hit.transform.GetComponent<Slime>() != null)
            {
                Debug.Log("Target Present");
                _hit.transform.GetComponent<Slime>();
            }
        } 
            Debug.Log("click");
        }

        void Shoot()
        {
            cooldown = shootRate;
            Instantiate(SlimeBullet, spawnPoint.position, transform.rotation, null);
            Debug.Log("pew");

        // ADDED BY KIAN vvvv

        shootRate -= SL_PlayerTemp.Instance.currentFuel;

        // ADDED BY KIAN ^^^^

        }
    
}
