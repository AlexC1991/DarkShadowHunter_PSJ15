using System.Collections;
using UnityEngine;

namespace DarkShadowHunter
{
   public class BottleLiquidControl : MonoBehaviour
   {
      private float _fillMax = 0.0183f;
      private float _fillMin = -0.01f;
      private float _fillAmount;
      [SerializeField] private Material _liquidMaterial;

      private void Update()
      {
         if (Input.GetKeyDown(KeyCode.Alpha1))
         {
            if (_fillAmount < _fillMax)
            {
               StartCoroutine(FillUpPotionBottle());
            }
         }

         if (Input.GetKeyDown(KeyCode.Alpha2))
         {
            if (_fillAmount > _fillMin)
            {
               StartCoroutine(EmptyPotionBottle());
            }
         }
         
         Debug.Log(_fillAmount);
      }
      
      private IEnumerator FillUpPotionBottle()
      {
         float startTime = Time.time;
         float duration = 3f;  // Duration in seconds for the fill up to complete
         float startFill = _fillAmount;

         while (_fillAmount < _fillMax)
         {
            float elapsedTime = Time.time - startTime;
            _fillAmount = Mathf.Lerp(startFill, _fillMax, elapsedTime / duration);
            _liquidMaterial.SetFloat("_Fullness", _fillAmount);

            if (elapsedTime >= duration)
            {
               _fillAmount = _fillMax;
               _liquidMaterial.SetFloat("_Fullness", _fillAmount);
               yield break;
            }

            yield return null;
         }
      }

      private IEnumerator EmptyPotionBottle()
      {
         float startTime = Time.time;
         float duration = 3f;  // Duration in seconds for the emptying to complete
         float startFill = _fillAmount;

         while (_fillAmount > _fillMin)
         {
            float elapsedTime = Time.time - startTime;
            _fillAmount = Mathf.Lerp(startFill, _fillMin, elapsedTime / duration);
            _liquidMaterial.SetFloat("_Fullness", _fillAmount);

            if (elapsedTime >= duration)
            {
               _fillAmount = _fillMin;
               _liquidMaterial.SetFloat("_Fullness", _fillAmount);
               yield break;
            }

            yield return null;
         }
      }
   }
}
