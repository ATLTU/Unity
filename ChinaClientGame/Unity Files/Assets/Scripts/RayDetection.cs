using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDetection : MonoBehaviour
{
    [SerializeField] private List<string> tags = new List<string>();
    [SerializeField] private float distance = 1f;
    [SerializeField] private LayerMask layerMask;


    private bool rayHitUp;
    private bool rayHitDown;
    private bool rayHitLeft;
    private bool rayHitRight;


    [SerializeField] private GameObject rayHitGameObjectUp;
    [SerializeField] private GameObject rayHitGameObjectDown;
    [SerializeField] private GameObject rayHitGameObjectLeft;
    [SerializeField] private GameObject rayHitGameObjectRight;

    public bool RayHitUp { get => rayHitUp; }
    public bool RayHitDown { get => rayHitDown; }
    public bool RayHitLeft { get => rayHitLeft; }
    public bool RayHitRight { get => rayHitRight; }
    public GameObject RayHitGameObjectUp { get => rayHitGameObjectUp; }
    public GameObject RayHitGameObjectDown { get => rayHitGameObjectDown; }
    public GameObject RayHitGameObjectLeft { get => rayHitGameObjectLeft; }
    public GameObject RayHitGameObjectRight { get => rayHitGameObjectRight; }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RayDetectionFunction();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.up * -distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * -distance);
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.left * distance);
    }

    private void RayDetectionFunction()
    {
        CheckRay(ref rayHitGameObjectUp, ref rayHitUp, Vector2.up * distance);
        CheckRay(ref rayHitGameObjectDown, ref rayHitDown, Vector2.up * -distance);
        CheckRay(ref rayHitGameObjectLeft, ref rayHitLeft, Vector2.left * distance);
        CheckRay(ref rayHitGameObjectRight, ref rayHitRight, Vector2.left * -distance);

    }

    private void CheckRay(ref GameObject _gameObject, ref bool _didIHit, Vector2 _direction)
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _direction, distance, layerMask);
        if (hit.collider != null /*&& tags.Contains(hit.collider.gameObject.tag)*/)
        {
            _gameObject = hit.collider.gameObject;
            _didIHit = true;
        }
        else
        {
            _gameObject = null;
            _didIHit = false;
        }
    }
}


