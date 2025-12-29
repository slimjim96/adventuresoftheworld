# Prefabs

This directory contains all Unity prefab assets for reusable game objects.

## Folder Structure

### Characters/
- `Lion.prefab` - Lion character with animations
- `Bunny.prefab` - Bunny character
- `Duck.prefab` - Duck character
- `Mouse.prefab` - Mouse character
- `Cart.prefab` - Player's cart vehicle

### Obstacles/
- `Gap.prefab` - Empty space obstacle
- `Barrier_Low.prefab` - Low barrier to jump over
- `Barrier_High.prefab` - Higher barrier
- `Spike.prefab` - Hazard obstacle
- `Pit.prefab` - Death pit
- `MovingPlatform.prefab` - Moving platform obstacle
- `Pendulum.prefab` - Swinging pendulum obstacle
- `Rock.prefab` - Static rock obstacle

### Collectibles/
- `Coin.prefab` - Standard coin pickup
- `CoinBunch.prefab` - Group of coins (3-5 coins)
- `ExtraLife.prefab` - Heart/life pickup
- `PowerUp_Shield.prefab` - Shield power-up (future)
- `PowerUp_Magnet.prefab` - Coin magnet (future)

### UI/
- `HUD.prefab` - Heads-up display
- `PauseMenu.prefab` - Pause menu overlay
- `LevelCompleteScreen.prefab` - Victory screen
- `GameOverScreen.prefab` - Game over screen
- `LoadingScreen.prefab` - Loading transition

### Effects/
- `Particle_Dust.prefab` - Jump/land dust effect
- `Particle_CoinSparkle.prefab` - Coin collection sparkle
- `Particle_Explosion.prefab` - Death explosion
- `Particle_Stars.prefab` - Star rating effect
- `Particle_Confetti.prefab` - Level complete celebration

## Prefab Guidelines

### Creation Best Practices
1. **Modularity**: Keep prefabs self-contained and reusable
2. **Variants**: Use Prefab Variants for variations of base prefabs
3. **Components**: Attach all necessary scripts and components
4. **Serialization**: Set default values in Inspector
5. **Testing**: Test prefabs in isolation before using in scenes

### Naming Convention
- Use PascalCase: `MovingPlatform.prefab`
- Group related prefabs with common prefix: `Enemy_Goblin.prefab`, `Enemy_Orc.prefab`
- Use descriptive names that indicate purpose

### Organization
- One prefab per file
- Group related prefabs in subfolders
- Keep hierarchy shallow (max 3 levels)

### Performance Considerations
- **Object Pooling**: Frequently spawned prefabs (coins, obstacles) should be pooled
- **Colliders**: Use simple colliders (Box, Circle) over Polygon when possible
- **Scripts**: Minimize GetComponent() calls; cache references
- **Sprites**: Use sprite atlases to reduce draw calls

## Common Prefab Patterns

### Obstacle Prefab Structure
```
ObstacleName
├── Sprite (SpriteRenderer)
├── Collider (BoxCollider2D or CircleCollider2D)
├── ObstacleScript (custom behavior)
└── Audio Source (optional, for obstacle-specific sounds)
```

### Collectible Prefab Structure
```
CollectibleName
├── Sprite (SpriteRenderer)
├── Trigger Collider (IsTrigger = true)
├── Animator (for spin/idle animation)
├── CollectibleScript (OnTriggerEnter2D logic)
└── Particle Effect (child object)
```

### UI Prefab Structure
```
UIElement
├── Canvas (if root UI element)
├── Panel (background)
├── Text (TextMeshPro)
├── Buttons
│   ├── Button (with UI script attached)
│   └── Text (button label)
└── Images/Icons
```

## Prefab Variants

Use **Prefab Variants** for creating variations:

**Example**: Base obstacle → Environment-specific variants
- `Obstacle_Base.prefab` (base)
  - `Obstacle_Forest.prefab` (variant with forest sprite)
  - `Obstacle_Desert.prefab` (variant with desert sprite)

This allows updating shared behavior in the base while maintaining unique visuals.

## Testing Prefabs

Create a test scene: `Assets/Scenes/Test_Prefabs.unity`
- Drag prefabs into the scene
- Test behavior in isolation
- Verify collision, animations, and scripts
- Delete test objects before committing

## Version Control Notes

- Prefabs are stored as YAML in Unity
- Be careful with merge conflicts (hard to resolve manually)
- Prefer small, focused prefabs to minimize conflicts
- Communicate with team when editing shared prefabs
