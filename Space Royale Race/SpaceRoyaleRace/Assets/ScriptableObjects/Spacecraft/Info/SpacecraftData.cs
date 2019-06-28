using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEditor;




[CreateAssetMenu(fileName = "New Spacecraft Data", menuName = "Spacecraft", order = 51)]
[System.Serializable]
public class SpacecraftData : ScriptableObject
{
    //Spacecraft string info
    [SerializeField]
    new string name;
    [SerializeField] GameObject spacecraft;
    [TextArea] [SerializeField] string description;
    [Space][Space] //Health related variables
    [SerializeField] float health;
    [Space]
    [SerializeField] float shield;
    [SerializeField] float shieldRecovery;
    [Space][Space] //Movement related variables
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;
    [Space][Space] //Rotation related variables
    [SerializeField] float yaw;
    [SerializeField] float roll;
    [Space][Space][Space][Space] //Spaces for unlcked bool in editor
    [SerializeField] bool locked;
    [SerializeField] uint cost;



    /// <summary>
    /// Returns the Spacecraft's name
    /// </summary>
    public string Name
    {
        get { return name; }
    }
    /// <summary>
    /// Returns the Spacecraft's description
    /// </summary>
    public string Description
    {
        get { return description; }
    }
    /// <summary>
    /// Returns the Spacecraft's health
    /// </summary>
    public float Health
    {
        get { return health; }
    }
    /// <summary>
    /// Returns the Spacecraft's shield
    /// </summary>
    public float Shield
    {
        get { return shield; }
    }
    /// <summary>
    /// Returns the Spacecraft's shield recovery rate
    /// </summary>
    public float RecoveryRate
    {
        get { return shieldRecovery; }
    }
    /// <summary>
    /// Returns the Spacecraft's minimum speed
    /// </summary>
    public float MinimumSpeed
    {
        get
        {
            if(minSpeed <= 0)
            {
                minSpeed = 0.001f;
            }
            return minSpeed;
        }
    }
    /// <summary>
    /// Returns the Spacecraft's maximum speed
    /// </summary>
    public float MaximumSpeed
    {
        get { return maxSpeed; }
    }
    /// <summary>
    /// Returns the Spacecraft's acceleration
    /// </summary>
    public float Acceleration
    {
        get { return acceleration; }
    }
    /// <summary>
    /// Returns the Spacecraft's yaw force
    /// </summary>
    public float Yaw
    {
        get { return yaw; }
    }
    /// <summary>
    /// Returns the Spacecraft's roll force
    /// </summary>
    public float Roll
    {
        get { return roll; }
    }
    /// <summary>
    /// Returns wether the spacecraft is locked or not
    /// </summary>
    public bool Locked
    {
        get { return locked; }
        set { value = locked; }
    }
    /// <summary>
    /// Returns the Spacecraft's GO
    /// </summary>
    public GameObject Spacecraft
    {
        get { return spacecraft; }
    }


    /// <summary>
    /// Save this object
    /// </summary>
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/SC_Data/" + name;

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, this);
        stream.Close();
        
    }
    /// <summary>
    /// Load this object
    /// </summary>
    public void Load()
    {
        string path = Application.persistentDataPath + "/SC_Data/" + name;


        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SpacecraftData data = formatter.Deserialize(stream) as SpacecraftData;
            stream.Close();

            
            this.name = data.name;
            this.description = data.description;
            this.health = data.health;
            this.minSpeed = data.minSpeed;
            this.maxSpeed = data.maxSpeed;
            this.yaw = data.yaw;
            this.roll = data.roll;
            this.locked = data.locked;
            this.cost = data.cost;
        }
    }
}

