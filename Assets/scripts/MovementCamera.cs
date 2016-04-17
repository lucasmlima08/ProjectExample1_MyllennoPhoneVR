using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using MyllennoPhoneVR;

public class MovementCamera : MonoBehaviour {

    public GameObject cameras;
	public float SpeedMovement;
	public float SpeedRotation;
    
	private CameraVR cameraVR;
    
    void Start () {

        // inicia a classe de cálculos e os sensores.
        cameraVR = new CameraVR(true, true, false, SpeedMovement, SpeedRotation, false);
    }

	void Update () {

		// Rotação de câmera.
		Quaternion quaternion = cameraVR.rotationCamera(cameras.transform.rotation);
        cameras.transform.rotation = quaternion;

        // Movimento de câmera.
        if (Input.touchCount > 0)
        {
			Vector3 movement = cameraVR.movementCamera(cameras.transform.forward);
            cameras.transform.position += movement;
        }
    }
}
