using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DistanceDissolveTarget : MonoBehaviour
{
    private Material[] m_materialRef = null;
    SkinnedMeshRenderer m_renderer = null;
    [HideInInspector] public bool dissolve = false;
    [SerializeField] float disolveSpeed;
    float t = 0;
    private void Awake() {
        m_renderer = GetComponentInChildren<SkinnedMeshRenderer>();
        //m_materialRef = m_renderer.material;
    }
    public Renderer Renderer {
        get {
            if (!m_renderer) m_renderer = GetComponentInChildren<SkinnedMeshRenderer>();
            return m_renderer;
        }
    }
    public Material[] MaterialRef {
        get {
            if (m_materialRef.Length == 0) m_materialRef = Renderer.materials;
            return m_materialRef;
        }
    }
    private void Update() {
        
        if (dissolve && t < 1.25) t += Time.deltaTime * disolveSpeed;
        if (t >= 1.25) gameObject.SetActive(false);
        if(dissolve)
            foreach (Material mat in m_renderer.materials) {
                mat.SetVector("_Position", transform.position + Vector3.down * 2 * (1 - t));
            }            

    }
    //private void OnDestroy() {
    //    m_renderer = null;
    //    if (m_materialRef) Destroy(m_materialRef);
    //    m_materialRef = null;
    //}
}
