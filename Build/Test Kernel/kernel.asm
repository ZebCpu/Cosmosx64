org 0x1000000

use64

[map symbols]

begin:

_begin:

jmp entry

align 8

multiboot_header:
    MULTIBOOT_HEADER_MAGIC dq 0x1BADB002
    MULTIBOOT_HEADER_FLAGS dq 0x00010003
    Checksum dq -(0x1BADB002 + 0x00010003)
    header_addr dq multiboot_header
    load_addr dq _begin
    load_end dq _end
    bss_end dq _end
    entry_val dq entry

entry:
    mov byte [0xB8000], 65

_loop:
    jmp _loop

_end:
