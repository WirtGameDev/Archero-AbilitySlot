using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "NewAbility", menuName = "Scriptable Object/Ability")]
public class Ability : ScriptableObject
{
    public string AbilityName;
    public AbilityType Type;
    public Sprite AbilityIcon;
}