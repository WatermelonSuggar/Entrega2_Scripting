### "Código Copiado y Pegado" (Copy-Paste Programming) 

**Problema:** En lugar de reutilizar código, se copian y pegan funciones similares en varias clases. 

**Ejemplo de código malo:** 

```cs
public class Enemigo1 
{ 
    public void Atacar() 
    { 
        Console.WriteLine("Enemigo 1 ataca con láser"); 
    } 
} 
 
public class Enemigo2 
{ 
    public void Atacar() 
    { 
        Console.WriteLine("Enemigo 2 ataca con láser"); 
    } 
}

```
 

>**¿Por qué es un antipatrón?**

* Duplica código innecesariamente: Si tienes funciones repetidas en diferentes clases, cada cambio debe hacerse en todos lados.
* Aumenta la posibilidad de errores: Si olvidas modificar una copia, podrías introducir bugs difíciles de rastrear.
* Rompe la mantenibilidad: Si quieres mejorar un comportamiento (ej. ataques de enemigos), debes hacerlo en cada enemigo manualmente en lugar de en una sola clase base. 

🏁**Solución:**

* Usar herencia o interfaces para reutilizar lógica: 

```cs
public class EnemigoBase 
{ 
    public virtual void Atacar() 
    { 
        Console.WriteLine("Enemigo ataca con láser"); 
    } 
} 
 
public class Enemigo1 : EnemigoBase { } 
public class Enemigo2 : EnemigoBase { } 

```
 
