using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Explosion", menuName = "Bullet")]
public class ScriptableBullet : ScriptableObject
{
    public BulletType type;
    public Bullet prefab;
}
