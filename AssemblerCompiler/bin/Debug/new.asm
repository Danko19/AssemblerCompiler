model small
 .DATA
 a dw 19
 .CODE
 std 
 mov ax, a 
 push ax 
 sar ax, 1 
 add ax, ax 
 pop bx 
 cmp ax, bx 
 jnz a1 
 jmp a2 
 a1: add ax, 1 
 mov a, ax 
 a2: end