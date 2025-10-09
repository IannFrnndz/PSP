// Clase que implementa un hilo personalizado en Java
public class MiHilo implements Runnable{

    // Variable para almacenar el nombre del hilo
    private String nombre;

    // Constructor que inicializa el nombre del hilo
    public MiHilo(String nombre) {
        this.nombre = nombre;
    }

    // Metodo que contiene la lógica que ejecutará el hilo
    // Debe implementarse la interfaz Runnable para que el @Override sea válido
    public void run(){
        // Bucle que se ejecuta 5 veces
        for (int i = 0; i < 5; i++) {
            // Imprime el nombre del hilo y el número de iteración
            System.out.println(nombre+ " esta en ejecucion: " + i);
            try {
                // Pausa la ejecución del hilo por 500 milisegundos
                Thread.sleep(500);

            }catch (InterruptedException e){
                // Maneja la excepción si el hilo es interrumpido
                e.printStackTrace();
            }
        }

        // Imprime que el hilo ha terminado su ejecución
        System.out.println(nombre + " ha terminado");
    }
}
