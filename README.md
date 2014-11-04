Assembler Studio Develop
======================

Assembler Studio Develop was the assembly editor for SIC and SIC XE machines make analysis and highlighting.

## Technology Stack
This project developed in C# using Microsoft 3.5 .Net Framework
Microsoft Visual Studio 2010
Highliter RichTextBox Component and UserControl
MDI Windows Form Application

## SIC and SIC XE Machines
which stands for Simplified Instructional Computer is a hypothetical architecture that was used used by 
Leland Beck in his book 'System Software' to explain the concepts of assemblers, compilers and 
operating systems. SIC/XE,(the XE stands for Extra Equipment), is an extension of SIC which has higher 
memory, greater number of registers and additional instructions. 

## Sample program code
sample SIC and SIC XE assembly code:

    LDA FIVE
    STA ALPHA
    LDCH CHARZ
    STCH C1
    
    ALPHA RESW 1
    FIVE WORD 5
    CHARZ BYTE C'Z'
    C1 RESB 1

## License
Assembler Studio Develop project licensed under [MIT](http://opensource.org/licenses/MIT) license.
