using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble
{
    public void TakeDamage(int value);
    public void ApplyDamage(int value);
}
