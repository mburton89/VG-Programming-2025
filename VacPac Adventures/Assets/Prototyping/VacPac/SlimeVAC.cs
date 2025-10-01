using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeVAC : MonoBehaviour
{
    public float fuelAddAmount = 5f;

    public void getAbsorbed()
    {
        PlayerTemp.Instance.currentFuel += fuelAddAmount;

        if (PlayerTemp.Instance.currentFuel > PlayerTemp.Instance.maxFuel)
        {
            PlayerTemp.Instance.currentFuel = PlayerTemp.Instance.maxFuel;
        }
        Destroy(this.gameObject);
    }
}
