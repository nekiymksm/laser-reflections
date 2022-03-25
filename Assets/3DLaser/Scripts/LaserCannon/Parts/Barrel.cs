using _3DLaser.Scripts.LaserCannon.Parts.Base;
using UnityEngine;

namespace _3DLaser.Scripts.LaserCannon.Parts
{
    public class Barrel : CannonPart
    {
        [SerializeField] private LaserBeam _laserBeam;

        private void Start()
        {
            _laserBeam.gameObject.SetActive(true);
        }
    }
}