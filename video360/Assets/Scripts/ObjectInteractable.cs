using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IObjectInteractable
{
    protected float _countdown;
    protected float _timelimit = 1, _coolown = 1;
    protected Collider _collider;
    protected MeshRenderer _mesh;

    public float countdown { get{ return _countdown; } }

    protected void Awake()
    {
        _collider = GetComponent<Collider>();
        _mesh = GetComponent<MeshRenderer>();

    }

    public virtual void actionAfterClick()
    {
      
    }

    public virtual void onclick()
    {
    }

    public void resetCount()
    {
        _countdown = 0;
    }

    public void selected()
    {
        _countdown += Time.deltaTime;
        if(_countdown >= _timelimit)
        {
            resetCount();
            onclick();
            actionAfterClick();
        }
    }

    public IEnumerator EnableAfterSeconds()
    {
        _collider.enabled = false;
        _mesh.enabled = false;
        yield return new WaitForSeconds(_coolown);
        _collider.enabled = true;
        _mesh.enabled = true;     
    }
}
