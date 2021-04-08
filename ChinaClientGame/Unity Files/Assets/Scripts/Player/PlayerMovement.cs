using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AudioManager audioSource;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform movePoint;

    private float horizontalRaw;
    private float verticalRaw;

    [SerializeField] private LayerMask whatStopsMovement;
    [SerializeField] private LayerMask whatMoveAble;

    [SerializeField] private Vector2 movePointStartPosition;

    private RayDetection rayDetection;
    private GameObject objectToBeMoved;

    public float HorizontalRaw { get => horizontalRaw; set => horizontalRaw = value; }
    public float VerticalRaw { get => verticalRaw; set => verticalRaw = value; }

    [SerializeField] private Animator animator;

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rayDetection = GetComponent<RayDetection>();
        movePoint.parent = null;
        movePoint.position = movePointStartPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Animation();
    }

    private void Movement()
    {
        horizontalRaw = Input.GetAxisRaw("Horizontal");
        verticalRaw = Input.GetAxisRaw("Vertical");
        bool didIMove = false;
        //transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(horizontalRaw) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontalRaw, 0f, 0f), .2f, whatStopsMovement) && didIMove == false )
                {
                    didIMove = true;
                    movePoint.position += new Vector3(horizontalRaw, 0f, 0f);
                    //DOtweening Code! Ask Kasper For help!
                    transform.DOLocalMove(movePoint.position, moveSpeed);
                }

                if (Physics2D.OverlapCircle(movePoint.position + new Vector3(horizontalRaw, 0f, 0f), .2f, whatMoveAble) 
                    && didIMove == false && DidIHitAnObject(new Vector2(horizontalRaw, verticalRaw)))
                {
                    didIMove = true;
                    movePoint.position += new Vector3(horizontalRaw, 0f, 0f);
                    MoveBox(new Vector2(horizontalRaw, 0));
                    //DOtweening Code! Ask Kasper For help!
                    transform.DOLocalMove(movePoint.position, moveSpeed);
                    //audioSource.Play("BoxMovement");
                }
            }
            else
            {
                if (Mathf.Abs(verticalRaw) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalRaw, 0f), .2f, whatStopsMovement) && didIMove == false )
                    {
                        didIMove = true;
                        movePoint.position += new Vector3(0f, verticalRaw, 0f);
                        //DOtweening Code! Ask Kasper For help!
                        transform.DOLocalMove(movePoint.position, moveSpeed);
                    }

                    if (Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, verticalRaw, 0f), .2f, whatMoveAble)
                        && didIMove == false && DidIHitAnObject(new Vector2(horizontalRaw,verticalRaw)))
                    {
                        didIMove = true;
                        movePoint.position += new Vector3(0f, verticalRaw, 0f);
                        MoveBox(new Vector2(0, verticalRaw));
                        //DOtweening Code! Ask Kasper For help!
                        transform.DOLocalMove(movePoint.position, moveSpeed);
                        //audioSource.Play("BoxMovement");
                    }
                }
            }
        }
    }

    private void Animation()
    {
        movement.x = HorizontalRaw;
        movement.y = VerticalRaw;

        animator.SetFloat("Horizontal", HorizontalRaw);
        animator.SetFloat("Vertical", VerticalRaw);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void MoveBox(Vector2 _direction)
    {
        objectToBeMoved = null;

        if (_direction.x != 0)
        {
            if (_direction.x > 0 && rayDetection.RayHitRight)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectRight;
            }
            else if (_direction.x < 0 && rayDetection.RayHitLeft)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectLeft;
            }
        }
        else
        {
            if (_direction.y > 0 && rayDetection.RayHitUp)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectUp;
            }
            else if (_direction.y < 0 && rayDetection.RayHitDown)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectDown;
            }
        }
        
        if (objectToBeMoved != null)
        {
            objectToBeMoved.transform.DOLocalMove((Vector2)movePoint.position + _direction, moveSpeed);
        }
    }

    private bool DidIHitAnObject(Vector2 _direction)
    {
        if (_direction.x != 0)
        {
            if (_direction.x > 0 && rayDetection.RayHitRight)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectRight;
            }
            else if (_direction.x < 0 && rayDetection.RayHitLeft)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectLeft;
            }
        }
        else
        {
            if (_direction.y > 0 && rayDetection.RayHitUp)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectUp;
            }
            else if (_direction.y < 0 && rayDetection.RayHitDown)
            {
                objectToBeMoved = rayDetection.RayHitGameObjectDown;
            }
        }
        if (objectToBeMoved != null)
        {
            return objectToBeMoved.GetComponent<BoxMovement>().CanIMove(_direction);
        }

        return false;
    }
}
