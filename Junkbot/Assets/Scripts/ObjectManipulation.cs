using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManipulation : MonoBehaviour
{
    public Camera playerCam;
    public GameObject selected;
    public float rotationSpeed;
    public bool leftClick;
    public bool rightClick;

    public float yaw;
    public float pitch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftClick = Input.GetMouseButton(0);
        rightClick = Input.GetMouseButton(1);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                selected = hit.transform.gameObject;
            }
        }

        if (Input.GetMouseButton(1) && selected != null)
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * -1;
            pitch += Input.GetAxis("Mouse Y") * rotationSpeed;

            selected.transform.eulerAngles = new Vector3(pitch, yaw, 0);
        }
    }
}
