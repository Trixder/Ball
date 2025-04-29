using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float mouseSensitivity = 1000.0f;
    [SerializeField]private float clampAngle = 80.0f;
 
    private float rotY, rotX;
    [SerializeField]private Transform PlayerCamera, PlayerBody;
    [SerializeField]private Rigidbody ball;
    
    public float speed = 5f;
    [SerializeField]private float jump = 5f;
    [SerializeField]private Vector3 moveDirection = Vector3.zero;
    [SerializeField]private bool grounded = false;
 
    private void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Jumpable") {
            gameObject.transform.SetParent(collision.transform, true);
            transform.localScale = new Vector3(1/collision.transform.localScale.x, 1/collision.transform.localScale.y, 1/collision.transform.localScale.z);
            grounded = true;
        } else if (collision.gameObject.tag == "JumpableWall") grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Jumpable") {
            gameObject.transform.SetParent(null, true);
            transform.localScale = new Vector3(1, 1, 1);
            grounded = false;
        } else if (collision.gameObject.tag == "JumpableWall") grounded = false;
    }

    private void Update() {
        moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        if (moveDirection.sqrMagnitude > 1f) moveDirection.Normalize();

        moveDirection.x = moveDirection.x * Time.deltaTime * speed;
        moveDirection.z = moveDirection.z * Time.deltaTime * speed;

        if (moveDirection.x != 0) ball.AddForce(transform.forward * moveDirection.x);
        if (moveDirection.z != 0) ball.AddForce(transform.right * moveDirection.z);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) ball.AddForce(transform.up * jump);

        // Mouse //

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
 
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
 
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
 
        Quaternion CameraRotation = Quaternion.Euler(rotX, rotY, 0);
        Quaternion BodyRotation = Quaternion.Euler(0, rotY, 0);

        PlayerCamera.rotation = CameraRotation;
        PlayerBody.rotation = BodyRotation;
    }
}
