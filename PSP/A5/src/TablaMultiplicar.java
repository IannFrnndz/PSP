public class TablaMultiplicar implements Runnable {
    private final int numero;

    public TablaMultiplicar(int numero) {
        this.numero = numero;
    }

    @Override
    public void run() {

        // obtenemos la hora actual en formato HH:mm:ss
        String hora = java.time.LocalTime.now()
                .format(java.time.format.DateTimeFormatter.ofPattern("HH:mm:ss"));

        // le ponemos un nomnbre al hilo
        String nombre = Thread.currentThread().getName();

        // decimos lo que se va a imprimir con el formato solicitado
        System.out.printf("[%s] %s - Tabla del %d:%n", hora, nombre, numero);

        // mostramos la tabla de multiplicar del numero
        for (int i = 1; i <= 10; i++) {
            System.out.printf("  %d x %d = %d%n", numero, i, numero * i);
            try {
                // hacemos una pausa de 50 milisegundos entre cada multiplicacion
                Thread.sleep(50);
            } catch (InterruptedException e) {
                // si el hilo es interrumpido, salimos del bucle
                Thread.currentThread().interrupt();
                return;
            }
        }
    }
}
