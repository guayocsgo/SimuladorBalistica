# Simulador de Balística - Unity 3D

## Versión de Unity

- **Unity 6 (6000.0.48f1)**
- Render Pipeline: Universal Render Pipeline (URP)
- Plataforma de build: Windows, Mac, Linux

## Cómo jugar

1. Observá cómo el proyectil impacta contra las cajas, derribándolas según la potencia y el tipo de proyectil elegido.
2. El contador en pantalla muestra cuántas cajas se derribaron en el último disparo.
3. Presioná **Reiniciar** para devolver todas las cajas a su posición original y volver a intentar.

## Controles (UI)

| Control | Función |
|---|---|
| **Slider de Potencia** | Ajusta la fuerza con la que se lanza el proyectil (velocidad inicial) |
| **Slider de Ángulo** | Ajusta el ángulo vertical de disparo (0° a 90°) |
| **Slider de Dirección Horizontal** | Ajusta el ángulo horizontal de disparo, para apuntar a la izquierda o derecha (-45° a 45°) |
| **Dropdown de Proyectil** | Selecciona el tipo de proyectil a disparar (liviano, pesado, grande), cada uno con distinta masa y tamaño |
| **Botón Disparar** | Lanza el proyectil con los parámetros configurados |
| **Botón Reiniciar** | Devuelve todas las cajas a su posición y rotación inicial, y reinicia el contador de resultados |

## Características principales

- **Física real:** las cajas y proyectiles usan `Rigidbody` de Unity, por lo que las colisiones, caídas y derribos son resultado de la simulación física, no de animaciones prefabricadas.
- **Múltiples tipos de proyectil:** distintos prefabs con variación de masa y escala, seleccionables desde la UI.
- **Indicador de dirección:** una línea muestra en tiempo real hacia dónde va a salir el próximo disparo, según los ángulos configurados.
- **Estela del proyectil:** una línea punteada marca la trayectoria recorrida por la bala, visible unos segundos después del impacto.
- **Efecto de impacto:** un destello de luz aparece en el punto exacto donde el proyectil choca contra algo.
- **Contador de derribos:** después de cada disparo, se registra cuántas cajas quedaron volcadas respecto al total.
- **Cámara secundaria:** una vista adicional en una esquina de la pantalla muestra la escena desde otro ángulo.
- **Sistema de reinicio:** un botón devuelve la escena a su estado inicial sin necesidad de reiniciar el Play.

## Autor

Pedro - Licenciatura en Producción de Simuladores y Videojuegos
