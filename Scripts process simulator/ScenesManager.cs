using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    private void Awake() {
        instance = this;
    }
    public enum Scene
    {
        LoginScene,
        SynopsisScene,
        FreelancerScene,
        AssessorScene,
        ModelScene,
        SimulationScene,
        ConclusionScene
    }
    // for jumping scene back and forth
    public void LoadScene(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }
    // load any next scene
    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // load login scene
    public void LoadLoginMenu() {
        SceneManager.LoadScene(Scene.LoginScene.ToString());
    }
}
