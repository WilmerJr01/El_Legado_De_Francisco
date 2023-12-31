using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoDialogo1 : MonoBehaviour
{
    private Transform theTransform; 
    public Vector2 Hrange = Vector2.zero;
    public Vector2 Vrange = Vector2.zero;

    void LateUpdate()
    {
        theTransform.position = new Vector3(
            Mathf.Clamp(transform.position.x, Vrange.x, Vrange.y),
            Mathf.Clamp(transform.position.y, Hrange.x, Hrange.y),
            transform.position.z
        );
    }

    // Start is called before the first frame update
    void Start()
    {
        theTransform = GetComponent<Transform>();
    }
}
