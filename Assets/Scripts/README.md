# Scripts

This directory contains all C# scripts for the game.

## Folder Structure

### Core/
Core game mechanics and systems:
- `CartController.cs` - Auto-scrolling cart movement and jump
- `GameManager.cs` - Main game state management
- `LevelManager.cs` - Level loading and progression

### Managers/
Singleton manager classes:
- `AudioManager.cs` - Audio playback and volume control
- `CoinManager.cs` - Coin collection and currency tracking
- `LivesManager.cs` - Lives system management
- `ScoreManager.cs` - Score calculation and tracking
- `SaveManager.cs` - Save/load game data
- `InputManager.cs` - Cross-platform input handling

### UI/
User interface scripts:
- `MainMenuUI.cs` - Main menu functionality
- `HUDController.cs` - In-game HUD updates
- `PauseMenuUI.cs` - Pause menu
- `ShopUI.cs` - Shop interface
- etc.

### Characters/
Character-related scripts:
- `CharacterData.cs` - Character definitions (ScriptableObject)
- `CharacterManager.cs` - Character selection and switching
- `CharacterAnimator.cs` - Character animations

### Obstacles/
Obstacle behavior scripts:
- `ObstacleBase.cs` - Base class for all obstacles
- `Hazard.cs` - Deadly obstacles
- `MovingPlatform.cs` - Moving obstacle logic
- `Pendulum.cs` - Swinging obstacles

### Collectibles/
Collectible item scripts:
- `Coin.cs` - Coin pickup logic
- `ExtraLife.cs` - Extra life pickup
- `PowerUp.cs` - Power-up base class

### Utilities/
Helper and utility scripts:
- `ObjectPooler.cs` - Object pooling for performance
- `CameraFollow.cs` - Camera tracking logic
- `ParallaxBackground.cs` - Background scrolling effect
- `Extensions.cs` - C# extension methods

## Coding Standards

- Use PascalCase for class names and public methods
- Use camelCase for private fields and local variables
- Prefix private fields with underscore (e.g., `_playerScore`)
- Add XML documentation comments for public methods
- Keep classes focused and single-purpose
- Use regions to organize code sections

## Example Script Template

```csharp
using UnityEngine;

namespace AdventuresOfTheWorld.Core
{
    /// <summary>
    /// Brief description of what this class does
    /// </summary>
    public class ExampleScript : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField] private float _speed = 5f;
        #endregion

        #region Private Fields
        private Rigidbody2D _rigidbody;
        #endregion

        #region Unity Lifecycle
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Update logic
        }
        #endregion

        #region Public Methods
        public void DoSomething()
        {
            // Implementation
        }
        #endregion

        #region Private Methods
        private void InternalMethod()
        {
            // Implementation
        }
        #endregion
    }
}
```
