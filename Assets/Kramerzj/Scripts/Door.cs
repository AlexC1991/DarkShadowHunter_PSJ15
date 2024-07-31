using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DarkShadowHunter
{
    public class Door : Interatable
    {
        public Transform originTran;
        public Transform targetTran;
        private bool _isMoved;
        [SerializeField] KeyCode _inputKey = KeyCode.E;

        public override void Interact()
        {
            if (Input.GetKeyDown(_inputKey))
            {
                _isMoved = !_isMoved;
                StartCoroutine(DoorMoves());
            }
        }
        IEnumerator DoorMoves()
        {
            Vector3 pos;
            if (_isMoved)
            {
                pos = originTran.position;
            }
            else
            {
                pos = targetTran.position;
            }
            while (Vector3.Distance(transform.position, pos) > 0.2f)
            {
                transform.position += (pos- transform.position) *Time.fixedDeltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
