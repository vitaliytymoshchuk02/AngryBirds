using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private LineRenderer[] _lines;
    [SerializeField] private Transform _center;
    [SerializeField] private Transform[] _stripPositions;
    [SerializeField] private Transform _idlePosition;
    [SerializeField] private float _maxLength;
    [SerializeField] private float _force;

    private Vector3 _currentPosition;
    private bool isMouseDown;
    void Start()
    {
        _lines[0].positionCount = 2;
        _lines[1].positionCount = 2;
        _lines[0].SetPosition(0, _stripPositions[0].position);
        _lines[1].SetPosition(0, _stripPositions[1].position);

        ResetStrips();
    }

    void Update()
    {
        if(isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;

            mousePosition.z = 10;
            _currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            _currentPosition = _center.position + Vector3.ClampMagnitude(_currentPosition - _center.position, _maxLength);

            SetStrips(_currentPosition);
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        Shoot();
        ResetStrips();
    }

    private void ResetStrips()
    {
        _currentPosition = _idlePosition.position;
        SetStrips(_currentPosition);
    }

    private void SetStrips(Vector3 position)
    {
        _lines[0].SetPosition(1, position);
        _lines[1].SetPosition(1, position);
    }

    public Vector3 GetCurrentPosition() => _currentPosition;
    public Vector3 GetCenterPosition() => _center.position;
    public Vector3 GetVelocity()
    {
        return (_center.position - _currentPosition) * _force;
    }
    private void Shoot()
    {
        gameManager.Shot(GetVelocity());
    }
    public bool GetIsMouseDown()
    {
        return isMouseDown;
    }
}
