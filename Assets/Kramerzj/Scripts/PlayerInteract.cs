using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DarkShadowHunter
{
    public class PlayerInteract : MonoBehaviour
    {
        public void Interacts(GameObject _hitObject)
        {
            Interatable tempInte;
            if (_hitObject.TryGetComponent<Interatable>(out tempInte))
            {
                tempInte.Interact();
            }
        }
    }
}
