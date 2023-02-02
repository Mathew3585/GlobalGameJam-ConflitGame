using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowVineTUT : MonoBehaviour
{
    public List<MeshRenderer> growVinesMeshes;
    public float Timetogrow = 5;
    public float RefreshRate = 0.05f;
    [Range(0, 1)]
    public float minGrow = 0.2f;
    [Range(0, 1)]
    public float maxGrow = 0.97f;

    private List<Material> growVinesMaterials = new List<Material> ();
    private bool FullyGrown;

    void Start()
    {
        for (int i=0; i < growVinesMeshes.Count; i++)
        {
            for (int j=0; j<growVinesMeshes[i].materials.Length; j++)
            {
                if (growVinesMeshes[i].materials[j].HasProperty("Grow_"))
                {
                    growVinesMeshes[i].materials[j].SetFloat("Grow_", minGrow);
                    growVinesMaterials.Add(growVinesMeshes[i].materials[j]);
                }
            }
        }
    }



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < growVinesMaterials.Count; i++)
            {
                StartCoroutine(GrowVines(growVinesMaterials[i]));
            }       
        }
        
    }

    IEnumerator GrowVines(Material mat)
    {
        float growValue = mat.GetFloat("Grow_");

        if (!FullyGrown)
        {
            while(growValue < maxGrow)
            {
                growValue += 1 / (Timetogrow / RefreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds(RefreshRate);
            }
        }
        else
        {
            while (growValue > minGrow)
            {
                growValue -= 1 / (Timetogrow/RefreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds(RefreshRate);
            }
        }

        if(growValue >= maxGrow)
        {
            FullyGrown = true;
            
        }
        else
        {
           FullyGrown = false; 
        }        
    }

}
