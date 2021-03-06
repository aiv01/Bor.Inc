using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]float cureValue;
    [SerializeField]float rotateSpeed;
    ParabolicMotion pm;
    [SerializeField]LayerMask ground;
    [HideInInspector] public bool trueStart = false;
    [SerializeField] AudioSource au;
    HeartSound sound;
    string pTag = "Player";

    private void OnEnable()
    {
        if(trueStart)
        {
            RaycastHit hit;
            if (!pm)
                pm = GetComponent<ParabolicMotion>();
            Vector3 pos;
            do
            {
                pos = new Vector3(Random.Range(-3f, 3f), 0, Random.Range(-3f, 3f)) + transform.position;

            } while (!Physics.Raycast(pos, -transform.up, out hit, 25f, ground));
            pm.TargetPos = pos;
        }
        
    }
    private void OnDisable()
    {
        trueStart = false;
        GetComponent<Collider>().enabled = false;
    }
    void Start()
    {
        sound = FindObjectOfType<HeartSound>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
        if (pm.finishParabolic && !GetComponent<Collider>().enabled)
        {
            GetComponent<Collider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(pTag))
        {
            sound.HeartMusic();
            if (other.GetComponent<ExplorerController>().CurrentHp + cureValue < other.GetComponent<ExplorerController>().MaxHp)
            {
                other.GetComponent<ExplorerController>().CurrentHp += cureValue;
            }
            else
            {
                other.GetComponent<ExplorerController>().CurrentHp = other.GetComponent<ExplorerController>().MaxHp;
            }
            gameObject.SetActive(false);

        }
    }
}
