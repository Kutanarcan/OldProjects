using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Power up",menuName ="ScriptableObjects/PowerUp")]
public class PowerUp : ScriptableObject
{
    //TODO: Change this variables name's first letter.
    public string PowerName;
    public Sprite Icon;
    public BaseActivator Activator;
    public GameObject pickupSound;
}
