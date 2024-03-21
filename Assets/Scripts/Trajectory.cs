using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Slingshot slingshot;
    [SerializeField] private int _dotsNumber = 20;
    [SerializeField] private GameObject _dotsParent;
    [SerializeField] private GameObject _dotPrefab;

    private Transform[] _dotsList;
    private Vector2 _position;

    private void Start()
    {
        Hide();
        PrepareDots();
    }
    private void Update()
    {
        if (gameManager.GetBird() && slingshot.GetIsMouseDown())
        {
            Show();
            UpdateDots(gameManager.GetBird().transform.position, slingshot.GetVelocity());
        }
        else {
            Hide();
        }
    }
    private void PrepareDots()
    {
        _dotsList = new Transform[_dotsNumber];

        for (int i = 0; i < _dotsNumber; i++)
        {
            _dotsList[i] = Instantiate(_dotPrefab, null).transform;
            _dotsList[i].parent = _dotsParent.transform;
        }
    }
    public void UpdateDots(Vector2 startPos, Vector2 velocity)
    {
        for (int i = 0; i < _dotsNumber; i++)
        {
            float time = i * Time.fixedDeltaTime * 2f;

            _position.x = startPos.x + velocity.x * time;
            _position.y = startPos.y + velocity.y * time - 0.5f * Mathf.Abs(Physics2D.gravity.y) * time * time;

            _dotsList[i].position = _position;
        }
    }
    public void Show() => _dotsParent.SetActive(true);
    public void Hide() => _dotsParent.SetActive(false);
}
