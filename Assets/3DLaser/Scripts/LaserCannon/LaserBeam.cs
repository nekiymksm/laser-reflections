using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    [SerializeField] private float _maxLength;
    [SerializeField] [Range(0f, 1f)] private float _minPowerLimit;

    private LineRenderer _lineRenderer;
    private Gradient _defaultGradient;
    private int _defaultPositionsCount;
    
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        
        _defaultGradient = _lineRenderer.colorGradient;
        _defaultPositionsCount = _lineRenderer.positionCount;
    }

    private void Update()
    {
        _lineRenderer.colorGradient = _defaultGradient;
        _lineRenderer.positionCount = _defaultPositionsCount;
        
        SetBeam(transform.position, transform.up, _maxLength);
    }

    public void SetBeam(Vector3 startPosition, Vector3 beamDirection, float length)
    {
        if (Physics.Raycast(startPosition, beamDirection, out RaycastHit hit, length) 
            && hit.collider.TryGetComponent(out Obstacle obstacle))
        {
            AddConnectionPoint(transform.InverseTransformPoint(hit.point));
            obstacle.ReflectLaserBeam(this, hit, length - hit.distance);
        }
        else
        {
            var lastLineVertexPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
            AddConnectionPoint(lastLineVertexPosition + transform.InverseTransformDirection(beamDirection) * length);
        }
    }
    
    public bool IsPowerEnough(float absorptionCoefficient, float beamLength)
    {
        var oldAlphaKeys = _lineRenderer.colorGradient.alphaKeys;
        var newAlpha = oldAlphaKeys[oldAlphaKeys.Length - 1].alpha - absorptionCoefficient;
        
        if (newAlpha < _minPowerLimit)
            return false;

        var gradient = new Gradient();
        var newAlphaKeys = new GradientAlphaKey[oldAlphaKeys.Length + 1];
        var newTimeLocation = (_maxLength - beamLength) / _maxLength;
        
        for (int i = 0; i < oldAlphaKeys.Length; i++)
            newAlphaKeys[i] = oldAlphaKeys[i];
        
        newAlphaKeys[oldAlphaKeys.Length - 1] = 
            new GradientAlphaKey(oldAlphaKeys[oldAlphaKeys.Length - 1].alpha, newTimeLocation);
        
        newAlphaKeys[newAlphaKeys.Length - 1] = 
            new GradientAlphaKey(newAlpha, oldAlphaKeys[oldAlphaKeys.Length - 1].time);
        
        gradient.mode = GradientMode.Fixed;
        gradient.SetKeys(_lineRenderer.colorGradient.colorKeys, newAlphaKeys);
        _lineRenderer.colorGradient = gradient;

        return true;
    }

    private void AddConnectionPoint(Vector3 pointPosition)
    {
        _lineRenderer.positionCount++; 
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, pointPosition);
    }
}