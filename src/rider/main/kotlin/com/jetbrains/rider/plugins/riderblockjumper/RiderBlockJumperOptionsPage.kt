package com.jetbrains.rider.plugins.riderblockjumper

import com.jetbrains.rider.settings.simple.SimpleOptionsPage

class RiderBlockJumperOptionsPage : SimpleOptionsPage("Block Jumper", "RiderBlockJumperOptionsPage") {
    override fun getId(): String {
        return "BlockJumperOptionsPage"
    }
}