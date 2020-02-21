using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{
    public class DilapidatedStone : MonoBehaviour
    {
        public void ActivateCanvasWithDilapidatedStone()
        {
            gameObject.SetActive(true);

            //if (m_DeactivationCoroutine != null)
            //{
            //    StopCoroutine(m_DeactivationCoroutine);
            //    m_DeactivationCoroutine = null;
            //}

            //gameObject.SetActive(true);
            //animator.SetBool(m_HashActivePara, true);
            //textMeshProUGUI.text = Translator.Instance[phraseKey];
        }
    }
}
