using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : BaseModel
{
    public float lifes;
    public float _mouseSensibilty = 100;
    public Action OnTakeDamage;
    
    public void TakeLife()
    {
      
        if (OnTakeDamage != null)
        {         
            print("da�o");
            //_rb.AddForce(Vector3.up * 200 + (-GetForward * 200));
            OnTakeDamage();
            lifes--;
        }

  
    }
    private void Update()
    {
       
    }
    public override void LookDir(Vector3 dir)
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensibilty * Time.deltaTime; //TODO: SACAR HARCODIADO
        gameObject.transform.Rotate(dir, mouseX);
    }
}
