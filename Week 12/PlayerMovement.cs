using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;

    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearleft;
    public Sprite bearright;

    public Transform weapon;
    public Transform firepoint;

    public Vector2 rightPosition = new Vector2(0.5f, 0);
    public Vector2 leftPosition = new Vector2(-0.5f, 0);
    public Vector2 upPosition = new Vector2(0, 0.5f);
    public Vector2 downPosition = new Vector2(0, -0.5f);

    private Vector2 facingDirection = Vector2.right;

    void Update()
    {
        Movement();
        RotateWeapon();
    }

    void Movement()
    {
        speedX = 0;
        speedY = 0;

        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.sprite = bearleft;
            facingDirection = Vector2.left;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.sprite = bearright;
            facingDirection = Vector2.right;
        }

        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = beartop;
            facingDirection = Vector2.up;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = beardown;
            facingDirection = Vector2.down;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }

    void RotateWeapon()
    {
        float angle = Mathf.Atan2(
            facingDirection.y,
            facingDirection.x
        ) * Mathf.Rad2Deg;

        weapon.localRotation = Quaternion.Euler(0, 0, angle);
        firepoint.localRotation = Quaternion.Euler(0, 0, angle - 90f);

        if (facingDirection == Vector2.right)
        {
            weapon.localPosition = rightPosition;
            firepoint.localPosition = rightPosition;
        }
        else if (facingDirection == Vector2.left)
        {
            weapon.localPosition = leftPosition;
            firepoint.localPosition = leftPosition;
        }
        else if (facingDirection == Vector2.up)
        {
            weapon.localPosition = upPosition;
            firepoint.localPosition = upPosition;
        }
        else if (facingDirection == Vector2.down)
        {
            weapon.localPosition = downPosition;
            firepoint.localPosition = downPosition;
        }
    }
}
