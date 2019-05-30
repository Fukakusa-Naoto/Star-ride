using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushEffect : MonoBehaviour
{
    // パーティクルシステム
    private ParticleSystem m_particle;


    // Start is called before the first frame update
    void Start()
    {
        // パーティクルシステムの取得
        m_particle = GetComponent<ParticleSystem>();
        m_particle.Stop();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartEffect(Vector3 vec)
    {
        // パーティクルシステムを発生させる
        transform.position = vec;
        m_particle.Play();
    }
}
