using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody playerRB;
    [SerializeField]
    Transform cameraParent;
    [SerializeField]
    float rotationSpeed, moveSpeed;

    private void Update()
    {
        playerRB.transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime, 0));

        cameraParent.transform.Rotate(- new Vector3(Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime, 0, 0));

        Vector3 newVelocity;
        if (Input.GetKey(KeyCode.W))
        {
            newVelocity = playerRB.transform.forward * moveSpeed;
            newVelocity.y = playerRB.linearVelocity.y;  
            playerRB.linearVelocity = newVelocity;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            newVelocity = -playerRB.transform.forward * moveSpeed;
            newVelocity.y = playerRB.linearVelocity.y;
            playerRB.linearVelocity = newVelocity;
        }        
        else if (Input.GetKey(KeyCode.D))
        {
            newVelocity = playerRB.transform.right * moveSpeed;
            newVelocity.y = playerRB.linearVelocity.y;
            playerRB.linearVelocity = newVelocity;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            newVelocity = -playerRB.transform.right * moveSpeed;
            newVelocity.y = playerRB.linearVelocity.y;
            playerRB.linearVelocity = newVelocity;
        }
    }
}
