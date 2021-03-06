﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets._scripts;
using UnityEngine.Events;


public class Gacha : MonoBehaviour
{

    public enum Animation { Idle, Walk, Special }
    #region public properties
    public bool IsAnimated = false;
    
    public Sprite gachaUI = null;
    public GachaID ID;
    public bool HasSpecialAnimation = false;
    public AnimationClip SpecialAnimation = null;
    [SerializeField]
    public Vector3 Size
    {
        get
        {
            float width = 0;
            float height = 0;
            float depth = 0;
            Vector3 size = _collider.bounds.size;
            if (size.x > width)
            {
                width = size.x;
            }
            if (size.y > height)
            {
                height = size.y;
            }
            if (size.z > depth)
            {
                depth = size.z;
            }
            

            return new Vector3(width, height, depth);
        }
    }
    #endregion

    #region events

    [System.Serializable]
    public class OnClickEvent : UnityEvent<Gacha> { }

    [SerializeField]
    public OnClickEvent OnClick;

    //public UnityEvent OnClickEvent;
    #endregion

    #region private fields
    private Camera _mainCamera;
    private Collider _collider;
    private Animator _animator;
    private Renderer[] _renderers;
    private bool _inTownScene = false;
    #endregion

    #region public API

    /// <summary>
    /// Sets and starts the given particle effect prefab
    /// note this called by animation controller when starting animation
    /// </summary>
    /// <param name="effectPrefab"></param>
    public void PlaySpecialAnimationEffect(GameObject effectPrefab)
    {
        GameObject particleInstance = GameObject.Instantiate<GameObject>(effectPrefab);
        ParticleSystem effects = particleInstance.GetComponent<ParticleSystem>();
        particleInstance.transform.position = transform.position;
        effects.Play();
        Destroy(particleInstance, effects.duration);
    }

    /// <summary>
    /// Called when the animation sequence is done.
    /// </summary>
    public void SpecialAnimationComplete()
    {
        GameManager.Instance.CameraReturnToOriginal();
    }

    /// <summary>
    /// Play the given animation for this object
    /// </summary>
    /// <param name="animation"></param>
    public void PlayAnimation(Animation animation)
    {
        switch (animation)
        {
            case Animation.Idle:
                _animator.SetTrigger("Idle");
                break;
            case Animation.Special:
                _animator.SetTrigger("special");
                break;
        }
    }

    /// <summary>
    /// Change the color of this gacha to the given color if disable is false, else ignores color and set to default texture.
    /// </summary>
    /// <param name="color"></param>
    public void ChangeColor(Color color)
    {
        foreach (Renderer renderer in _renderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.color = color;
            }
        }

    }

    public void ChangeTexture(Texture texture)
    {
        foreach (Renderer renderer in _renderers)
        {
            foreach (Material material in renderer.materials)
            {
                material.mainTexture = texture;
            }
        }
    }
    #endregion

    #region unity lifecycle methods

    private void Awake()
    {
        OnClick = new OnClickEvent();

        _collider = GetComponent<Collider>();
        Debug.Assert(_collider != null, "collider not found.");

        _animator = GetComponent<Animator>();
        Debug.Assert(_animator != null, "No animator component found.");

        IsAnimated = _animator.enabled;

        _mainCamera = Camera.main;

       

        _renderers = GetComponentsInChildren<Renderer>();
       Debug.Assert(_renderers != null, "could not find a renderer.");

        _inTownScene = GameManager.Instance.CurrentScene == GameManager.Scene.TOWN;

    }

    private void Update()
    {
        if (_inTownScene)
        {
            UpdateClickEvent();
        }
        
    }
    #endregion

    #region event handlers
    /// <summary>
    /// Idle animation timer alarm event handler
    /// (fired from _idleAnimationTimer)
    /// </summary>
    private void HandleIdleAnimationAlarmEvent()
    {
        PlayAnimation(Animation.Idle);
    }
    #endregion

    /// <summary>
    /// fires OnClickEvent if this gacha is clicked.
    /// note the Gacha prefab needs layer to be 'Gacha'and a 3d collider for this to work
    /// </summary>
    private void UpdateClickEvent()
    {
        bool playingSpecialAnimation = IsAnimated && _animator.GetCurrentAnimatorStateInfo(0).IsName("special");
        if (!playingSpecialAnimation && Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("Gacha");
            if (Physics.Raycast(ray, out hit, 1000, mask) && hit.collider == _collider)
            {
                OnClick.Invoke(this);
            }
        }
    }


    private IEnumerator WalkForward()
    {
        for (Timer timer = new Timer(1, true); timer.AlarmRaised == false; timer.Update(Time.deltaTime))
        {
            
            float speed = 5 * Time.deltaTime;
            transform.Translate(Vector3.forward * speed);
            _animator.SetFloat("velocity", speed);
            yield return null;
        }
        _animator.SetFloat("velocity", 0);

    }
}
