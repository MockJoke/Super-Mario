using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerSpriteRenderer : MonoBehaviour
{
    private PlayerMovement movement;
    public SpriteRenderer spriteRenderer { get; private set; }
    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite jump;
    [SerializeField] private Sprite slide;
    [SerializeField] private AnimatedSprite run;

    private void Awake()
    {
        if (movement == null)
            movement = GetComponentInParent<PlayerMovement>();
        
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        run.enabled = movement.running;

        if (movement.jumping) 
        {
            spriteRenderer.sprite = jump;
        } 
        else if (movement.sliding) 
        {
            spriteRenderer.sprite = slide;
        } 
        else if (!movement.running) 
        {
            spriteRenderer.sprite = idle;
        }
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        run.enabled = false;
    }
}
