using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeVAC : MonoBehaviour
{
    public void getAbsorbed()
    {
        Destroy(this.gameObject);
    }
}
