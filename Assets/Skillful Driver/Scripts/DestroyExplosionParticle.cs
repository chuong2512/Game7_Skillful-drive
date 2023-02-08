using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkillfulDriver
{
    public class DestroyExplosionParticle : MonoBehaviour
    {
        private void Start()
        {
            Destroy(this.gameObject, 3);
        }
    }
}
