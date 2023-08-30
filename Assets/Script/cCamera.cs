using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cCamera : MonoBehaviour

{
    public Transform targert;
    public float suavizacao = 0.1f;
    public Vector3 offset = new Vector3 (0.3f, 0.15f, 0);

    // Start is called before the first frame update
    void Start()
    {
        targert = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosicion = new Vector3(targert.position.x, targert.position.y, -1f);
        Vector3 suavizacaoPosicion = Vector3.Lerp(transform.position, startPosicion, suavizacao);
        transform.position = suavizacaoPosicion + offset;
    }
}
