using UnityEngine;

public class Barrel : CannonPart
{
    [SerializeField] private LaserBeam _laserBeam;

    private void Start()
    {
        _laserBeam.gameObject.SetActive(true);
    }
}