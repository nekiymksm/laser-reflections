using _3DLaser.Scripts.LaserCannon;
using UnityEngine;

namespace _3DLaser.Scripts
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] [Range(0f, 1f)] private float _absorptionCoefficient;

        public void ReflectLaserBeam(LaserBeam beam, RaycastHit hit, float beamLength)
        {
            if (beam.IsPowerEnough(_absorptionCoefficient, beamLength) == false)
                beamLength = 0;

            beam.SetBeam(hit.point, Vector3.Reflect(hit.point, hit.normal).normalized, beamLength);
        }
    }
}