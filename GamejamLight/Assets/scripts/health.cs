using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class health : MonoBehaviour
{
    bool dam = false;
    [SerializeField]float hp = 100;
    void Update()
    {
        if (dam)
        {
            hp -= Time.deltaTime * 20;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            dam = true;
        }
        else if (collision.gameObject.tag == "Death")
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            dam = false;
        }
    }
}
