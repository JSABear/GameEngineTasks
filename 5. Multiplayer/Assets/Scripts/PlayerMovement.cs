using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    #region Private Fields

    private float moveSpeed = 5f;
    private Vector2 moveDirection = Vector2.zero;
    private Rigidbody2D rb;

    #endregion

    #region MonoBehaviour CallBacks

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        HandleMovement();
    }

    #endregion

    private void HandleMovement()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the move direction based on input
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the Rigidbody2D
        rb.velocity = moveDirection * moveSpeed;
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Send player's position data to the network
            stream.SendNext(rb.position);
        }
        else
        {
            // Receive and set other player's position data from the network
            rb.position = (Vector2)stream.ReceiveNext();
        }
    }
}

