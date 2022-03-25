using _3DLaser.Scripts.LaserCannon.Parts;
using UnityEngine;

namespace _3DLaser.Scripts.LaserCannon
{
    public class CannonController : MonoBehaviour
    {
        [SerializeField] private Platform _platform;
        [SerializeField] private Crane _barrelCrane;
        [SerializeField] private float _turningSpeed;
        [SerializeField] private float _tiltingSpeed;

        public void TurnPlatformLeft()
        {
            _platform.transform.rotation *= Quaternion.Euler(0, -_turningSpeed * Time.deltaTime, 0);
        }
    
        public void TurnPlatformRight()
        {
            _platform.transform.rotation *= Quaternion.Euler(0, _turningSpeed * Time.deltaTime, 0);
        }

        public void TiltBarrelUp()
        {
            _barrelCrane.transform.rotation *= Quaternion.Euler(_tiltingSpeed * Time.deltaTime, 0, 0);
        }
    
        public void TiltBarrelDown()
        {
            _barrelCrane.transform.rotation *= Quaternion.Euler(-_tiltingSpeed * Time.deltaTime, 0, 0);
        }
    }
}