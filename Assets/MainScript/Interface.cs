using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public interface IHitable
    {
        public void Hit();
    }
    public interface IAttackable
    {
        public void Attack();
    }
}
