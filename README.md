# RiderBlockJumper

[![Rider](https://img.shields.io/jetbrains/plugin/v/RIDER_PLUGIN_ID.svg?label=rider%20&colorB=0A7BBB&style=flat-square&logo=%20data%3Aimage%2Fpng%3Bbase64%2CiVBORw0KGgoAAAANSUhEUgAAADAAAAAsCAYAAAAjFjtnAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAAZdEVYdFNvZnR3YXJlAHBhaW50Lm5ldCA0LjAuMjHxIGmVAAAEEklEQVRoQ%2B2ZS0hUURjHLSoKominVIta1aLaFYhBES1t1bLFRCAREbQKaiHpqgeEpjDjRhIFHWwzIyo6oWXqwmfkW0evr9TxNT7GcZxX%2FzPzzZk53jsyc%2B91I%2FcHB4a5%2F%2B%2B79z%2Fn3O98RzOOBKFQ6BeGlOrw%2B%2F2S0%2Bn83dXV9a6srOwSpUlKfX19yvnn5%2BelwcFBW09Pz8uamporlOJgEOgMq2R7ezuAm33Cx%2BOUTgYMqMq%2Ft7cX7O3t7QbXKJUyWgzEWFhYaMONTlJKAbUGYvh8vjBymy0Wi2J%2BXQwwxsbGvlFKAa0GGHjG8Nra2nd8lM%2B0kgGPx9OK76sSx9LSkgNrfyMQCOySTAAxodLS0uuUlqNkAPnG9%2BdfWVlxLC8vs%2FxBkskYHx%2B3Udo4CJbdoKqqKpcuy8DLmzU3N%2FeTpAJTU1MfSMZRMoBCYKHLMhwOx12YacBzkVpkeHjYRNIo6RpgsPXodrtdJOdgvdpJwknXQIyRkZE3mA2KiIP7LqJCnSGZOgMM3MBOcg5y6WaAsb6%2B%2Fp5CBDo7O5%2BSRL0BTOWhG2hpaTnt9Xr%2FURhndna2lSTqDWxtbUkk50xOTupqgDE9PV1AYZzV1VVXXl5etKyma6C8vDwTJa2GpALY1J6QjKPVAGY6l8I4mJVwR0dH9D1QMtDW1ubCjaXE0dDQIA0MDEj45f0kE0DlmMeUn4gkTUCrgYqKCpkBxszMTHID6YJq4cVU50QS7kOrAZvNJjOAZ9bPAHoWT3Nz84tIMgW0GsC%2B84rCOFjCYV5K1RpgPQo2tKbi4uLbkURJ0GoALUo3hXHQRP7BpWMRgZIBrGcPpmgjNjY3N2XtA16knb6%2BvouRJAegxUB1dXVuMCjvLCYmJspIomwA3wlVqL29PXt3d1e2t6MeD%2BTn58te3ETUGkDByMTyHKMQDmL9drv9FslSM8DAzvuRLgtgjX4miSJqDOCdugfNKMkFJElqIlmUVA0w0PdPkISDmQk3NjZmk0SGkgF0tq2VlZWm2ECpNFmtVtPi4uJzLN8fuD8pRdBa%2BIaGhrIodZR0DKCk5WBafSTj4IEmMeWnSCagZEANmBEPVsEDShsnHQOM%2Fv7%2BLyQTQPKvJBHQwwCqjhet%2Bn1KKZKuAfQg51GH%2F5KUw5bS6OjoHZJxtBjAr876q14ssxuUTk66Bhg4dNzECYzUcbAv7KCPukCyCGoMIPcaGjYrK6NIEa33ycBb%2FRhtgClx4EEu0%2BWkoPo83B%2FHBo59QqzZbH4LE7UHjbq6ulpsjM9QJEwFBQWPlHoqAwMDAwMDAwODo0hJScnZoqKic3oOHPST%2Fs9Md1wulxMjrNfAuZYdbK5S%2BsNH6UCjBfZ3HJgwDKQMDLzGKNRrwECh2%2B0WjpUGimRk%2FAdgThdOY4UJ9QAAAABJRU5ErkJggg%3D%3D)](https://plugins.jetbrains.com/plugin/RIDER_PLUGIN_ID)

RiderBlockJumper is an extension for Rider that allows you to jump over blocks of code. Available on the [JetBrains Plugins Repository](https://plugins.jetbrains.com/plugin/RIDER_PLUGIN_ID).

![Demo](./media/demo.gif?raw=true "Demo")

# Usage

Jumping takes you outside of the nearest block edge (i.e. the whitespace line adjacent to a block). If the cursor reaches BOF or EOF, we jump there instead.

## Commands

Due to existing keybindings within Rider, I was unable to provide my ideal default keybindings. I've listed my preferences here, and encourage you to update your keybindings by assigning your own actions (`Ctrl + Shift + A`).

| Command               | Description                                     | Keybinding (Default) | Keybinding (Ideal) |
|:--------------------- |:----------------------------------------------- |:-------------------- |:------------------ |
| `Edit.JumpUp`         | Jump to the closest block edge above the cursor | `Alt+Page Up`        | `Ctrl+Up`          |
| `Edit.JumpDown`       | Jump to the closest block edge below the cursor | `Alt+Page Down`      | `Ctrl+Down`        |
| `Edit.JumpSelectUp`   | Jump Up and add to the active selection         | `Alt+Shift+Page Up`  | `Ctrl+Shift+Up`    |
| `Edit.JumpSelectDown` | Jump Down and add to the active selection       | `Alt+Shift+Page Down`| `Ctrl+Shift+Down`  |

## Settings

Settings can be found under `File>Settings...>Editor>Block Jumper`

| Setting           | Description                                                                                                                   | Default |
|:----------------- |:----------------------------------------------------------------------------------------------------------------------------- |:------- |
| `JumpOutsideEdge` | If enabled, the cursor will jump outside of the block edge (blank line), otherwise it jumps inside the block edge (text line) | `true`  |
| `SkipClosestEdge` | If enabled, the cursor will only jump to the far edge of a block, otherwise it visits every edge of a block                   | `false` |

# Credits and Thanks

* [Casey Muratory](https://twitter.com/cmuratori) - I first saw this method for navigating code in his Handmade Hero video series
* [Matthias Koch](https://twitter.com/matkoch87) - For helping me get started and putting me in the Jetbrains PluginWriters slack
* [Space Block Jumper](https://marketplace.visualstudio.com/items?itemName=jmfirth.vsc-space-block-jumper) - I use this extension for the same purpose as RiderBlockJumper in VSCode
* [Anthony Reddan](https://twitter.com/AnthonyReddan) - That's me!

![RiderBlockJumper](./media/RiderBlockJumperLogo.png?raw=true "RiderBlockJumper")