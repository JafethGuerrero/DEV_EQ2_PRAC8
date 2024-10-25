using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SostenerCubo : MonoBehaviour
{   
    
    public GameObject tomado;

    public bool IsTaken;

    public bool estaElObbjetoCerca;
    
    Transform padre;

    public Vector3 original_scale;

    private void Awake() {
        padre =  GameObject.Find("Personaje").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IsTaken = false;
        estaElObbjetoCerca = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)){
                if(!IsTaken){
                    IsTaken = true;
                }
                else{
                    IsTaken = false;

                }
            }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject temporal = other.gameObject;
        if(temporal.CompareTag("ObjetoTomable")){
            estaElObbjetoCerca = true;
        }
    }
    
    private void OnTriggerStay(Collider other) {
        GameObject temporal = other.gameObject;
        if(estaElObbjetoCerca){
                if(IsTaken){
                    tomado = temporal;
                    temporal.transform.SetParent(padre);
                    temporal.transform.position = transform.position;
                    temporal.transform.rotation = transform.rotation;
                    original_scale = temporal.transform.localScale;
                    temporal.transform.localScale = transform.localScale;
                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    rb.useGravity = false;
                }
                else if(tomado !=null){
                    tomado = null;
                    temporal.transform.SetParent(null);
                    Rigidbody rb = temporal.GetComponent<Rigidbody>();
                    rb.useGravity = true;
                    rb.isKinematic = false;
                    temporal.transform.localScale = original_scale;
                }
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("ObjetoTomable")){ 
            estaElObbjetoCerca = false;
        }
        Debug.Log(other.gameObject.name);
    }
}
