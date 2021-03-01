using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private bool _isMouseOver;

    public bool IsMouseOver
    {
        get { return _isMouseOver; }
    }

    private PlayerData _playerData;

    public PlayerData PlayerData
    {
        get { return _playerData; }
    }

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private GameObject _hair;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetPlayerData(PlayerData playerData)
    {
        _playerData = playerData;
    }

    void Start()
    {
        if(_playerData != null)
        {
            //Set the NPC's gender
            _animator.SetBool("Male", _playerData.Gender == "Male" ? true : false);

            Color32[] SkinColors = new Color32[] {
            new Color32(254, 253, 253, 255),
            new Color32(245, 234, 223, 255),
            new Color32(235, 214, 193, 255),
            new Color32(220, 185, 149, 255),
            new Color32(206, 155, 105, 255),
            new Color32(190, 126, 62, 255),
            new Color32(160, 106, 52, 255),
            new Color32(131, 87, 43, 255),
            new Color32(101, 67, 33, 255),
            new Color32(86, 57, 28, 255),
            new Color32(71, 47, 23, 255),
            new Color32(57, 38, 19, 255)
            };

            //Set the NPC's skin color
            _spriteRenderer.color = SkinColors[_playerData.SkinColor];
        };
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && _isMouseOver)
        {
            MenuStateHandler.currentMenuState = MenuState.worldSelection;
        }
    }

    void OnMouseEnter()
    {
        _isMouseOver = true;
    }

    void OnMouseExit()
    {
        _isMouseOver = false;
    }
}
