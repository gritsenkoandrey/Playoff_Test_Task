# Реализация адаптивного UI с использованием UniRx и DI
###### Unity 2022.3.30f1
###### VContainer 1.16.8
###### UniRx 7.1.0
## Installers:
### GameInstaller - регистрирует все сервисы.
## Services:
### AssetService - логика загрузки ресурсов.
### ScreenFactory - фабрика для генерации UI элементов.
### StateMachineFactory - фабрика для создания GameStateMachine.
### GameStateMachine - стейт машина для переключения состояний игры:
##### BootstrapState - стартовый стейт игры.
##### LoadState - в этом стейте идет загрузка ресурсов и загружается Game сцена.
##### GameState - игровой стейт, в данном стейте загружается MainUIController.
### LevelService - логика генерация уровня и награды.
### SceneLoadService - логика загрузки сцен.
### StaticDataService - сервис который загружает ресурсы и кэширует их.
## Models:
### LevelModel - данные уровня, в котором содержится номер уровня и список наград.
### RewardModel - данные о награде, где содердится вид награды и количество.
## UI:
### UIRoot - рутовый элемент для всего UI.
### MainUIController - управление тестом текущего уровня и кнопкой обновления уровня.
### LevelPopupController - управление окном с новым уровнем и наградами.
### RewardItemView - отображение награды.