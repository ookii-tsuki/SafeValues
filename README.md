<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#demo">Demo</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

This is a small project I have been working on for anti cheating in Unity Engine.
It allows you to protect your game from cheating tools but it doesn't protect its files from being ripped off.

###### Key Features
    * Hides variables in memory.
    * Encrypts and extends PlayerPrefs.
    * Detects speedhacks.


<!-- GETTING STARTED -->
## Getting Started

### Installation

* Download the [Latest release](https://github.com/med9999/SafeValues/releases/tag/1.0.1.0) then extract `SfVal.zip` and place the `SfVal.dll` and `SfVal.xml` files in Assets/Plugins of your project.


<!-- USAGE EXAMPLES -->
## Usage

### Safe Values

**These structs hide values from cheating tools by making an offset to them**

  * Example of hiding a float/integer from cheating tools.
   
    ```csharp
    using Med.SafeValue;
    using UnityEngine;

    public class Test : MonoBehaviour
    {
        SafeFloat speed = new SafeFloat(500f);
        SafeInt health = new SafeInt(100);

        public RigidBody rb;

        public void DealDamage(int amount)
        {
            health.Value -= amount;
        }
        void Update()
        {
            rb.velocity = Vector3.forward * speed.Value * Time.deltaTime;
        }
    }
    ```
    
### Player Saves

**This class saves and loads various data types and classes using AES encryption to playerprefs.**
    
  * Example of Encrypting/Decrypting and saving/loading a custom serializable class to/from PlayerPrefs using AES encryption
  
    ```csharp
    using Med.SafeValue;
    using UnityEngine;

    public class Test : MonoBehaviour
    {
        public Card card;

        void Awake()
        {
            //It is recommanded to set an encryption key, otherwise it is going to use a default key
            //Warning: always use the same key when encrypting or decrypting
            PlayerSaves.Key = "/A?D(G+KbPeShVmYq3t6w9z$C&E)H@Mc";
        }

        public void SaveCard()
        {
            PlayerSaves.EncryptClass(card, "card1");
        }
        public Card LoadCard()
        {
            return PlayerSaves.DecryptClass<Card>("card1");
        }

        [System.Serializable]
        class Card
        {
            public string title;
            public int number;
            public bool isLegendary;
        }
    }
    ```
  * Example of Encrypting/Decrypting and saving/loading values to/from PlayerPrefs using AES encryption
  
    ```csharp
    using Med.SafeValue;
    using UnityEngine;

    public class Test : MonoBehaviour
    {
        SafeFloat speed = new SafeFloat(500f);
        SafeInt health = new SafeInt(100);
        string title = "Plane 1";
        bool isActive = true;

        void Awake()
        {
            //It is recommanded to set an encryption key, otherwise it is going to use a default key
            //Warning: always use the same key when encrypting or decrypting
            PlayerSaves.Key = "/A?D(G+KbPeShVmYq3t6w9z$C&E)H@Mc";
        }

        public void SaveValues()
        {
            speed.Value.EncryptFloat("plSpeed");
            health.Value.EncryptInt("plHealth");
            title.EncryptString("plTitle");
            isActive.EncryptBool("plAct");
        }

        public void LoadValues()
        {
            speed.Value = PlayerSaves.DecryptFloat("plSpeed");
            health.Value = PlayerSaves.DecryptInt("plHealth");
            title = PlayerSaves.DecryptString("plTitle");
            isActive = PlayerSaves.DecryptBool("plAct");
        }
    }
    ```
### Anti-Speedhack

**This class detects speed hack attempts**

  * Example of setting up an anti speed hack to detect speed hacks
  
    ```csharp
    using Med.SafeValue;
    using UnityEngine;

    public class Test : MonoBehaviour
    {
        void Awake()
        {
            StartCoroutine(AntiSpeedHack.Start(CloseGame, 2f, true));
        }

        //This will be called if the AntiSpeedHack class detected a speed hack
        void CloseGame()
        {
            Application.Quit();
        }
    }
    ```
    
<!-- DEMO -->
## Demo

Try a WebGL [Demo](https://med9999.github.io/SafeValues/index.html)

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.

<!-- CONTACT -->
## Contact

Med Ben Chrifa - mohamed6aminbenchrifa@gmail.com

Project Link: [Safe Values](https://github.com/med9999/SafeValues)


