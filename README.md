## Adaptive UI Implementation Using UniRx and DI
###### Unity 2022.3.30f1
###### VContainer 1.16.8
###### UniRx 7.1.0
## Installers:
### GameInstaller - Registers all services.
## Services:
### AssetService - Handles resource loading logic.
### ScreenFactory - A factory for generating UI elements.
### StateMachineFactory - A factory for creating the GameStateMachine.
### GameStateMachine - A state machine for switching game states:
##### BootstrapState - The initial game state.
##### LoadState - In this state, resources are loaded and the Game scene is loaded.
##### GameState - The main game state; in this state, the MainUIController is loaded.
### LevelService - Handles level generation logic and rewards.
### SceneLoadService - Handles scene loading logic.
### StaticDataService - Loads and caches resources.
## Models:
### LevelModel - Contains level data, including the level number and a list of rewards.
### RewardModel - Contains reward data, including the reward type and amount.
## UI:
### UIRoot - The root element for the entire UI.
### MainUIController - Manages the display of the current level and the refresh level button.
### LevelPopupController - Manages the popup with the new level and rewards.
### RewardItemView - Displays the reward.