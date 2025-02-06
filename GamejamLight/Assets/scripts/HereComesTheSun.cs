using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HereComesTheSun : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    void Update()
    {
        transform.position = new Vector3(transform.position.x + Time.deltaTime * moveSpeed, 0, 0);
    }
}
 