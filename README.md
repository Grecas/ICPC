# ICPC
ACM-ICPC Problems

De los 3 problemas sugeridos el escogido para implementar fue Traffic Blights. Adicionalmente se analizó el Conquer the World, interesante pero a todas luces bien complejo de solucionar. El problema Road Time no lo alcancé a revisar.

# Traffic Blights: 

Se tiene una calle: MainStreet en la cual se han dispuesto `n` semáforos que cambian entre la luz roja y verde. La luz roja tiene una duración de r seg. y la verde de v seg. Un auto aparece en el extremo oeste de la calle y se traslada con MRU hacia el este a razón de `1m/s`. El auto puede aparecer en un tiempo random, uniformemente distribuido en el intervalo `[0, 2019!]`. En el segundo cero, todos los semáforos comienzan en rojo. Se desea saber la probabilidad que tiene cada semáforo de ser el primero al que el auto tope en rojo y la probabilidad que tiene el auto de avanzar por toda la calle con todas las luces en verde. 

# Solución implementada

Lo primero que se observa es que el ciclo de repetición de cada semáforo es `c = (r+v)` y el ciclo de repetición de todos los semáforos de la calle es `C=mcm(c1,c2,...cn)`. La solución implementada comprueba en qué estado aparece cada semáforo al llegar el auto si este parte en un `0<=t<=C-1`. La probabilidad de que un semáforo esté en rojo en el seg (t) es el número de veces que está en rojo al llegar el auto dividido por C y la probabilidad de que el auto pase en verde es el número de veces que el auto pasa todos los semáforos con verde dividido por C. Esta solución sin embargo, tiene la desventaja que depende del MCM lo que implica que, para intervalos de r o g grande no es factible de calcular. 

La solution sketch propuesta en la página de la ACM-ICPC fue revisada y la entendí pero no la alcancé a implementar. La puedo explicar más adelante...


# Código
La solución fue implementada en C# con VisualStudio 2019. Es una aplicación de consola que lee de un archivo de texto Data.txt donde están los juegos de datos según la especificación de entrada del problema original. Se crearon 4 clases, siendo Program la clase donde se lee la entrada y se ejecutan los métodos que calculan las probabilidades descritas.
