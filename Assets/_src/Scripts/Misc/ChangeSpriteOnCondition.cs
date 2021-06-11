using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KaitoMajima
{
    public class ChangeSpriteOnCondition : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer theSpriteRenderer;
        [SerializeField] private Sprite onSprite;
        [SerializeField] private Sprite offSprite;
        public void SetSprite(bool condition)
        {
            theSpriteRenderer.sprite = condition ? onSprite : offSprite;
        }
    }
}
