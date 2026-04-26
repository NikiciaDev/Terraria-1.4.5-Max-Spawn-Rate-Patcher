# Terraria Journey Mode Spawn Rate Patcher

Patches `Terraria.exe` to increase the maximum spawn rate multiplier in Journey Mode from **x10** to **x50**.

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (any recent version)
- Terraria 1.4.5 (other versions untested)
- Linux or Windows

## Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/terraria-patch
   cd terraria-patch
   ```

2. Install dependencies:
   ```bash
   dotnet add package Mono.Cecil
   ```

## Usage

1. Open `Program.cs` and update the `exe` variable to point to your `Terraria.exe`:
   ```csharp
   var exe = "/path/to/your/steamapps/common/Terraria/Terraria.exe";
   ```
   Common paths:
   - **Linux:** `/home/USERNAME/.steam/steam/steamapps/common/Terraria/Terraria.exe`
   - **Windows:** `C:\Program Files (x86)\Steam\steamapps\common\Terraria\Terraria.exe`

2. Make sure Terraria is **closed**.

3. Run the patcher:
   ```bash
   dotnet run
   ```

4. Launch Terraria. The Journey Mode spawn rate slider will now go up to **x50**.

## Restoring the original

Verify the game files via Steam to restore the original `Terraria.exe`:
- Right-click Terraria in Steam → Properties → Installed Files → Verify integrity of game files

## Notes

- If you want a different max multiplier, change `50f` and `"x50"` in `Program.cs` to your desired value.
- The patcher searches for the current max value (`10f`) so if you run it twice it will not find it and nothing will be patched. Verify game files first if you want to re-patch.
