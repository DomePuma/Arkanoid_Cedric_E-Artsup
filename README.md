<img src="https://i.ibb.co/fdT88SY2/Capture-d-cran-2025-05-26-155537-removebg-preview.png"/>

A modular, extensible Brick Breaker game built with Unity, following clean architecture principles and design patterns. Includes dynamic UI, audio management, flexible brick and ball systems, and player controls bounded by the screen.

---

## Features

### Main Menu & UI

* Additive scene loading (`Play`, `Options`, `Credits`)
* Title floating animation
* Visual feedback on buttons (font changes on hover/selection)
* Additive scenes can be closed with a dedicated `X` button

### Music Management

* `AudioManager` (Singleton): handles music persistence between scenes
* `MenuMusic`: specific music tracks based on current scene (`Menu`, `Ingame`, etc.)
* `MusicType` enum allows easy addition of new music contexts

### Brick System (Factory & Layout Strategy)

* `BrickFactory` creates different brick types
* `BrickFactoryData` holds prefab references
* `ArkanoidLayoutStrategy` generates brick rows and limits the number of bonus bricks per row
* Bricks in each row share the same color for visual consistency

| Type        | Class              | Description                          |
| ----------- | ------------------ | ------------------------------------ |
| Standard    | `StandardBrick`    | Destroyed after a set number of hits |
| Bonus       | `BonusBrick`       | Spawns a bonus on destruction        |
| Unbreakable | `UnbreakableBrick` | Cannot be destroyed                  |

All bricks inherit from `ABrick`, which exposes a `Hit()` interface.

### Ball System (Factory, Base Class, Types)

* `BallFactory` handles instantiation of different ball types
* `BallFactoryData` contains prefabs for base and multi balls
* `BallSpawner` creates a ball at the defined position
* Ball bounces off the paddle, bricks, and screen boundaries
* Shared behavior is implemented in `ABall`, an abstract base class

| Type  | Class       | Behavior                                   |
| ----- | ----------- | ------------------------------------------ |
| Base  | `BallBase`  | Respawns a new ball when destroyed         |
| Multi | `BallMulti` | Simply gets destroyed without consequences |

### Player Movement (Command Pattern)

* Uses the command pattern to decouple input handling from movement logic
* `InputHandler` creates `MoveCommand` instances
* Prepares the system for advanced features like undo, replay, or input logging

### Screen Boundary Clamping

* `ScreenBoundsSystem` defines screen limits using a ScriptableObject
* `PlayerScreenBoundaries` ensures player movement stays within the screen
* Ball bouncing system also respects the same bounds

---

## Design Patterns Used

| Pattern   | Used In                       | Benefit                              |
| --------- | ----------------------------- | ------------------------------------ |
| Singleton | `AudioManager`                | Global persistent instance           |
| Factory   | `BrickFactory`, `BallFactory` | Centralized prefab creation          |
| Strategy  | `IBrickLayoutStrategy`        | Easily interchangeable layouts       |
| Command   | `MoveCommand`, `InputHandler` | Decouples input logic from execution |

---

## Testing Checklist

* [x] Additive scenes load and close correctly
* [x] Music changes dynamically per scene
* [x] Buttons provide visual feedback
* [x] Bricks correctly respond to `Hit()` events
* [x] Layout strategy properly limits bonus bricks per row
* [x] Balls bounce and destroy bricks as expected
* [x] Base ball regenerates when falling
* [x] Player and balls stay within screen boundaries

---

## Technologies

* Unity 6000.0.27f1
* C# (Eartsup conventions) https://pastebin.com/ZbTgSgNx
* Unity Input System
* TextMeshPro (TMP)

---

## Upcoming Features

* Brick and ball collision effects (visual feedback)
* Bonus system (paddle size boost, score multiplier, etc.)
* In-game UI (score, lives, level tracker)
* Replay and Undo system using command history
* Additional ball types (e.g., fireball, splitting ball)

---

## Contributors

* Mathys MECHAIN
* Damien ESMIEU
* Johanne HUET

---

## License

Free to use for personal and educational purposes.
