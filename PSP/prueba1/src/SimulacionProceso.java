public class SimulacionProceso {

    // Simulamos los posibles estados de un proceso
    enum Estado {
        LISTO, EJECUCION, BLOQUEADO, TERMINADO
    }
    // Método para simular un proceso que cambia de estado
    public static void simularProceso() {
        Estado estado = Estado.LISTO;
        System.out.println("Estado inicial: " + estado);
        // Simular el cambio de estado a "En ejecución"
        estado = Estado.EJECUCION;
        System.out.println("Proceso en ejecución... Estado actual: " + estado);
        // Simular el cambio de estado a "Bloqueado"
        estado = Estado.BLOQUEADO;
        System.out.println("Proceso bloqueado... Esperando un recurso. Estado actual: " +
                estado);

        // Simular que el recurso está disponible, vuelve a "Listo"
        estado = Estado.LISTO;
        System.out.println("Recurso disponible. Estado actual: " + estado);
        // Simular que el proceso termina
        estado = Estado.TERMINADO;
        System.out.println("Proceso terminado. Estado actual: " + estado);
    }
    public static void main(String[] args) {
        // Simulamos varios procesos
        System.out.println("Simulando el primer proceso...");
        simularProceso();
        System.out.println("\nSimulando el segundo proceso...");
        simularProceso();
    }
}
