#  El Reino de los Números Infiltrados

Este programa en **C#** permite ingresar dos números naturales como límites de un rango y calcula cuántos números primos existen entre ellos.  
El rango permitido es entre **1** y **10⁸**.  
El programa finaliza si se ingresan los valores `0` y `0`.
Usa el algoritmo de **Criba Segmentada**, lo que permite resolver el problema **alrededor de 1 segundo** incluso con rangos grandes.  

## Funcionamiento del algoritmo
1. **Criba base (Eratóstenes clásico):**  
   Se calculan los primos hasta `√(10⁸) = 10,000`. Estos primos base se usarán para eliminar múltiplos en el rango solicitado.

2. **Criba segmentada:**  
   Se crea un arreglo para representar solo el rango `[a, b]`.  
   Con los primos base, se eliminan múltiplos dentro de este rango.  
   Los números que quedan marcados como verdaderos son primos.

3. **Contador:**  
   Se cuentan los números que permanecen como primos.  
   Si el límite inferior es `1`, se corrige porque **1 no es primo**.  

