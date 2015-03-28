# About #

XonarSwitcher is a simple utility for switching audio output on Xonar audio cards. If you hate to use the [Asus Audio Center](http://xonarswitcher.googlecode.com/files/audiocenter.png) for such simple tasks, this is your alternative. It's written in C# and currently it only works with Xonar Essence STX cards on 64 bit Windows.

![http://xonarswitcher.googlecode.com/files/xonarswitcher.png](http://xonarswitcher.googlecode.com/files/xonarswitcher.png)

# Download #

  * [XonarSwitcher 1.0](http://xonarswitcher.googlecode.com/files/XonarSwitcher%201.0.exe)

# Technical #

  * Essence STX
    * `PCI\VEN_13F6&DEV_8788&SUBSYS_835C1043&REV_00`
    * `HKLM\SYSTEM\CurrentControlSet\Control\Class\{4D36E96C-E325-11CE-BFC1-08002BE10318}\0007\Settings\SpeakerConfig`
      * `hex:01,00,00,00`: Headphones
      * `hex:04,00,00,00`: Speakers