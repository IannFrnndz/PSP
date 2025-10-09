public class ProcesosSimultaneos {
    public static void main(String[] args) {
        // definimos los numeros para los que queremos las tablas de multiplicar
        int[] numeros = {2, 3, 4};

        // creamos y arrancamos un hilo para cada numero
        for (int n : numeros) {
            Thread t = new Thread(new TablaMultiplicar(n), "Proceso: ");
            t.start();
            // esperamos a que termine el hilo antes de iniciar el siguiente
            try {

                t.join();
                // hacemos una pausa de 100 milisegundos entre cada hilo
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
                break;
            }
        }
    }
}
