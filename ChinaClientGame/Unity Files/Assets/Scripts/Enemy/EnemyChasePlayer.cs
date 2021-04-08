using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    private float horizontalRaw;
    private float verticalRaw;

    public float HorizontalRaw { get => horizontalRaw; set => horizontalRaw = value; }
    public float VerticalRaw { get => verticalRaw; set => verticalRaw = value; }
    #region EnemyStats
    [SerializeField] private int attack = 5;
    [SerializeField] private int health = 20;

    public int Attack { get => attack; set => attack = value; }
    public int Health { get => health; set => health = value; }
    #endregion
    public float maxSpeed;
    public Transform player;

    [SerializeField] private Animator animator;

    private Vector2 movement;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, maxSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage(int PlayerDamage)
    {
        health -= PlayerDamage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public void Update()
    {
        horizontalRaw = Input.GetAxisRaw("Horizontal");
        verticalRaw = Input.GetAxisRaw("Vertical");
        Animation();
    }

    private void Animation()
    {
        movement.x = HorizontalRaw;
        movement.y = VerticalRaw;

        animator.SetFloat("Horizontal", HorizontalRaw);
        animator.SetFloat("Vertical", VerticalRaw);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
