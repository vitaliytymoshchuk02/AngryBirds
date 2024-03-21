using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _birdPrefab;
    [SerializeField] private Slingshot slingshot;
    private Rigidbody2D _birdRigidbody;
    private Collider2D _birdCollider;

    private void Start()
    {
        CreateBird();
    }
    private void CreateBird()
    {
        _birdRigidbody = Instantiate(_birdPrefab).GetComponent<Rigidbody2D>();
        _birdCollider = _birdRigidbody.GetComponent<Collider2D>();
        _birdRigidbody.isKinematic = true;

        _birdRigidbody.transform.position = slingshot.GetCurrentPosition();
    }

    public void Shot(Vector3 birdForce)
    {
        _birdRigidbody.isKinematic = false;
        _birdCollider.gameObject.GetComponent<Bird>().SetInSlingshot(false);
        _birdRigidbody.velocity = birdForce;

        _birdRigidbody = null;
        _birdCollider = null;

        Invoke("CreateBird", 2);
    }
    public GameObject GetBird()
    {
        if (_birdRigidbody)
        {
            return _birdRigidbody.gameObject;
        }
        else return null;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
