using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelman : MonoBehaviour
{
    [SerializeField] GameObject[] levels = new GameObject[6];
    [SerializeField] float[] levelLenght = new float[6];
    float posindex;
    private void Start()
    {
        int levelIndex = Random.Range(0, levels.Length);
        GameObject level = Instantiate(levels[levelIndex]);
        level.transform.position = Vector3.zero;
        posindex += levelLenght[levelIndex];
        levelIndex = Random.Range(0, levels.Length);
        level = Instantiate(levels[levelIndex]);
        level.transform.position = Vector3.right * posindex;
        transform.position = Vector3.right * posindex;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            int levelIndex = Random.Range(0, levels.Length);
            GameObject level = Instantiate(levels[levelIndex]);
            level.transform.position = Vector3.right * posindex;
            posindex += levelLenght[levelIndex];
            transform.position = Vector3.right * posindex;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            int levelIndex = Random.Range(0, levels.Length);
            GameObject level = Instantiate(levels[levelIndex]);
            level.transform.position = Vector3.right * posindex;
            posindex += levelLenght[levelIndex];
            transform.position = Vector3.right * posindex;

        }
    }
}
