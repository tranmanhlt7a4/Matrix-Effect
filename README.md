# Matrix Effect
Simple matrix effect like cmatrix on Linux <br /> <br />

Using .Net framework 4.7<br /> <br />

How to use:<br />
matrix.exe [--width value] [--charset value] [--refreshTime value] [--closeRate value] <br /><br />

Parameter meaning:<br />
width: the width of the matrix effect (Default: Console width).<br />
charset: controls which characters will be displayed (Default: 01).<br />
refresh time: effect delay time in miliseconds (the smaller the value, the faster the effect) (default: 45).<br />
close rate: controls whether the characters are close together (the larger the value, the closer the characters are) (default: 25).<br /><br />

Ex: <br />
matrix.exe<br />
matrix.exe --width 100 --charset 0123456789 --refreshTime 20 --closeRate 50<br />
matrix.exe --refreshTime 1000<br />
