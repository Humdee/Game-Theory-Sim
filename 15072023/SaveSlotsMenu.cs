using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{
    public static SaveSlotsMenu instance;
    [Header("Menu Navigation")]
    // [SerializeField] private MainMenu mainMenu;

    // [Header("Menu Buttons")]
    // [SerializeField] private Button backButton;

    [Header("Confirmation Popup")]
    // [SerializeField] private ConfirmationPopupMenu confirmationPopupMenu;

    private SaveSlot[] saveSlots;
    [SerializeField] SaveSlot firstSlot;

    // private bool isLoadingGame = false;

    private void Awake() 
    {
        instance = this;
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void Start()
    {
        DataPersistenceManager.instance.ChangeSelectedProfileId(firstSlot.GetProfileId());
        for (int i = 0; i < saveSlots.Length; i++)
        {
            saveSlots[i].line.SetActive(false);
        }
        saveSlots[firstSlot.publicId - 1].line.SetActive(true);
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot) 
    {
        // my edit
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        for (int i = 0; i < saveSlots.Length; i++)
        {
            saveSlots[i].line.SetActive(false);
        }
        saveSlots[saveSlot.publicId - 1].line.SetActive(true);
        // disable all buttons
        // DisableMenuButtons();

        // case - loading game
        // if (isLoadingGame) 
        // {
        //     DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        //     SaveGameAndLoadScene();
        // }
        // case - new game, but the save slot has data
        // else if (saveSlot.hasData) 
        // {
        //     confirmationPopupMenu.ActivateMenu(
        //         "Starting a New Game with this slot will override the currently saved data. Are you sure?",
        //         // function to execute if we select 'yes'
        //         () => {
        //             DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        //             DataPersistenceManager.instance.NewGame();
        //             SaveGameAndLoadScene();
        //         },
        //         // function to execute if we select 'cancel'
        //         () => {
        //             this.ActivateMenu(isLoadingGame);
        //         }
        //     );
        // }
        // case - new game, and the save slot has no data
        // else 
        // {
        //     DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        //     DataPersistenceManager.instance.NewGame();
        //     SaveGameAndLoadScene();
        // }
    }

    private void SaveGameAndLoadScene() 
    {
        // save the game anytime before loading a new scene
        DataPersistenceManager.instance.SaveGame();
        // load the scene
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void OnClearClicked(SaveSlot saveSlot) 
    {
        // DisableMenuButtons();

        // confirmationPopupMenu.ActivateMenu(
        //     "Are you sure you want to delete this saved data?",
        //     // function to execute if we select 'yes'
        //     () => {
                DataPersistenceManager.instance.DeleteProfileData(saveSlot.GetProfileId());
                // ActivateMenu(isLoadingGame);
                ActivateMenu();
        //     },
        //     // function to execute if we select 'cancel'
        //     () => {
        //         ActivateMenu(isLoadingGame);
        //     }
        // );
    }

    public void OnBackClicked() 
    {
        // mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    // public void ActivateMenu(bool isLoadingGame)
    public void ActivateMenu()
    {
        // set this menu to be active
        this.gameObject.SetActive(true);

        // set mode
        // this.isLoadingGame = isLoadingGame;

        // load all of the profiles that exist
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();

        // ensure the back button is enabled when we activate the menu
        // backButton.interactable = true;

        // loop through each save slot in the UI and set the content appropriately
        // GameObject firstSelected = backButton.gameObject;
        foreach (SaveSlot saveSlot in saveSlots) 
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            // if (profileData == null && isLoadingGame) 
            // {
            //     saveSlot.SetInteractable(false);
            // }
            // else 
            // {
            //     saveSlot.SetInteractable(true);
            //     if (firstSelected.Equals(backButton.gameObject))
            //     {
            //         firstSelected = saveSlot.gameObject;
            //     }
            // }
        }

        // set the first selected button
        // Button firstSelectedButton = firstSelected.GetComponent<Button>();
        // this.SetFirstSelected(firstSelectedButton);
    }

    public void DeactivateMenu() 
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons() 
    {
        foreach (SaveSlot saveSlot in saveSlots) 
        {
            saveSlot.SetInteractable(false);
        }
        // backButton.interactable = false;
    }
}