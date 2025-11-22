# Audio

This directory contains all audio assets for the game.

## Folder Structure

### Music/
Background music tracks (looping):
- `menu_theme.mp3` - Main menu music
- `forest_theme.mp3` - Forest levels background music
- `mountain_theme.mp3` - Mountain levels
- `desert_theme.mp3` - Desert levels
- `underwater_theme.mp3` - Underwater levels
- `ocean_theme.mp3` - Ocean levels
- `victory_jingle.mp3` - Level complete celebration
- `game_over.mp3` - Game over music

### SFX/
Sound effects (short, one-shot sounds):
- `jump.wav` - Player jump sound
- `land.wav` - Cart landing sound
- `coin_collect.wav` - Coin pickup
- `death.wav` - Collision/death sound
- `extra_life.wav` - Extra life pickup
- `button_click.wav` - UI button press
- `level_complete.wav` - Reaching finish line
- `star_earn.wav` - Star rating awarded
- `purchase.wav` - Shop purchase confirmation

## Audio Guidelines

### Format Recommendations
- **Music**: MP3 or OGG (compressed, looping)
  - Bitrate: 128-192 kbps
  - Sample Rate: 44.1 kHz
  - Stereo

- **SFX**: WAV or OGG (short duration)
  - Bitrate: Uncompressed or 96 kbps
  - Sample Rate: 44.1 kHz
  - Mono (for non-positional sounds)

### Unity Import Settings
- **Load Type**:
  - Music: Streaming (for long tracks)
  - SFX: Decompress on Load (for short sounds)

- **Compression Format**:
  - PC: Vorbis
  - Mobile: Vorbis or ADPCM

- **Quality**: 70-100% (balance file size vs quality)

### Naming Convention
- Use lowercase with underscores
- Be descriptive: `enemy_death.wav`, `coin_collect_01.wav`
- Number variations: `footstep_01.wav`, `footstep_02.wav`

## Music Guidelines

### Loop Points
- Ensure seamless looping (start and end match)
- Export with loop markers if possible
- Typical length: 60-120 seconds per track

### Volume Levels
- Normalize music to -6dB to -3dB
- Leave headroom for SFX
- Keep consistent volume across all tracks

### Tempo Matching
- Match music tempo to game pace:
  - Forest: 90-110 BPM (calm, introductory)
  - Mountain: 110-130 BPM (adventurous)
  - Desert: 120-140 BPM (energetic)
  - Underwater: 80-100 BPM (flowing, ethereal)
  - Ocean: 130-150 BPM (epic, triumphant)

## SFX Guidelines

### Volume Balancing
- Normalize SFX to consistent levels
- UI sounds: Quieter (-12dB to -18dB)
- Gameplay sounds: Medium (-6dB to -12dB)
- Important events: Louder (-3dB to -6dB)

### Variety
- Create 2-3 variations for frequently played sounds
- Randomly pitch-shift in code for more variety
- Avoid listener fatigue

## Royalty-Free Sources

### Music
- [Incompetech](https://incompetech.com) - Kevin MacLeod
- [FreePD](https://freepd.com) - Public domain music
- [Purple Planet](https://www.purple-planet.com) - Royalty-free tracks

### Sound Effects
- [Freesound.org](https://freesound.org) - Community SFX library
- [OpenGameArt.org](https://opengameart.org) - Game audio assets
- [ZapSplat](https://www.zapsplat.com) - Free SFX (with attribution)
- [Kenney.nl](https://kenney.nl/assets) - Game assets including audio

## Attribution

When using royalty-free assets, track attributions in a separate file:
- Create `AUDIO_CREDITS.txt` in this directory
- List each asset with source and license
- Include in game credits screen

## Placeholder Audio

During development, use:
- Simple beeps/boops for SFX
- Royalty-free placeholder music
- Text-to-speech for voice (if needed)

Replace with final audio during polish phase (Month 3).
