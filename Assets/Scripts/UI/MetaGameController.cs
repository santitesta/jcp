using Platformer.Mechanics;
using Platformer.UI;
using UnityEngine;

namespace Platformer.UI
{
    /// <summary>
    /// The MetaGameController is responsible for switching control between the high-level
    /// contexts of the application, e.g., the Main Menu and Gameplay systems.
    /// </summary>
    public class MetaGameController : MonoBehaviour
    {
        /// <summary>
        /// The main UI object which is used for the menu.
        /// </summary>
        public MainUIController mainMenu;

        /// <summary>
        /// A list of canvas objects which are used during gameplay (when the main UI is turned off).
        /// </summary>
        public Canvas[] gamePlayCanvasii;

        /// <summary>
        /// The game controller.
        /// </summary>
        public GameController gameController;

        bool showMainCanvas = false;

        void OnEnable()
        {
            // Check if menu functionality is available, otherwise log a warning and skip
            if (mainMenu == null && (gamePlayCanvasii == null || gamePlayCanvasii.Length == 0))
            {
                Debug.LogWarning("No main menu or gameplay canvases are configured. Skipping UI initialization.");
                return;
            }

            _ToggleMainMenu(showMainCanvas);
        }

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (this.showMainCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        void _ToggleMainMenu(bool show)
        {
            // Handle missing references gracefully
            if (mainMenu != null)
            {
                mainMenu.gameObject.SetActive(show);
            }

            if (gamePlayCanvasii != null)
            {
                foreach (var canvas in gamePlayCanvasii)
                {
                    if (canvas != null)
                    {
                        canvas.gameObject.SetActive(!show);
                    }
                }
            }

            Time.timeScale = show ? 0 : 1; // Pause game if menu is active
            this.showMainCanvas = show;
        }

        void Update()
        {
            // Handle menu toggle input only if the menu exists
            if (mainMenu != null && Input.GetButtonDown("Menu"))
            {
                ToggleMainMenu(show: !showMainCanvas);
            }
        }
    }
}
