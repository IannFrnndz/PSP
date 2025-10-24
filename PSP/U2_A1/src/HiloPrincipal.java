public class HiloPrincipal implements Runnable {
    public void run() {
        System.out.println("Hilo: Iniciando...");
        try {
            // El hilo se pausa durante 1 segundo
            Thread.sleep(1000);
            System.out.println("Hilo: He terminado de dormir.");
        } catch (InterruptedException e) {
            System.out.println("Hilo: Fui interrumpido mientras dormía.");
            // Restablece la bandera de interrupción
            Thread.currentThread().interrupt();
        }
    }
}

