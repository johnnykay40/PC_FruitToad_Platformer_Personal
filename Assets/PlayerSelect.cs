using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    
    public enum Player {Frog, MaskDude, PinkMan, VirtualGuy };
    public Player playerSelected;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public RuntimeAnimatorController[] playerAnimatorControllers;
    public Sprite[] playerRenderer;

    void Start()
    {
        switch (playerSelected)
        {
            case Player.Frog:
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playerAnimatorControllers[0];
                break;
            case Player.MaskDude:
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playerAnimatorControllers[1];
                break;
            case Player.PinkMan:
                spriteRenderer.sprite = playerRenderer[2];
                animator.runtimeAnimatorController = playerAnimatorControllers[2];
                break;
            case Player.VirtualGuy:
                spriteRenderer.sprite = playerRenderer[3];
                animator.runtimeAnimatorController = playerAnimatorControllers[3];
                break;            
        }
    }

   
}
