# Othello Game

## About the game:
The game is played in a squared-matrix.

Each player has coin in specific color (Red or Yellow).

The purpose of each player is to block a sequence of the second player, which blocked with a coin of current player. 
When a player block a sequence, the coins of the second players flip to the color of the player who made the block.
The winner is the player who has more coins of his color on the board.

## Options of the game
The first window of the game is for choosing the following game settings:
1. Board size - Choose the size of the game board from the following options: 6x6, 8x8, 10x10, 12x12.
2. Type of game (Single player of multi player) - You need to click on one from the following button to choose the type of the game:
   - Play against the computer
   - Play against your friend
   
   Clicking one of the buttons will close the settings window and open the game window with the settings you chose.

## The game:
The game begins with 4 coins in the middle of the board (2 coins for each player, diagonally across from each other).
The name of the player, whose turn it is, will appear next to the window game (Othello).
Each turn, the player need choose one cell, where he wants to place his coin, from the cells marked in green.
After the selection, the board is updated and the turn over.

> [!CAUTION]
> It is possible that a player doesn't have any empty and legal cells. In such a case, the turn will pass the the opposing player. 

**Therefore, pay attention to the player's name that appears next to the window title.**


> [!IMPORTANT]
> The game over when the board is full **or** when both players have no empty and legal cells.

A message will appear with the identity of the winner, the result of the current game and the points standings between the players.
