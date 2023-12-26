// Console.write
// Para imprimir un mensaje completo en la consola de salida, ha empleado la primera técnica, Console.WriteLine(). Al final de la línea, agregaba un avance de línea, como cuando se crea una línea de texto con la tecla Intro o Entrar del teclado.
// Para imprimir en la consola de salida, pero sin agregar un avance de línea al final, ha usado utilizado la segunda técnica, Console.Write(). Por lo tanto, la siguiente llamada a Console.Write() imprime otro mensaje en la misma línea.
// Console es una clase, mientras que Write() es un método

// Literales de caracteres
// Si únicamente queremos imprimir un carácter alfanumérico en la pantalla, podemos crear un literal char; para ello, escribiríamos un carácter alfanumérico entre comillas simples. char se usa como abreviatura de carácter. En C#, este tipo de datos se denomina oficialmente "char", pero con frecuencia se conoce como "carácter".
// Agregue la siguiente línea de código en el editor de código:
// Console.WriteLine('b');
// Observe que la letra b está entre comillas simples 'b'. Las comillas simples crean un literal de carácter. Recuerde que el uso de comillas dobles crea un tipo de datos string.
// Si escribe el código siguiente:
// Console.WriteLine('Hello World!');
// Se obtiene el siguiente error:
// (1,19): error CS1012: Too many characters in character literal
// Observe las comillas simples que rodean Hello World!. Cuando se usan comillas simples, el compilador de C# espera un solo carácter. Sin embargo, en este caso, se usó la sintaxis literal de caracteres, pero en su lugar se proporcionaron 12 caracteres.
// Al igual que con el tipo de datos string, usamos char siempre que tengamos un solo carácter alfanumérico para presentación (no cálculo).

// Literales enteros
// Si queremos mostrar un número entero (sin fracciones) en la consola de salida, podemos usar literal int. El término int es la abreviatura de entero, que puede que recuerde de cuando ha estudiado matemáticas. En C#, este tipo de datos se denomina oficialmente "int", pero se conoce con frecuencia como "entero". Un literal int no requiere otros operadores, como string o char.
// Agregue la siguiente línea de código en el editor de código:
// Console.WriteLine(123);
// Presione el botón verde Ejecutar para ejecutar el código. Deberíamos ver el resultado siguiente en la consola de salida:
// 123