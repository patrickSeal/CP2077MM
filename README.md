# Cyberpunk 2077 Mod Manager
An open-source mod manager for Cyberpunk 2077. Install and delete your mods with a beautiful user interface. The manager informs you about the requirements that you need and keeps track of all the files installed by mods, to safely remove them at any time.

### Version 0.2.0-alpha is out right now!

### Important
This is a pre-release and therefore lacks many features that I want to add in the future.
But the basic functionality is there, for installing, deleting and informing about the mods you want to use.

## Installation
1. Download the zip file from NexusMods
2. Extract the zip file
3. Run the "CP2077MM.exe" file


## Currently supported features
- Installing mods from zip/rar archives (into the standard directory)
- Deleting mods safely
- Informing about requirements when installing a mod
- Informing about requirements of installed mods, if not installed
- Uses NexusModsAPI for metadata information about the mods
- Verifys a mod with NexusMods hash
- Update information for all your installed mods

## Features in Development
- Working: adding a feature to change the load order of different archive files
- Working: adding a feature to scan for already installed mods (profiler is already done, analysis in development)
- Paused: adding non standard installation options for mods (maybe through json file provided by the mod author or the mod manager)

## Features that potentially will be added in the future
 - Managing config files of mods
- Downloading and updating mods using the manager (only for NexusMods Premium users)
- Many more things...

## Deinstallation
1. Delete the directory where you installed the mod manager
2. Delete the "CP2077ModManager" directory in "C:\ProgramData\"

If you have a feature request or encounter any useability breaking bugs or have any questions, please leave an issue or open a discussion.
