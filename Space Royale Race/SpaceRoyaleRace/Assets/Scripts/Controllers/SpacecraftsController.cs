using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacecraftsController : MonoBehaviour
{
    [SerializeField]
    List<SpacecraftData> spacecrafts;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(SpacecraftData spacecraft in spacecrafts)
        {
            spacecraft.Load();
        }

    }

    public void UnlockSpacecraft(int id)
    {
        spacecrafts[id].Locked = false;
        spacecrafts[id].Save();
    }

    public void LockSpacecraft(int id)
    {
        spacecrafts[id].Locked = true;
        spacecrafts[id].Save();
    }
    public List<SpacecraftData> Spacecrafts
    {
        get { return spacecrafts; }
    }
    public List<SpacecraftData> CheckLocked()
    {
        List<SpacecraftData> list = new List<SpacecraftData>();
        foreach(SpacecraftData spacecraft in spacecrafts)
        {
            if (spacecraft.Locked)
            {
                list.Add(spacecraft);
            }
        }
        return list;
    }
}
