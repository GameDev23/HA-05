using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float xMov;
    private float yMov;
    [SerializeField] private Camera camera;
    public float Speed = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");

        Vector3 mov = ((Vector3.up * yMov) + (Vector3.right * xMov)) * (Speed * Time.deltaTime);
        if (mov != Vector3.zero)
        {
            var bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
            var topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
 
            var cameraRect = new Rect(
                bottomLeft.x,
                bottomLeft.y,
                topRight.x - bottomLeft.x,
                topRight.y - bottomLeft.y);
            transform.position += mov;
            
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, cameraRect.xMin + 0.5f, cameraRect.xMax - 0.5f),
                Mathf.Clamp(transform.position.y, cameraRect.yMin + 0.5f, cameraRect.yMax - 0.5f),
                transform.position.z);
        }

    }
}
