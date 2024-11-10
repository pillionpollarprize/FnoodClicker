using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    public MeshFilter clickObject;
    public Mesh[] models;
    public ParticleSystem particle;
    private Clicker clicker;
    private int currentModel;
    [HideInInspector]public bool changed = false;

    // Start is called before the first frame update
    void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        currentModel = 0;
    }
// Update is called once per frame
    void Update()
    {
        if(clicker.clicks/100 == 1 && changed == false)
        {
            changed = true;
            clickObject.mesh = models[currentModel];
            currentModel++;
            if(currentModel >= models.Length)
            {
                currentModel = 0;
            }
        } else if (changed == true) { changed = false; };
    }
}
