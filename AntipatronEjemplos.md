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
* Ahora todos los enemigos heredan el método Atacar(), y puedes sobreescribirlo si un enemigo ataca diferente.

**Ejemplo de problemas reales:** 

* Si en un juego de plataformas con Corgi Engine cada enemigo tiene su propio código de ataque copiado y pegado, agregar una nueva mecánica de combate requerirá modificar cada clase individualmente, en lugar de simplemente cambiar una sola función en la clase padre. 

### Dios todopoderoso: God Object

**Problema:** Una sola clase maneja demasiadas responsabilidades, como controlar el personaje, enemigos, interfaz, puntuación y física. 

**Ejemplo de código malo:** 

```cs
public class GameManager : MonoBehaviour 
{ 
    public void ControlarPersonaje() { /* Código del personaje */ } 
    public void GestionarEnemigos() { /* Código de los enemigos */ } 
    public void ActualizarUI() { /* Código de la interfaz */ } 
    public void GuardarPuntaje() { /* Código del puntaje */ } 
} 
```

> **Por qué es un antipatrón:** 

* Rompe el principio de responsabilidad única (SRP): Una clase debe hacer una sola cosa bien, pero el God Object maneja demasiadas responsabilidades a la vez.
* Hace el código difícil de mantener y escalar: Si necesitas cambiar algo en una parte del juego (ej. interfaz), podrías romper algo en otra (ej. enemigos).
* Complica la depuración: Si algo falla en el juego, es difícil saber qué lo causó porque todo está centralizado en una sola clase.
* Viola el principio de bajo acoplamiento: Otras clases dependen demasiado del God Object, lo que hace difícil reutilizar código. 


️ 🏁**Solución:** 

 * Divide la funcionalidad en clases específicas:
     * PlayerController para el personaje.
     * EnemyManager para enemigos.
     * UIManager para la interfaz.
     * ScoreManager para el puntaje. 


**Ejemplo de problemas reales:** 

* En un juego con Corgi Engine, si tu GameManager maneja la lógica de IA, audio, UI y física, cualquier pequeño cambio puede afectar todo el juego, haciendo el código muy frágil. 
