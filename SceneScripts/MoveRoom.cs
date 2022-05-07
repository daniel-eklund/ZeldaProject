using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoom : MonoBehaviour
{
    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;
    public Vector3 playerChange;
    private CameraMove cam;
   
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            cam.minPosition = cameraMinChange;
            cam.maxPosition = cameraMaxChange;
            other.transform.position += playerChange;
        }
    }
}
