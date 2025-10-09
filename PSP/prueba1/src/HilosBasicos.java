// Clase principal que demuestra el uso básico de hilos en Java
public class HilosBasicos {
    public static void main(String[] args) {
        // Se crean dos hilos, cada uno ejecutando una instancia de MiHilo con un nombre diferente
        Thread hilo1 = new Thread(new MiHilo("Hilo 1"));
        Thread hilo2 = new Thread(new MiHilo("Hilo 2"));

        // Se inician ambos hilos
        hilo1.start();
        hilo2.start();

        try{
            // El hilo principal espera a que ambos hilos terminen su ejecución
            hilo1.join();
            hilo2.join();
        }catch (InterruptedException e){
            // Si ocurre una interrupción, se imprime la traza del error
            e.printStackTrace();
        }
        // Mensaje final indicando que todos los hilos han terminado
        System.out.println("todos los hilos han terminado" );
    }
}
