using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowVineTUT : MonoBehaviour
{
    public List<MeshRenderer> growVinesrenderers;
    public float Timetogrow = 5;
    public float RefreshRate = 0.05f;
    [Range(0f, 1f)]
    public float minGrow = 0.2f;
    [Range(0f, 1f)]
    public float maxGrow = 0.97f;

    private List<Material> growVinesMaterials = new List<Material> ();
    private bool FullyGrown;

    private void Start()
    {
        for (int i = 0; i < growVinesrenderers.Count; i++)
        {
            for (int j = 0; j < growVinesrenderers[i].materials.Length; j++)
            {
                if (growVinesrenderers[i].materials[j].HasProperty("Grow_"))
                {
                    growVinesrenderers[i].materials[j].SetFloat("Grow_", minGrow);
                    growVinesMaterials.Add(growVinesrenderers[i].materials[j]);
                }
            }
        }
    }



    private void Update()
    {
        for (int i = 0; i < growVinesMaterials.Count; i++)
        {
            StartCoroutine(GrowVines(growVinesMaterials[i]));
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
                growValue -= 1 / (Timetogrow / RefreshRate);
                mat.SetFloat("Grow_", growValue);

                yield return new WaitForSeconds(RefreshRate);
            }
        }

        if(growValue >= maxGrow)
        {
            FullyGrown = true;
            FullyGrown = false;
        }
    }

}
