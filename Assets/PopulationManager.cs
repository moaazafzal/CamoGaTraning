using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour
{
    public GameObject personPrefab;
    public int populationSize = 10;
    public List<GameObject> population = new List<GameObject>();
    // Start is called before the first frame update
    public static float elapsed = 0;
    int trailTime = 10;
    int generation = 1;
    GUIStyle guiStyle = new GUIStyle();
    private void OnGUI()
    {
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), "Gemeration: " + generation, guiStyle);
        GUI.Label(new Rect(10, 80, 100, 20), "Trial Time: " + (int)elapsed, guiStyle);


    }
    void Start()
    {
        for(int i=0;i<populationSize;i++)
        {
            Vector3 pos = new Vector3(Random.Range(-9f, 9f), Random.Range(-3.5f, 3.5f), 0);
            GameObject go = Instantiate(personPrefab, pos, Quaternion.identity);
            go.GetComponent<DNA>().r = Random.Range(0.0f, 1.0f);
            go.GetComponent<DNA>().g = Random.Range(0.0f, 1.0f);
            go.GetComponent<DNA>().b = Random.Range(0.0f, 1.0f);
            go.GetComponent<DNA>().s = Random.Range(0.1f, 0.3f);
            population.Add(go);
        }
       // DNA.instance.playerColor();
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if(elapsed>trailTime)
        {
            BreednewPopulation();
            elapsed = 0;
        }
    }
    public void BreednewPopulation()
    {
        List<GameObject> newPopulation = new List<GameObject>();
        List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<DNA>().timeToDie).ToList();
        population.Clear();
        for(int i=(int)(sortedList.Count/2.0f)-1; i<sortedList.Count-1; i++)
        {
            population.Add(Breed(sortedList[i], sortedList[i + 1]));
            population.Add(Breed(sortedList[i+1], sortedList[i ]));
        }
        for(int i=0;i<sortedList.Count;i++)
        {
            Destroy(sortedList[i]);
        }
        generation++;
    }
    GameObject Breed(GameObject parent1,GameObject parent2)
    {
        Vector3 pos = new Vector3(Random.Range(-9f, 9f), Random.Range(-3.5f, 3.5f), 0);
        GameObject offspring = Instantiate(personPrefab, pos, Quaternion.identity);
        DNA dna1 = parent1.GetComponent<DNA>();
        DNA dna2 = parent2.GetComponent<DNA>();
        offspring.GetComponent<DNA>().r = Random.Range(0, 10) < 5 ? dna1.r : dna2.r;
        offspring.GetComponent<DNA>().g = Random.Range(0, 10) < 5 ? dna1.g : dna2.g;
        offspring.GetComponent<DNA>().b = Random.Range(0, 10) < 5 ? dna1.b : dna2.b;
        offspring.GetComponent<DNA>().s = Random.Range(0, 10) < 5 ? dna1.s : dna2.s;
        return offspring;


    }


}
