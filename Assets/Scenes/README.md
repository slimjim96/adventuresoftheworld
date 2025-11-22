# Scenes

This directory contains all Unity scene files for the game.

## Scene Organization

- **MainMenu.unity** - Main menu scene
- **LevelSelect.unity** - Level selection screen
- **Gameplay.unity** - Core gameplay scene (used for all levels)
- **Shop.unity** - Shop/upgrade screen
- **Settings.unity** - Settings menu
- **CharacterSelect.unity** - Character selection screen

## Naming Convention

- Use PascalCase for scene names
- Prefix level scenes with world name (e.g., `Forest_Level_1.unity`)
- Keep scene names descriptive and consistent

## Notes

- The Gameplay scene will load level data dynamically
- All scenes should be added to Build Settings
- Test scenes should be prefixed with `Test_`
