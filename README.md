<img src="https://i.ibb.co/fdT88SY2/Capture-d-cran-2025-05-26-155537-removebg-preview.png"/>

This is a modular and extensible Brick Breaker game built with Unity. It features a main menu system, audio management, dynamic brick generation using design patterns, and player movement using the Command pattern.

---

## Features

### Main Menu & UI

- Scene loading with additive mode (`Play`, `Options`, `Credits`)
- Floating animation for the title
- Visual feedback on button hover and selection (font change)
- Close additive scenes with a dedicated close button

### Music Management

- **AudioManager (Singleton):** persistent music across scenes
- **MenuMusic:** plays context-specific music for each scene (`Menu`, `Ingame`, etc.)
- **MusicType enum:** defines the music types available

### Brick Generation (Factory & Layout System)

- **BrickFactory:** central class to spawn bricks of different types
- **BrickFactoryData:** a ScriptableObject that holds prefab references for:
  - Standard bricks
  - Bonus bricks
  - Unbreakable bricks
- **BrickFactoryInitializer:** initializes the factory with a container to keep the scene hierarchy clean

### Layout Strategy & Spawning

- **ArkanoidLayoutStrategy:** a layout inspired by the classic Arkanoid game
- Dynamically places a limited number of bonus bricks per row
- Keeps brick colors consistent per row, including bonus bricks
- Extendable via the `IBrickLayoutStrategy` interface

### Brick Types

| Type        | Class             | Description                          |
|-------------|-------------------|--------------------------------------|
| Standard    | `StandardBrick`    | Can be destroyed after a set number of hits |
| Bonus       | `BonusBrick`       | Spawns a bonus when destroyed        |
| Unbreakable | `UnbreakableBrick` | Cannot be destroyed                  |

All bricks inherit from `ABrick`, which defines the common interface (`Hit()` method).

### Player Movement (Command Pattern)

- Uses the **Command pattern** to encapsulate player actions
- `InputHandler` interprets input and instantiates movement commands (`MoveCommand`)
- Prepares the architecture for future features like undo or replay systems

### Screen Boundary Clamping

- `ScreenBoundaries` ensures the player cannot move outside the screen using `ViewportToWorldPoint`

---

## Design Patterns Used

| Pattern     | Implementation               | Benefit                              |
|-------------|-------------------------------|---------------------------------------|
| Singleton   | `AudioManager`                | Global instance, persists between scenes |
| Factory     | `BrickFactory`                | Modular creation of different brick types |
| Strategy    | `ArkanoidLayoutStrategy`      | Interchangeable layout generation      |
| Command     | `MoveCommand`, `InputHandler` | Decouples input from execution logic  |

---

## Testing Checklist

- [x] Additive scenes load and close correctly
- [x] Music switches dynamically per scene
- [x] Button UI responds visually on interaction
- [x] Layout generates correctly with capped bonus bricks per row
- [x] Bricks respond properly to `Hit()` calls
- [x] Player stays within screen bounds

---

## Technologies

- Unity 6000.0.27f1
- C# (using Unity coding conventions)
- Unity Input System
- TextMeshPro (TMP)

---

## Upcoming Features

- Ball and collision system
- Visual effects when bricks are destroyed
- Bonus types: paddle extension, score multipliers, etc.
- In-game UI (score, lives, progress)

---

## Contribution
- **Mathys MECHAIN**
- **Damien ESMIEU**
- **Johanne HUET**
---

## License 
Feel free to use it for personal and educational purposes.
