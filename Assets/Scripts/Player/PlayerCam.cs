using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Player Cam Settings")]
     private float MouseSensitivity = 100f;

    [SerializeField] private Transform PlayerBody;


    float XRot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MouseSensitivity = StartGame.instance.MouseSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Gamemanager.instance.CanPlayerMove)
        {
            return;
        }
        float MX = Input.GetAxis("Mouse X")* MouseSensitivity * Time.deltaTime;
        float MY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRot -= MY;
        XRot = Mathf.Clamp(XRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRot, 0, 0);
        PlayerBody.Rotate(Vector3.up * MX);
        
    }


}
