using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMove<T> : EntityStateBase<T>
{
    T _inputIdle;

    public PlayerStateMove(T inputIdle)
    {
        _inputIdle = inputIdle;
    }
    public override void Awake()
    {
        base.Awake();
        _model.OnRun += _view.AnimRun;
       
    }
    public override void Execute()
    {

        base.Execute();
        var h = Input.GetAxis("Vertical");
        var dir = h * _model.transform.forward;
    
        if (h == 0)
        {
            _fsm.Transitions(_inputIdle);
            return;
        }
        _model.Move(dir);
        _model.LookDir(Vector3.up);


    }
    public override void Sleep()
    {
        base.Sleep();
        _model.OnRun -= _view.AnimRun;
        _model.Move(Vector3.zero);
    }
}
