using UnityEngine;

namespace _3DLaser.Scripts
{
    public class FreeCamera : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _minLimitX;
        [SerializeField] private float _maxLimitX;
        [SerializeField] private float _minLimitY;
        [SerializeField] private float _maxLimitY;

        private Vector3 _defaultCameraPosition;
        private Quaternion _defaultRotation;
        private Vector3 _transfer;
        private float _rotationX;
        private float _rotationY;

        private void Start()
        {
            _defaultCameraPosition = transform.position;
            _defaultRotation = transform.rotation;
        }

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                _rotationX += Input.GetAxis("Mouse X") * _mouseSensitivity;
                _rotationY += Input.GetAxis("Mouse Y") * _mouseSensitivity;
        
                _rotationX = ClampAngle (_rotationX, _minLimitX, _maxLimitX);
                _rotationY = ClampAngle (_rotationY, _minLimitY, _maxLimitY);
        
                transform.rotation = _defaultRotation * Quaternion.AngleAxis(_rotationX, Vector3.up) * 
                                     Quaternion.AngleAxis (_rotationY, Vector3.left);
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                transform.position = _defaultCameraPosition;
                transform.rotation = _defaultRotation;
            }
        
            _transfer = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
            transform.position += _transfer * _movementSpeed * Time.deltaTime;
        }

        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F) angle += 360F;
            if (angle > 360F) angle -= 360F;
        
            return Mathf.Clamp (angle, min, max);
        }
    }
}