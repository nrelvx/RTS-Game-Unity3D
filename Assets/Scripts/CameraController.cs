using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 10.0f, speed = 10.0f, zoomSpeed = 3000f;
    
    private void Update()
    {
        
        // WASD moves
        float horizontal = -Input.GetAxis("Horizontal");
        float vertical = -Input.GetAxis("Vertical");
        
        float rotate = 0f;
        // If user tap keyboard
        if (Input.GetKey(KeyCode.Q))
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E))
            rotate = 1f;
        
        // Speed increase
        float _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
        
            // Rotate camera along the Y slow 
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * _mult, Space.World);
            // Move camera
        transform.Translate(new Vector3(horizontal, 0f, vertical) * Time.deltaTime * _mult * speed, Space.Self);
            // Zoom camera
        transform.position += transform.up * zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");
            // Limit zoom(-30; 50)
        transform.position = new Vector3(transform.position.x,
            // min max Y
            Mathf.Clamp(transform.position.y, -30f, 50f),
            transform.position.z);
    }
}
