using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Scriptable Explosion", menuName = "Explosion")]
public class ScriptableExplosion : ScriptableObject
{
    public ExplosionType type;
    public ParticleSystem prefab;
}
