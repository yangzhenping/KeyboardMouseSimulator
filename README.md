# KeyboardMouseSimulator
Keyboard and Mouse Simulator on Windows


# Introduction

This is a Keyboard and Mouse Simulator on Windows, which is a program coding with C# .net 2.0.


# Usage

1. Create a file 'model.txt' under same directory with current application.

2. Edit model.txt with Keyboard or Mouse actions, each action a line, and the format is <actionname>###<actionvalue>

<actionname> can be below values:
```
LeftClick
单击
左键
DoubleClick
双击
RightClick
右键
Move
移动
Drag
拖动
Input
输入
Sleep
延迟
```
<actionvalue> can be below work with <actionname> values:
```
LeftClick###473,472
单击###473,472
左键###473,472
DoubleClick###473,472
双击###473,472
RightClick###473,472
右键###473,472
Move###473,472
移动###473,472
Drag###373,372,473,472
拖动###373,372,473,472
Input###{ENTER}I am Jumping
输入###{ENTER}我是Jumping
Sleep###1000
延迟###1000
```


# Screen shots
![Alt text](modelScreenshot.PNG?raw=true "model Screen Shot")

# A tool to get screen x value and y value

mousexy.exe is under this repository, but I don't know who is its owner, so just share it...... If you are the owner, please contract me, thanks.
