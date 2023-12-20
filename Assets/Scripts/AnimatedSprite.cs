using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float framerate = 1f / 6f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(Animate), framerate, framerate);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Animate()
    {
        frame++;

        if (frame >= sprites.Length) 
        {
            frame = 0;
        }

        if (frame >= 0 && frame < sprites.Length) 
        {
            spriteRenderer.sprite = sprites[frame];
        }
    }
}
