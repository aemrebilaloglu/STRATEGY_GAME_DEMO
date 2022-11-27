using UnityEngine;
    public class Unit : MonoBehaviour {
        [SerializeField] private SpriteRenderer _renderer;
    public void Init(Sprite sprite) // for start sprite
    {
        _renderer.sprite = sprite;
    }
}
