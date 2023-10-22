using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class FollowMouse : MonoBehaviourPun
{
    public Transform centerPoint;     // The center point for positioning the arm
    public float armLength = 2.45f;  // Length of the arm


 

    private void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 directionToMouse = mousePosition - centerPoint.position;

        // Ensure the arm stays within the fixed radius
        if (directionToMouse.magnitude > armLength)
        {
            directionToMouse = directionToMouse.normalized * armLength;
        }

        // Calculate the new arm position
        Vector3 newArmPosition = centerPoint.position + directionToMouse;

        // Move the arm to the new position
        transform.position = newArmPosition;

        // Calculate the rotation to make the arm point towards the mouse
        float objectRotation = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, objectRotation - 90f);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send player's position data to the network
            stream.SendNext(transform.rotation);
            stream.SendNext(transform.position);
        }
        else
        {
            // Receive and set other player's position data from the network
            transform.rotation = (Quaternion)stream.ReceiveNext();
            transform.position = (Vector2)stream.ReceiveNext();
        }
    }
}
